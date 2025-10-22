namespace Menu_Management
{
    partial class UC_BillItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_BillItem));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelMain = new Panel();
            OrderHolderPanel = new Panel();
            OrderItemHolderFlowPanel = new FlowLayoutPanel();
            label9 = new Label();
            panel1 = new Panel();
            OrderTotal = new Label();
            label2 = new Label();
            label4 = new Label();
            PrintButton = new Guna.UI2.WinForms.Guna2Button();
            panelHeader = new Panel();
            Status = new Label();
            StatusLabel = new Label();
            label5 = new Label();
            label3 = new Label();
            EmployeeName = new Label();
            OrderedTime = new Label();
            Bill = new Label();
            label1 = new Label();
            ClearBill = new Guna.UI2.WinForms.Guna2Button();
            panelMain.SuspendLayout();
            OrderHolderPanel.SuspendLayout();
            panel1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(OrderHolderPanel);
            panelMain.Controls.Add(panel1);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(280, 400);
            panelMain.TabIndex = 0;
            // 
            // OrderHolderPanel
            // 
            OrderHolderPanel.BackColor = Color.White;
            OrderHolderPanel.Controls.Add(OrderItemHolderFlowPanel);
            OrderHolderPanel.Controls.Add(label9);
            OrderHolderPanel.Dock = DockStyle.Fill;
            OrderHolderPanel.Location = new Point(0, 134);
            OrderHolderPanel.Name = "OrderHolderPanel";
            OrderHolderPanel.Size = new Size(280, 168);
            OrderHolderPanel.TabIndex = 2;
            // 
            // OrderItemHolderFlowPanel
            // 
            OrderItemHolderFlowPanel.AutoScroll = true;
            OrderItemHolderFlowPanel.Location = new Point(0, 23);
            OrderItemHolderFlowPanel.Name = "OrderItemHolderFlowPanel";
            OrderItemHolderFlowPanel.Size = new Size(280, 171);
            OrderItemHolderFlowPanel.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(12, 3);
            label9.Name = "label9";
            label9.Size = new Size(246, 17);
            label9.TabIndex = 0;
            label9.Text = "[No.] --- [Item Name] --- [Qty]  --- [Price]";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(OrderTotal);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(PrintButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 302);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 98);
            panel1.TabIndex = 1;
            // 
            // OrderTotal
            // 
            OrderTotal.AutoSize = true;
            OrderTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OrderTotal.Location = new Point(68, 3);
            OrderTotal.Name = "OrderTotal";
            OrderTotal.Size = new Size(88, 21);
            OrderTotal.TabIndex = 23;
            OrderTotal.Text = "something";
            OrderTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(162, 3);
            label2.Name = "label2";
            label2.Size = new Size(43, 21);
            label2.TabIndex = 23;
            label2.Text = "VNĐ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 3);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 23;
            label4.Text = "Total :";
            // 
            // PrintButton
            // 
            PrintButton.BorderRadius = 25;
            PrintButton.CustomizableEdges = customizableEdges9;
            PrintButton.DisabledState.BorderColor = Color.DarkGray;
            PrintButton.DisabledState.CustomBorderColor = Color.DarkGray;
            PrintButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            PrintButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            PrintButton.FillColor = Color.FromArgb(255, 107, 0);
            PrintButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrintButton.ForeColor = Color.White;
            PrintButton.Location = new Point(60, 40);
            PrintButton.Name = "PrintButton";
            PrintButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            PrintButton.Size = new Size(153, 49);
            PrintButton.TabIndex = 18;
            PrintButton.Text = "Print";
            PrintButton.Click += PrintButton_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(28, 40, 51);
            panelHeader.Controls.Add(Status);
            panelHeader.Controls.Add(StatusLabel);
            panelHeader.Controls.Add(label5);
            panelHeader.Controls.Add(label3);
            panelHeader.Controls.Add(EmployeeName);
            panelHeader.Controls.Add(OrderedTime);
            panelHeader.Controls.Add(Bill);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(ClearBill);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(280, 134);
            panelHeader.TabIndex = 0;
            // 
            // Status
            // 
            Status.AutoSize = true;
            Status.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Status.ForeColor = Color.FromArgb(255, 107, 0);
            Status.Location = new Point(98, 101);
            Status.Name = "Status";
            Status.Size = new Size(66, 17);
            Status.TabIndex = 6;
            Status.Text = "Unknown";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusLabel.ForeColor = Color.FromArgb(255, 107, 0);
            StatusLabel.Location = new Point(13, 101);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(49, 17);
            StatusLabel.TabIndex = 5;
            StatusLabel.Text = "Status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(255, 107, 0);
            label5.Location = new Point(13, 70);
            label5.Name = "label5";
            label5.Size = new Size(70, 17);
            label5.TabIndex = 4;
            label5.Text = "Employee:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 107, 0);
            label3.Location = new Point(13, 44);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 4;
            label3.Text = "Time:";
            // 
            // EmployeeName
            // 
            EmployeeName.AutoSize = true;
            EmployeeName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmployeeName.ForeColor = Color.FromArgb(255, 107, 0);
            EmployeeName.Location = new Point(98, 70);
            EmployeeName.Name = "EmployeeName";
            EmployeeName.Size = new Size(95, 17);
            EmployeeName.TabIndex = 4;
            EmployeeName.Text = "Nguyễn Văn A";
            // 
            // OrderedTime
            // 
            OrderedTime.AutoSize = true;
            OrderedTime.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OrderedTime.ForeColor = Color.FromArgb(255, 107, 0);
            OrderedTime.Location = new Point(93, 44);
            OrderedTime.Name = "OrderedTime";
            OrderedTime.Size = new Size(115, 17);
            OrderedTime.TabIndex = 4;
            OrderedTime.Text = "1/6/2025 - 17:23:12";
            // 
            // Bill
            // 
            Bill.AutoSize = true;
            Bill.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Bill.ForeColor = Color.FromArgb(255, 107, 0);
            Bill.Location = new Point(83, 17);
            Bill.Name = "Bill";
            Bill.Size = new Size(53, 17);
            Bill.TabIndex = 4;
            Bill.Text = "HD1254";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 107, 0);
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(50, 17);
            label1.TabIndex = 4;
            label1.Text = "Bill No:";
            // 
            // ClearBill
            // 
            ClearBill.BackColor = Color.Transparent;
            ClearBill.BorderRadius = 5;
            customizableEdges11.BottomRight = false;
            customizableEdges11.TopLeft = false;
            customizableEdges11.TopRight = false;
            ClearBill.CustomizableEdges = customizableEdges11;
            ClearBill.DisabledState.BorderColor = Color.DarkGray;
            ClearBill.DisabledState.CustomBorderColor = Color.DarkGray;
            ClearBill.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ClearBill.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ClearBill.FillColor = Color.FromArgb(255, 107, 0);
            ClearBill.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearBill.ForeColor = Color.Black;
            ClearBill.Image = (Image)resources.GetObject("ClearBill.Image");
            ClearBill.ImageSize = new Size(12, 12);
            ClearBill.Location = new Point(250, 0);
            ClearBill.Name = "ClearBill";
            ClearBill.ShadowDecoration.CustomizableEdges = customizableEdges12;
            ClearBill.Size = new Size(30, 22);
            ClearBill.TabIndex = 3;
            ClearBill.Click += ClearBill_Click;
            // 
            // UC_BillItem
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(panelMain);
            Margin = new Padding(10);
            Name = "UC_BillItem";
            Size = new Size(280, 400);
            panelMain.ResumeLayout(false);
            OrderHolderPanel.ResumeLayout(false);
            OrderHolderPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel OrderHolderPanel;
        private Panel panel1;
        private Panel panelHeader;
        private Guna.UI2.WinForms.Guna2Button PrintButton;
        private Label label4;
        private Label OrderTotal;
        private Guna.UI2.WinForms.Guna2Button ClearBill;
        private Label label5;
        private Label label3;
        private Label Bill;
        private Label label1;
        private Label EmployeeName;
        private Label OrderedTime;
        private Label label9;
        private FlowLayoutPanel OrderItemHolderFlowPanel;
        private Label label2;
        private Label Status;
        private Label StatusLabel;
    }
}
