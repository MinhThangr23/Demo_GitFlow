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
using Serilog;

namespace Menu_Management
{
    public partial class HomeForm : Form
    {
        // Khai báo đối tượng log
        private static readonly ILogger log = Log.ForContext<HomeForm>();
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
            log.Information("[SaveBill] Bắt đầu lưu hóa đơn. BillID={BillID}, ItemNumber={ItemNumber}, Total={Total}", BillID, ItemNumber, totalPrice);

            // Kiểm tra đầu vào
            if (OrderInfos == null || OrderInfos.Count == 0)
            {
                log.Warning("Không có món ăn nào trong OrderInfos. Không thể lưu hóa đơn.");
                throw new Exception("Bill must contain at least 1 item.");
            }
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                log.Information("Kết nối SQL thành công.");
                // Bắt đầu giao dịch vì căn bản 2 lệnh này phải xảy ra đồng thời
                using (SqlTransaction transaction = sqlcon.BeginTransaction())
                {
                    try
                    {
                        log.Debug("Bắt đầu transaction cho Bill và BillDetails.");
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
                            log.Information("Lưu bảng Bills thành công.");
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
                                log.Debug($"Đã lưu món: {item.ItemName}, SL={item.ItemQuantity}, Giá={item.ItemTotalPrice}");
                            }
                        }
                        //chạy xong 2 lệnh INSERT thì commit giao dịch
                        transaction.Commit();
                        log.Information($"Lưu hóa đơn hoàn tất thành công cho BillID={BillID}");
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        Log.Error(ex, "Lỗi SQL khi lưu hóa đơn. Đã rollback transaction.");
                        throw; // ném tiếp lên cho chỗ gọi xử lý
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Log.Fatal(ex, "Lỗi nghiêm trọng khi lưu hóa đơn. Đã rollback transaction.");
                        throw;
                    }
                    finally
                    {
                        Log.Debug("Kết thúc SaveBill()");
                        Log.Debug("--------------------------------------");
                    }
                }
            }
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!TryGetOrderTotal(out float total))
            {
                MessageBox.Show("Please add items to the order before placing it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int billid = OrderHelper.CurrentOrderID;
            DateTime timestamp = DateTime.Now;

            UC_BillItem BillItem = CreateBillItem(billid, timestamp);

            (int itemnumber, float totalprice) = ProcessOrderItems(BillItem);

            FinalizeBill(BillItem, itemnumber, totalprice);

            SaveBill(BillItem.BillID, BillItem.OrderTime, BillItem.EmloyeeName, BillItem.ItemNumber, BillItem.totalPrice, OrderInfos);

            ResetOrderUI();
        }

        // Kiểm tra và lấy tổng tiền
        private bool TryGetOrderTotal(out float total)
        {
            total = 0;
            try
            {
                total = float.Parse(OrderTotalLabel.Text);
                return true;
            }
            catch
            {
                return false;// Trả về false nếu không thể phân tích tổng tiền
            }
        }

        // Tạo BillItem và sự kiện xóa hóa đơn
        private UC_BillItem CreateBillItem(int billid, DateTime timestamp)
        {
            UC_BillItem BillItem = new UC_BillItem(this.billform, billid.ToString(), timestamp, Login.User, "Apending");

            BillItem.ClearBillItemClicked += (sender, e) =>
            {
                if (sender is UC_BillItem clickedItem)
                {
                    billform.billflowpanel.Controls.Remove(clickedItem); // Xóa UC_BillItem khỏi billflowpanel trong BillForm
                    using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        sqlcon.Open();
                        string deleteBillQuery = "UPDATE Bills SET Status = 'Cancelled' WHERE BillID = @BillID";
                        SqlCommand cmd = new SqlCommand(deleteBillQuery, sqlcon);
                        cmd.Parameters.AddWithValue("@BillID", clickedItem.BillID); // Sử dụng BillID từ UC_BillItem
                        cmd.ExecuteNonQuery();
                    }
                }
            };
            return BillItem;
        }

        // Duyệt danh sách món ăn trong OrderflowLayout
        private (int itemnumber, float totalprice) ProcessOrderItems(UC_BillItem BillItem)
        {
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
            return (itemnumber, totalprice);
        }

        // Cập nhật tổng tiền, số lượng, thêm vào giao diện
        private void FinalizeBill(UC_BillItem BillItem, int itemnumber, float totalprice)
        {
            BillItem.totalPrice = totalprice;
            BillItem.ItemNumber = itemnumber;
            BillItem.CalculateTotalPrice();
            billform.billflowpanel.Controls.Add(BillItem);
        }

        //  Xóa đơn tạm khỏi giao diện
        private void ResetOrderUI()
        {
            OrderflowLayout.Controls.Clear();
            OrderTotalLabel.Text = "";
            OrderID.Text = "";
            OrderHelper.CurrentOrderID = 0;
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
