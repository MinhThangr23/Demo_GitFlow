using Menu_Management.Class;
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
    public partial class UC_BillItem : UserControl
    {
        BillForm billform;

        public FlowLayoutPanel OrderPanel => OrderItemHolderFlowPanel;
        public event EventHandler ClearBillItemClicked;

        public string BillStatus;
        public string BillID;
        public DateTime OrderTime;
        public string EmloyeeName;
        public int ItemNumber;
        public float totalPrice;

        public List<OrderInfoClass> OrderInfos;
        public UC_BillItem(BillForm billform, string billid, DateTime OrderTime, string employeename, string BillStatus , float totalprice = 0)
        {
            InitializeComponent();

            this.billform = billform;
            OrderInfos = new List<OrderInfoClass>();
            Bill.Text = billid;
            this.BillID = billid;

            OrderedTime.Text = OrderTime.ToString();
            this.OrderTime = OrderTime;

            EmployeeName.Text = employeename;
            this.EmloyeeName = employeename;

            this.totalPrice = totalprice;
            OrderTotal.Text = totalprice.ToString();

            this.BillStatus = BillStatus;
            Status.Text = BillStatus;
        }


        public UC_BillItem()
        {
            InitializeComponent();
            OrderInfos = new List<OrderInfoClass>();
        }

        public void AddToBill(string ItemID, string itemName, int quantity, float price)
        {
            this.OrderInfos.Add(new OrderInfoClass
            {
                ItemID = ItemID,
                ItemName = itemName,
                ItemQuantity = quantity,
                ItemTotalPrice = price
            });
            this.ItemNumber = quantity;
            Label item = new Label();
            item.AutoSize = true;
            item.MaximumSize = new Size(260, 0);
            item.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            item.Text = ItemNumber.ToString() + " --- " + itemName + " --- " + quantity + " --- " + price;
            item.Margin = new Padding(3);

            OrderPanel.Controls.Add(item);
        }

        public void CalculateTotalPrice()
        {
            OrderTotal.Text = "";
            OrderTotal.Text = totalPrice.ToString();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            AlertPrintForm printform = new AlertPrintForm(this.billform, this.BillID, this.OrderTime, this.EmloyeeName, this.ItemNumber, this.totalPrice,  this.OrderInfos);
            printform.Show();
        }

        private void ClearBill_Click(object sender, EventArgs e)
        {

            ClearBillItemClicked?.Invoke(this, e); // Gọi sự kiện khi nút Clear được nhấn
        }
    }
}
