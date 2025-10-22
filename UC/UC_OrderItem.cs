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
    public partial class UC_OrderItem : UserControl
    {
        public string orderID;
        public string orderCategoryID;
        public float orderPrice;
        public int quantity;
        public string name;

        public event EventHandler quantityChanged; // Sự kiện khi số lượng thay đổi
        public event EventHandler removeOrderItem; // Sự kiện khi xóa mục đơn hàng
        public UC_OrderItem(string orderName, float orderPrice, Image orderImage, string orderID, string orderCategoryID)
        {
            InitializeComponent();
            OrderImage.Image = orderImage;
            OrderName.Text = orderName;
            OrderPrice.Text = orderPrice.ToString();
            this.name = orderName;
            this.quantity = int.Parse(Quantity.Text);
            this.orderPrice = orderPrice;
            this.orderCategoryID=orderCategoryID;
            this.orderID = orderID;
        }

        private void MinusOrder_Click(object sender, EventArgs e)
        {
            if (Quantity.Text == "0" || Quantity.Text == "1")
            {
                Quantity.Text = "0"; // không cho số lượng nhỏ hơn 0
            }
            else
            {
                Quantity.Text = (int.Parse(Quantity.Text) - 1).ToString();
            }

        }
        private void IncreaseOrder_Click(object sender, EventArgs e)
        {
            Quantity.Text = (int.Parse(Quantity.Text) + 1).ToString();
        }
        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; //không cho nhập ký tự khác số
            }
        }

        private void Quantity_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(Quantity.Text, out int q) || q < 1)
            {
                Quantity.Text = "1";
                return;
            }

            quantity = q;
            quantityChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ClearOrderItem_Click(object sender, EventArgs e)
        {
            removeOrderItem?.Invoke(this, EventArgs.Empty);
        }
    }
}
