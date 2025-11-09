using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Management.Class
{
    public class OrderHelper
    {
        public static float totalPrice = 0; //Tổng tiền của đơn hàng hiện tại
        private static int currentOrderID = 0;

        public static event EventHandler OrderIDChanged;

        public static int CurrentOrderID
        {
            get { return currentOrderID; }
            set
            {
                currentOrderID = value;
                OrderIDChanged?.Invoke(null, EventArgs.Empty); // Gọi sự kiện khi ID đơn hàng thay đổi
            }
        }
        public static void CalculateTotalPrice(FlowLayoutPanel Orderfl)
        {
            float total = 0;
            foreach (Control item in Orderfl.Controls)
            {
                if (item is UC_OrderItem OrderItem)
                {
                    total += OrderItem.orderPrice * OrderItem.quantity;
                }   
            }
            totalPrice = total; //Cập nhật tổng tiền
        }
    }
}
