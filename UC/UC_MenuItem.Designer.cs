namespace Menu_Management
{
    partial class UC_MenuItem
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MenuItem));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            DishPrice = new Label();
            DishName = new Label();
            DishImage = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DishImage).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.White;
            guna2Panel1.BorderRadius = 20;
            guna2Panel1.Controls.Add(DishPrice);
            guna2Panel1.Controls.Add(DishName);
            guna2Panel1.Controls.Add(DishImage);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.FromArgb(234, 234, 234);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(150, 184);
            guna2Panel1.TabIndex = 0;
            // 
            // DishPrice
            // 
            DishPrice.BackColor = Color.FromArgb(234, 234, 234);
            DishPrice.Dock = DockStyle.Top;
            DishPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DishPrice.ForeColor = Color.FromArgb(255, 107, 0);
            DishPrice.Location = new Point(0, 128);
            DishPrice.Name = "DishPrice";
            DishPrice.Size = new Size(150, 35);
            DishPrice.TabIndex = 2;
            DishPrice.Text = "$5.99";
            DishPrice.TextAlign = ContentAlignment.MiddleCenter;
            DishPrice.Click += DishImage_Click;
            // 
            // DishName
            // 
            DishName.BackColor = Color.FromArgb(234, 234, 234);
            DishName.Dock = DockStyle.Top;
            DishName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DishName.ForeColor = Color.FromArgb(28, 40, 51);
            DishName.Location = new Point(0, 86);
            DishName.Name = "DishName";
            DishName.Size = new Size(150, 42);
            DishName.TabIndex = 1;
            DishName.Text = "Pancake";
            DishName.TextAlign = ContentAlignment.MiddleCenter;
            DishName.Click += DishImage_Click;
            // 
            // DishImage
            // 
            DishImage.BackColor = Color.Transparent;
            DishImage.BorderRadius = 20;
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            DishImage.CustomizableEdges = customizableEdges1;
            DishImage.Dock = DockStyle.Top;
            DishImage.FillColor = Color.Transparent;
            DishImage.Image = (Image)resources.GetObject("DishImage.Image");
            DishImage.ImageRotate = 0F;
            DishImage.Location = new Point(0, 0);
            DishImage.Name = "DishImage";
            DishImage.ShadowDecoration.CustomizableEdges = customizableEdges2;
            DishImage.Size = new Size(150, 86);
            DishImage.SizeMode = PictureBoxSizeMode.StretchImage;
            DishImage.TabIndex = 0;
            DishImage.TabStop = false;
            DishImage.Click += DishImage_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            // 
            // UC_MenuItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            Cursor = Cursors.Hand;
            Margin = new Padding(4, 3, 4, 3);
            Name = "UC_MenuItem";
            Size = new Size(150, 184);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DishImage).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox DishImage;
        private Label DishName;
        private Label DishPrice;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
