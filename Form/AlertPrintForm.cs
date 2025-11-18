using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Menu_Management.Class;
using Microsoft.Data.SqlClient;

namespace Menu_Management
{
    public partial class AlertPrintForm : Form
    {
        BillForm billform;

        // Biến để hỗ trợ in hóa đơn
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        private int currentLine = 0;
        private List<string> billLines;

        // Thông tin hóa đơn
        public string BillStatus;
        public string BillID;
        public DateTime OrderTime;
        public string EmployeeName;
        public int ItemNumber;
        public float totalPrice;
        public List<OrderInfoClass> OrderInfos;

        public AlertPrintForm(BillForm billform,string BillID, DateTime OrderTime, string EmployeeName, int ItemNumber, float totalPrice, List<OrderInfoClass> OrderInfos)
        {
            InitializeComponent();
            this.billform = billform;
            this.BillID = BillID;
            this.OrderTime = OrderTime;
            this.EmployeeName = EmployeeName;
            this.ItemNumber = ItemNumber;
            this.totalPrice = totalPrice;
            this.OrderInfos = OrderInfos;


            // Gắn sự kiện in 1 lần
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void BuildBillContent()
        {
            billLines = new List<string>();

            AddHeader();
            AddItems();
            AddFooter();
        }
        //Tách phần Header
        private void AddHeader()
        {
            billLines.Add("         Sales Invoice");
            billLines.Add("-------------------------------");
            billLines.Add($"Invoice No  : {BillID}");
            billLines.Add($"Employee   : {EmployeeName}");
            billLines.Add($"Date & Time   : {OrderTime}");
            billLines.Add("-------------------------------");
            billLines.Add(string.Format("{0,-20} {1,5} {2,12}", "Item", "Qty", "Price"));
        }
        //Tách phần Items
        private void AddItems()
        {
            foreach (var item in OrderInfos)
            {
                billLines.Add(BuildItemLine(item));
            }
        }
        private string BuildItemLine(OrderInfoClass item)
        {
            string name = ShortenName(item.ItemName);

            return string.Format("{0,-20} {1,5} {2,12:N0}",
                name, item.ItemQuantity, item.ItemTotalPrice);
        }
        private string ShortenName(string name)
        {
            return name.Length > 20 ? name.Substring(0, 17) + "..." : name;
        }
        //Tách phần Footer
        private void AddFooter()
        {
            billLines.Add("-------------------------------");
            billLines.Add($"Total Items: {ItemNumber}");
            billLines.Add($"Total Amount: {totalPrice:N0} VND");
            billLines.Add("-------------------------------");
            billLines.Add("  Thank you for your support!");
        }



        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Courier New", 12);
            float yPos = 10; // Vị trí bắt đầu vẽ văn bản
            float leftMargin = 10; // Lề trái của trang in
            float lineHeight = font.GetHeight(e.Graphics); // Chiều cao của mỗi dòng văn bản
            int linesPerPage = (int)(e.MarginBounds.Height / lineHeight); // Số dòng có thể in trên mỗi trang

            while (currentLine < billLines.Count) //Lặp qua từng dòng trong danh sách
            {
                string line = billLines[currentLine];
                e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos); // Vẽ dòng văn bản, DrawString sẽ vẽ dòng văn bản tại vị trí (leftMargin, yPos) trên trang in
                yPos += lineHeight; // Cập nhật vị trí yPos cho dòng tiếp theo
                currentLine++; //tăng thêm 1 dòng

                if ((currentLine % linesPerPage) == 0)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
            currentLine = 0; // Reset cho lần in tiếp theo
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            BuildBillContent();

            ShowPrintPreview();

            if (ShowPrintDialog())
            {
                PrintDocumentNow();
            }

            CompleteAfterPrinting();
        }
        //Xem truoc khi in
        private void ShowPrintPreview()
        {
            previewDialog.Document = printDocument;
            previewDialog.PrintPreviewControl.Zoom = 1.3;
            previewDialog.Width = 600;
            previewDialog.Height = 800;
            previewDialog.ShowDialog();
        }
        //Mở dialog chọn máy in
        private bool ShowPrintDialog()
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                return printDialog.ShowDialog() == DialogResult.OK;
            }
        }
        //Thực hiện in
        private void PrintDocumentNow()
        {
            printDocument.Print();
        }
        //Xử lý sau khi in (đóng form + cập nhật DB + load lại bill
        private void CompleteAfterPrinting()
        {
            this.Close();
            FinalizeBill();
            BillHelper.LoadBills(billform.billflowpanel, billform);
        }



        private void NotPrintButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Không in, chỉ đóng form
        }


        private void FinalizeBill()
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string updatestatusQuery = "UPDATE Bills SET Status = 'Done' WHERE BillID = @OrderID";
                SqlCommand sqlcmd = new SqlCommand(updatestatusQuery, sqlcon);
                sqlcmd.Parameters.AddWithValue("@OrderID", BillID);
                sqlcmd.ExecuteNonQuery(); // Cập nhật trạng thái hóa đơn thành "Done"
            }    
        }
    }
}
