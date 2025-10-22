using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Management
{
    public partial class HomeForm : Form
    {
        private BillForm billform;
        public Label CategoryLBL => Category;

        List<OrderInfoClass> OrderInfos = new List<OrderInfoClass>();
        public HomeForm(BillForm billform)
        {
            InitializeComponent();
            Login.PhanQuyen(this, Login.Role);
            DatabaseHelper.ShowCategory(CategoryFlowPanel, OrderflowLayout, OrderTotalLabel, DishFlowPanel, this);
            DatabaseHelper.ShowDishes(DishFlowPanel, OrderflowLayout, OrderTotalLabel);
            this.billform=billform;
            Category.Text = "ALL"; // Đặt tiêu đề danh mục là "ALL" khi khởi tạo
            OrderHelper.OrderIDChanged += (sender, e) =>
            {
                OrderID.Text = "Transaction #" +  OrderHelper.CurrentOrderID.ToString();
            };
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchBar.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                Category.Text = "ALL"; // Đặt tiêu đề danh mục là "ALL" nếu không có từ khóa tìm kiếm
                DishFlowPanel.Controls.Clear(); // Xóa tất cả các điều khiển trong DishFlowPanel nếu không có từ khóa tìm kiếm
                DatabaseHelper.ShowDishes(DishFlowPanel, OrderflowLayout, OrderTotalLabel); // Hiển thị lại tất cả các món ăn

            }
            else
            {
                DatabaseHelper.ShowDishesBySearch(DishFlowPanel, searchText);
            }
        }

        //Hàm thêm bIll và lưu thông tin hóa đơn vào CSDL
        private void SaveBill(string BillID, DateTime OrderTime, string EmployeeName, int ItemNumber, float totalPrice, List<OrderInfoClass> OrderInfos)
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();

                // Bắt đầu giao dịch vì căn bản 2 lệnh này phải xảy ra đồng thời
                using (SqlTransaction transaction = sqlcon.BeginTransaction())
                {
                    try
                    {
                        // Lưu bảng Bills
                        string billQuery = @"INSERT INTO Bills (BillID, OrderTime, EmployeeName, TotalItem, TotalPrice, Status)
                                     VALUES (@BillID, @OrderTime, @EmployeeName, @ItemNumber, @TotalPrice, 'Appending')";
                        using (SqlCommand cmdBill = new SqlCommand(billQuery, sqlcon, transaction))
                        {
                            cmdBill.Parameters.AddWithValue("@BillID", BillID);
                            cmdBill.Parameters.AddWithValue("@OrderTime", OrderTime);
                            cmdBill.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                            cmdBill.Parameters.AddWithValue("@ItemNumber", ItemNumber);
                            cmdBill.Parameters.AddWithValue("@TotalPrice", totalPrice);
                            cmdBill.ExecuteNonQuery();
                        }

                        // Lưu từng món vào bảng BillDetails
                        string detailQuery = @"INSERT INTO BillDetails (BillID, DishID, Quantity, UnitPrice)
                                       VALUES (@BillID, @DishID, @Quantity, @UnitPrice)";
                        foreach (var item in OrderInfos)
                        {
                            using (SqlCommand cmdDetail = new SqlCommand(detailQuery, sqlcon, transaction))
                            {
                                cmdDetail.Parameters.AddWithValue("@BillID", BillID);
                                cmdDetail.Parameters.AddWithValue("@DishID", item.ItemID);
                                cmdDetail.Parameters.AddWithValue("@Quantity", item.ItemQuantity);
                                cmdDetail.Parameters.AddWithValue("@UnitPrice", item.ItemTotalPrice);
                                cmdDetail.ExecuteNonQuery();
                            }
                        }
                        //chạy xong 2 lệnh INSERT thì commit giao dịch
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        //nếu xả ra lỗi thì rollback giao dịch
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message);
                    }
                }
            }
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            int billid = OrderHelper.CurrentOrderID;
            DateTime timestamp = DateTime.Now;
            float total = 0;
            try
            {
                total = float.Parse(OrderTotalLabel.Text);
            }
            catch
            {
                MessageBox.Show("Please add items to the order before placing it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UC_BillItem BillItem = new UC_BillItem(this.billform, billid.ToString(), timestamp, Login.User, "Apending");
            BillItem.ClearBillItemClicked += (sender, e) =>
            {
                if (sender is UC_BillItem clickedItem)
                {
                    billform.billflowpanel.Controls.Remove(clickedItem); //  đúng control đang được click
                    using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        sqlcon.Open();
                        string deleteBillQuery = "UPDATE Bills SET Status = 'Cancelled' WHERE BillID = @BillID";
                        SqlCommand cmd = new SqlCommand(deleteBillQuery, sqlcon);
                        cmd.Parameters.AddWithValue("@BillID", clickedItem.BillID); // ✅ đúng BillID thực tế
                        cmd.ExecuteNonQuery();
                    }
                }
            };
            int itemnumber = 0;
            float totalprice = 0;
            foreach (Control controlitem in OrderflowLayout.Controls)
            {
                if (controlitem is UC_OrderItem Orderitem)
                {
                    string itemid = Orderitem.orderID;
                    string itemname = Orderitem.name;
                    int itemquantity = Orderitem.quantity;
                    float itemprice = Orderitem.orderPrice * itemquantity;
                    totalprice += itemprice;
                    OrderInfos.Add(new OrderInfoClass
                    {
                        ItemID = itemid,
                        ItemName = itemname,
                        ItemQuantity = itemquantity,
                        ItemTotalPrice = itemprice
                    });
                    BillItem.AddToBill(itemid, itemname, itemquantity, itemprice);
                    itemnumber++;
                }
            }

            //Tổng giá của hóa đơn
            BillItem.totalPrice = totalprice;
            BillItem.ItemNumber = itemnumber;
            // Cập nhật tổng giá và số lượng món ăn trong hóa đơn (hiển thị)

            BillItem.CalculateTotalPrice(); //Làm ơn đừng xóa dòng code này =)))))

            billform.billflowpanel.Controls.Add(BillItem);

            //Lưu thông tin hóa đơn vào CSDL
            SaveBill(BillItem.BillID, BillItem.OrderTime, BillItem.EmloyeeName, BillItem.ItemNumber, BillItem.totalPrice, OrderInfos);


            OrderflowLayout.Controls.Clear(); // Xóa các mục trong OrderflowLayout sau khi đặt hàng
            OrderTotalLabel.Text = "";
            OrderID.Text = ""; // Đặt lại ID đơn hàng
            OrderHelper.CurrentOrderID = 0; // Đặt lại tổng tiền đơn hàng
        }

        private void reload_Click(object sender, EventArgs e)
        {
            SearchBar.Text = ""; // Xóa nội dung tìm kiếm
            Category.Text = "ALL"; // Đặt tiêu đề danh mục là "ALL" khi tải lại
            DatabaseHelper.ShowDishes(DishFlowPanel, OrderflowLayout, OrderTotalLabel);
            DatabaseHelper.ShowCategory(CategoryFlowPanel, OrderflowLayout, OrderTotalLabel, DishFlowPanel, this);
        }

        private void ClearBillButton_Click(object sender, EventArgs e)
        {
            OrderHelper.CurrentOrderID = 0; // Đặt lại ID đơn hàng
            OrderID.Text = ""; // Xóa ID đơn hàng
            OrderflowLayout.Controls.Clear(); // Xóa các mục trong OrderflowLayout
            OrderTotalLabel.Text = ""; // Xóa tổng tiền
        }
    }
}
