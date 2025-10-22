namespace Menu_Management
{
    partial class UC_OrderItem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_OrderItem));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            OrderImage = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            Quantity = new Guna.UI2.WinForms.Guna2TextBox();
            IncreaseOrder = new Guna.UI2.WinForms.Guna2Button();
            MinusOrder = new Guna.UI2.WinForms.Guna2Button();
            ClearOrderItem = new Guna.UI2.WinForms.Guna2Button();
            OrderPrice = new Label();
            OrderName = new Label();
            ((System.ComponentModel.ISupportInitialize)OrderImage).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // OrderImage
            // 
            OrderImage.BorderRadius = 10;
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopRight = false;
            OrderImage.CustomizableEdges = customizableEdges1;
            OrderImage.Dock = DockStyle.Left;
            OrderImage.FillColor = Color.LightGray;
            OrderImage.Image = (Image)resources.GetObject("OrderImage.Image");
            OrderImage.ImageRotate = 0F;
            OrderImage.Location = new Point(0, 0);
            OrderImage.Name = "OrderImage";
            OrderImage.ShadowDecoration.CustomizableEdges = customizableEdges2;
            OrderImage.Size = new Size(136, 110);
            OrderImage.SizeMode = PictureBoxSizeMode.StretchImage;
            OrderImage.TabIndex = 0;
            OrderImage.TabStop = false;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(Quantity);
            guna2Panel1.Controls.Add(IncreaseOrder);
            guna2Panel1.Controls.Add(MinusOrder);
            guna2Panel1.Controls.Add(ClearOrderItem);
            guna2Panel1.Controls.Add(OrderPrice);
            guna2Panel1.Controls.Add(OrderName);
            customizableEdges11.BottomLeft = false;
            customizableEdges11.TopLeft = false;
            guna2Panel1.CustomizableEdges = customizableEdges11;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.LightGray;
            guna2Panel1.Location = new Point(136, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel1.Size = new Size(149, 110);
            guna2Panel1.TabIndex = 1;
            // 
            // Quantity
            // 
            Quantity.BorderRadius = 5;
            Quantity.BorderThickness = 0;
            Quantity.CustomizableEdges = customizableEdges3;
            Quantity.DefaultText = "1";
            Quantity.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Quantity.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Quantity.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Quantity.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Quantity.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Quantity.Font = new Font("Segoe UI", 9F);
            Quantity.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Quantity.Location = new Point(60, 82);
            Quantity.Name = "Quantity";
            Quantity.PlaceholderText = "";
            Quantity.SelectedText = "";
            Quantity.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Quantity.Size = new Size(30, 25);
            Quantity.TabIndex = 3;
            Quantity.TextAlign = HorizontalAlignment.Center;
            Quantity.TextChanged += Quantity_TextChanged;
            Quantity.KeyPress += Quantity_KeyPress;
            // 
            // IncreaseOrder
            // 
            IncreaseOrder.BorderRadius = 5;
            IncreaseOrder.CustomizableEdges = customizableEdges5;
            IncreaseOrder.DisabledState.BorderColor = Color.DarkGray;
            IncreaseOrder.DisabledState.CustomBorderColor = Color.DarkGray;
            IncreaseOrder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            IncreaseOrder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            IncreaseOrder.FillColor = Color.Transparent;
            IncreaseOrder.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IncreaseOrder.ForeColor = Color.Black;
            IncreaseOrder.Image = (Image)resources.GetObject("IncreaseOrder.Image");
            IncreaseOrder.ImageSize = new Size(15, 15);
            IncreaseOrder.Location = new Point(96, 82);
            IncreaseOrder.Name = "IncreaseOrder";
            IncreaseOrder.ShadowDecoration.CustomizableEdges = customizableEdges6;
            IncreaseOrder.Size = new Size(30, 25);
            IncreaseOrder.TabIndex = 2;
            IncreaseOrder.Click += IncreaseOrder_Click;
            // 
            // MinusOrder
            // 
            MinusOrder.BorderRadius = 5;
            MinusOrder.CustomizableEdges = customizableEdges7;
            MinusOrder.DisabledState.BorderColor = Color.DarkGray;
            MinusOrder.DisabledState.CustomBorderColor = Color.DarkGray;
            MinusOrder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            MinusOrder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            MinusOrder.FillColor = Color.Transparent;
            MinusOrder.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MinusOrder.ForeColor = Color.Black;
            MinusOrder.Image = (Image)resources.GetObject("MinusOrder.Image");
            MinusOrder.ImageOffset = new Point(0, 1);
            MinusOrder.ImageSize = new Size(15, 15);
            MinusOrder.Location = new Point(24, 82);
            MinusOrder.Name = "MinusOrder";
            MinusOrder.ShadowDecoration.CustomizableEdges = customizableEdges8;
            MinusOrder.Size = new Size(30, 25);
            MinusOrder.TabIndex = 2;
            MinusOrder.Click += MinusOrder_Click;
            // 
            // ClearOrderItem
            // 
            ClearOrderItem.BorderRadius = 10;
            customizableEdges9.BottomRight = false;
            customizableEdges9.TopLeft = false;
            ClearOrderItem.CustomizableEdges = customizableEdges9;
            ClearOrderItem.DisabledState.BorderColor = Color.DarkGray;
            ClearOrderItem.DisabledState.CustomBorderColor = Color.DarkGray;
            ClearOrderItem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ClearOrderItem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ClearOrderItem.FillColor = Color.Transparent;
            ClearOrderItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearOrderItem.ForeColor = Color.Black;
            ClearOrderItem.Image = (Image)resources.GetObject("ClearOrderItem.Image");
            ClearOrderItem.ImageSize = new Size(12, 12);
            ClearOrderItem.Location = new Point(119, 0);
            ClearOrderItem.Name = "ClearOrderItem";
            ClearOrderItem.ShadowDecoration.CustomizableEdges = customizableEdges10;
            ClearOrderItem.Size = new Size(30, 22);
            ClearOrderItem.TabIndex = 2;
            ClearOrderItem.Click += ClearOrderItem_Click;
            // 
            // OrderPrice
            // 
            OrderPrice.AutoSize = true;
            OrderPrice.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OrderPrice.Location = new Point(6, 46);
            OrderPrice.Name = "OrderPrice";
            OrderPrice.Size = new Size(50, 21);
            OrderPrice.TabIndex = 1;
            OrderPrice.Text = "$7.99";
            // 
            // OrderName
            // 
            OrderName.AutoSize = true;
            OrderName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OrderName.Location = new Point(6, 18);
            OrderName.Name = "OrderName";
            OrderName.Size = new Size(51, 21);
            OrderName.TabIndex = 0;
            OrderName.Text = "Beefs";
            // 
            // UC_OrderItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            Controls.Add(OrderImage);
            Margin = new Padding(15, 3, 3, 3);
            Name = "UC_OrderItem";
            Size = new Size(285, 110);
            ((System.ComponentModel.ISupportInitialize)OrderImage).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox OrderImage;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label OrderPrice;
        private Label OrderName;
        private Guna.UI2.WinForms.Guna2TextBox Quantity;
        private Guna.UI2.WinForms.Guna2Button MinusOrder;
        private Guna.UI2.WinForms.Guna2Button ClearOrderItem;
        private Guna.UI2.WinForms.Guna2Button IncreaseOrder;
    }
}
