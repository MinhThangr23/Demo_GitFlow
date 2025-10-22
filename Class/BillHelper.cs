using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Management.Class
{
    internal class BillHelper
    {
        public class Bills
        {
            public string BillID { get; set; }
            public DateTime OrderTime { get; set; }
            public string EmployeeName { get; set; }
            public float TotalPrice { get; set; }
            public string Status { get; set; } = "Appending"; // Trạng thái mặc định là "Appending"
        }

        public static List <Bills> GroupedBill = new List<Bills>();
        internal static void LoadBills(FlowLayoutPanel fl, BillForm billform)
        {
            GroupedBill.Clear();
            fl.Controls.Clear(); // Xóa các điều khiển hiện tại trong FlowLayoutPanel trước khi thêm các mục mới
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                getBillIDs(GroupedBill);
                foreach(Bills Bill in GroupedBill)
                {
                    string query = "SELECT d.DishID, DishName, Quantity, UnitPrice FROM Bills b\r\n"
                    + "JOIN BillDetails bd ON bd.BillID = b.BillID\r\n"
                    + "JOIN Dishes d ON d.DishID = bd.DishID\r\n"
                    +"WHERE b.BillID = @BillID AND Status = 'Appending'";
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@BillID", Bill.BillID);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        UC_BillItem billItem = new UC_BillItem(billform, Bill.BillID, Bill.OrderTime, Bill.EmployeeName, Bill.Status, Bill.TotalPrice);

                        //Đăng ký sự kiện xóa hóa đơn
                        billItem.ClearBillItemClicked += (sender, e) =>
                        {
                            if (sender is UC_BillItem clickedItem)
                            {
                                fl.Controls.Remove(clickedItem);
                                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                                {
                                    sqlcon.Open();
                                    string deleteBillQuery = "UPDATE Bills SET Status = 'Cancelled' WHERE BillID = @BillID";
                                    SqlCommand cmd = new SqlCommand(deleteBillQuery, sqlcon);
                                    cmd.Parameters.AddWithValue("@BillID", clickedItem.BillID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        };
                        while (reader.Read())
                        {
                            string itemName = reader["DishName"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            float price = Convert.ToSingle(reader["UnitPrice"]);
                            string itemID = reader["DishID"].ToString();
                            billItem.AddToBill(itemID, itemName, quantity, price);
                        }
                        fl.Controls.Add(billItem);
                    }
                    reader.Close();
                }    
            }
        }

        private static void getBillIDs(List <Bills> BillIds)
        {
            using(SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string query = "SELECT * FROM Bills";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BillIds.Add(new Bills
                        {
                            BillID = reader["BillID"].ToString(),
                            OrderTime = Convert.ToDateTime(reader["OrderTime"]),
                            EmployeeName = reader["EmployeeName"].ToString(),
                            TotalPrice = Convert.ToSingle(reader["TotalPrice"]),
                            Status = reader["Status"].ToString()
                        });
                    }
                }    
                reader.Close();
            }
        }
    }
}
