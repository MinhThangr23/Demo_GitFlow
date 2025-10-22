namespace Menu_Management
{
    partial class HomeForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelMainContent = new Panel();
            panelMenu = new Panel();
            reload = new Guna.UI2.WinForms.Guna2Button();
            Category = new Label();
            DishFlowPanel = new FlowLayoutPanel();
            panelCategory = new Panel();
            CategoryFlowPanel = new FlowLayoutPanel();
            panelHeader = new Panel();
            SearchBar = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            CurrentOrderPanel = new Panel();
            ClearBillButton = new Guna.UI2.WinForms.Guna2Button();
            Currency = new Label();
            OrderTotalLabel = new Label();
            label4 = new Label();
            btnOrder = new Guna.UI2.WinForms.Guna2Button();
            OrderflowLayout = new FlowLayoutPanel();
            OrderID = new Label();
            label2 = new Label();
            panelMainContent.SuspendLayout();
            panelMenu.SuspendLayout();
            panelCategory.SuspendLayout();
            panelHeader.SuspendLayout();
            CurrentOrderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(panelMenu);
            panelMainContent.Controls.Add(panelCategory);
            panelMainContent.Controls.Add(panelHeader);
            panelMainContent.Controls.Add(CurrentOrderPanel);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(982, 775);
            panelMainContent.TabIndex = 1;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(reload);
            panelMenu.Controls.Add(Category);
            panelMenu.Controls.Add(DishFlowPanel);
            panelMenu.Dock = DockStyle.Fill;
            panelMenu.Location = new Point(0, 196);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(659, 579);
            panelMenu.TabIndex = 3;
            // 
            // reload
            // 
            reload.BorderRadius = 5;
            reload.CustomizableEdges = customizableEdges1;
            reload.DisabledState.BorderColor = Color.DarkGray;
            reload.DisabledState.CustomBorderColor = Color.DarkGray;
            reload.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            reload.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            reload.FillColor = Color.Transparent;
            reload.Font = new Font("Segoe UI", 9F);
            reload.ForeColor = Color.White;
            reload.Image = (Image)resources.GetObject("reload.Image");
            reload.ImageSize = new Size(30, 30);
            reload.Location = new Point(609, 0);
            reload.Name = "reload";
            reload.ShadowDecoration.CustomizableEdges = customizableEdges2;
            reload.Size = new Size(47, 35);
            reload.TabIndex = 14;
            reload.Click += reload_Click;
            // 
            // Category
            // 
            Category.AutoSize = true;
            Category.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Category.Location = new Point(8, 3);
            Category.Name = "Category";
            Category.Size = new Size(133, 25);
            Category.TabIndex = 12;
            Category.Text = "CategoryItems";
            // 
            // DishFlowPanel
            // 
            DishFlowPanel.AutoScroll = true;
            DishFlowPanel.Location = new Point(3, 36);
            DishFlowPanel.Name = "DishFlowPanel";
            DishFlowPanel.Size = new Size(653, 543);
            DishFlowPanel.TabIndex = 3;
            // 
            // panelCategory
            // 
            panelCategory.Controls.Add(CategoryFlowPanel);
            panelCategory.Dock = DockStyle.Top;
            panelCategory.Location = new Point(0, 66);
            panelCategory.Name = "panelCategory";
            panelCategory.Size = new Size(659, 130);
            panelCategory.TabIndex = 2;
            // 
            // CategoryFlowPanel
            // 
            CategoryFlowPanel.AutoScroll = true;
            CategoryFlowPanel.Dock = DockStyle.Fill;
            CategoryFlowPanel.Location = new Point(0, 0);
            CategoryFlowPanel.Name = "CategoryFlowPanel";
            CategoryFlowPanel.Size = new Size(659, 130);
            CategoryFlowPanel.TabIndex = 11;
            CategoryFlowPanel.WrapContents = false;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(SearchBar);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(659, 66);
            panelHeader.TabIndex = 1;
            // 
            // SearchBar
            // 
            SearchBar.BorderRadius = 20;
            SearchBar.BorderThickness = 0;
            SearchBar.CustomizableEdges = customizableEdges3;
            SearchBar.DefaultText = "";
            SearchBar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            SearchBar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            SearchBar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            SearchBar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            SearchBar.FillColor = Color.FromArgb(224, 224, 224);
            SearchBar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            SearchBar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchBar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            SearchBar.IconRight = (Image)resources.GetObject("SearchBar.IconRight");
            SearchBar.IconRightSize = new Size(36, 36);
            SearchBar.Location = new Point(331, 9);
            SearchBar.Margin = new Padding(4);
            SearchBar.Name = "SearchBar";
            SearchBar.PlaceholderForeColor = Color.Silver;
            SearchBar.PlaceholderText = "Search dish";
            SearchBar.SelectedText = "";
            SearchBar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            SearchBar.Size = new Size(315, 45);
            SearchBar.TabIndex = 11;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 11);
            label1.Name = "label1";
            label1.Size = new Size(113, 45);
            label1.TabIndex = 10;
            label1.Text = "Dishes";
            // 
            // CurrentOrderPanel
            // 
            CurrentOrderPanel.BackColor = Color.FromArgb(234, 234, 234);
            CurrentOrderPanel.Controls.Add(ClearBillButton);
            CurrentOrderPanel.Controls.Add(Currency);
            CurrentOrderPanel.Controls.Add(OrderTotalLabel);
            CurrentOrderPanel.Controls.Add(label4);
            CurrentOrderPanel.Controls.Add(btnOrder);
            CurrentOrderPanel.Controls.Add(OrderflowLayout);
            CurrentOrderPanel.Controls.Add(OrderID);
            CurrentOrderPanel.Controls.Add(label2);
            CurrentOrderPanel.Dock = DockStyle.Right;
            CurrentOrderPanel.Location = new Point(659, 0);
            CurrentOrderPanel.Name = "CurrentOrderPanel";
            CurrentOrderPanel.Size = new Size(323, 775);
            CurrentOrderPanel.TabIndex = 0;
            // 
            // ClearBillButton
            // 
            ClearBillButton.BorderRadius = 5;
            ClearBillButton.CustomizableEdges = customizableEdges5;
            ClearBillButton.DisabledState.BorderColor = Color.DarkGray;
            ClearBillButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ClearBillButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ClearBillButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ClearBillButton.FillColor = Color.Transparent;
            ClearBillButton.Font = new Font("Segoe UI", 9F);
            ClearBillButton.ForeColor = Color.White;
            ClearBillButton.Image = (Image)resources.GetObject("ClearBillButton.Image");
            ClearBillButton.ImageSize = new Size(30, 30);
            ClearBillButton.Location = new Point(276, 31);
            ClearBillButton.Name = "ClearBillButton";
            ClearBillButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ClearBillButton.Size = new Size(47, 35);
            ClearBillButton.TabIndex = 15;
            ClearBillButton.Click += ClearBillButton_Click;
            // 
            // Currency
            // 
            Currency.AutoSize = true;
            Currency.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Currency.Location = new Point(104, 670);
            Currency.Name = "Currency";
            Currency.Size = new Size(53, 25);
            Currency.TabIndex = 24;
            Currency.Text = "VNĐ";
            // 
            // OrderTotalLabel
            // 
            OrderTotalLabel.AutoSize = true;
            OrderTotalLabel.BackColor = Color.Transparent;
            OrderTotalLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OrderTotalLabel.Location = new Point(182, 670);
            OrderTotalLabel.Name = "OrderTotalLabel";
            OrderTotalLabel.Size = new Size(0, 25);
            OrderTotalLabel.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 670);
            label4.Name = "label4";
            label4.Size = new Size(63, 25);
            label4.TabIndex = 22;
            label4.Text = "Total :";
            // 
            // btnOrder
            // 
            btnOrder.BackColor = Color.Transparent;
            btnOrder.BorderRadius = 10;
            btnOrder.CustomizableEdges = customizableEdges7;
            btnOrder.DisabledState.BorderColor = Color.DarkGray;
            btnOrder.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOrder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOrder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOrder.FillColor = Color.FromArgb(255, 107, 0);
            btnOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrder.ForeColor = Color.White;
            btnOrder.Location = new Point(13, 714);
            btnOrder.Name = "btnOrder";
            btnOrder.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnOrder.Size = new Size(298, 49);
            btnOrder.TabIndex = 21;
            btnOrder.Text = "Order";
            btnOrder.Click += btnOrder_Click;
            // 
            // OrderflowLayout
            // 
            OrderflowLayout.AutoScroll = true;
            OrderflowLayout.BackColor = Color.FromArgb(234, 234, 234);
            OrderflowLayout.Location = new Point(0, 66);
            OrderflowLayout.Name = "OrderflowLayout";
            OrderflowLayout.Size = new Size(323, 583);
            OrderflowLayout.TabIndex = 6;
            // 
            // OrderID
            // 
            OrderID.AutoSize = true;
            OrderID.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderID.Location = new Point(20, 49);
            OrderID.Name = "OrderID";
            OrderID.Size = new Size(0, 17);
            OrderID.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 9);
            label2.Name = "label2";
            label2.Size = new Size(131, 25);
            label2.TabIndex = 2;
            label2.Text = "Current Order";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 775);
            Controls.Add(panelMainContent);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            panelMainContent.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelCategory.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            CurrentOrderPanel.ResumeLayout(false);
            CurrentOrderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainContent;
        private Panel panelMenu;
        private Label CategoryLabel;
        private FlowLayoutPanel DishFlowPanel;
        private Panel panelCategory;
        private FlowLayoutPanel CategoryFlowPanel;
        private Panel panelHeader;
        private Guna.UI2.WinForms.Guna2TextBox SearchBar;
        private Label label1;
        private Panel CurrentOrderPanel;
        private Label OrderTotalLabel;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Button btnOrder;
        private FlowLayoutPanel OrderflowLayout;
        private Label OrderID;
        private Label label2;
        private UC_OrderItem uC_OrderItem1;
        private Label Currency;
        private Label Category;
        private Guna.UI2.WinForms.Guna2Button reload;
        private Guna.UI2.WinForms.Guna2Button ClearBillButton;
    }
}