namespace Menu_Management
{
    partial class AdminCheckoutFrm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminCheckoutFrm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            StartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            EndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ReportItemWise = new Guna.UI2.WinForms.Guna2Button();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // StartDate
            // 
            StartDate.BorderRadius = 20;
            StartDate.Checked = true;
            StartDate.CustomizableEdges = customizableEdges1;
            StartDate.FillColor = Color.FromArgb(255, 107, 0);
            StartDate.Font = new Font("Segoe UI", 9F);
            StartDate.Format = DateTimePickerFormat.Long;
            StartDate.Location = new Point(118, 507);
            StartDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            StartDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            StartDate.Name = "StartDate";
            StartDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            StartDate.Size = new Size(220, 45);
            StartDate.TabIndex = 2;
            StartDate.Value = new DateTime(2025, 7, 20, 21, 10, 13, 286);
            // 
            // EndDate
            // 
            EndDate.BorderRadius = 20;
            EndDate.Checked = true;
            EndDate.CustomizableEdges = customizableEdges3;
            EndDate.FillColor = Color.FromArgb(255, 107, 0);
            EndDate.Font = new Font("Segoe UI", 9F);
            EndDate.Format = DateTimePickerFormat.Long;
            EndDate.Location = new Point(632, 507);
            EndDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            EndDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            EndDate.Name = "EndDate";
            EndDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            EndDate.Size = new Size(220, 45);
            EndDate.TabIndex = 3;
            EndDate.Value = new DateTime(2025, 7, 20, 21, 10, 13, 286);
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(118, 474);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(90, 27);
            guna2HtmlLabel1.TabIndex = 4;
            guna2HtmlLabel1.Text = "Start Date";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(632, 474);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(81, 27);
            guna2HtmlLabel2.TabIndex = 5;
            guna2HtmlLabel2.Text = "End Date";
            // 
            // ReportItemWise
            // 
            ReportItemWise.BorderRadius = 20;
            ReportItemWise.CustomizableEdges = customizableEdges5;
            ReportItemWise.FillColor = Color.FromArgb(28, 40, 51);
            ReportItemWise.Font = new Font("Segoe UI", 9F);
            ReportItemWise.ForeColor = Color.White;
            ReportItemWise.Location = new Point(672, 619);
            ReportItemWise.Name = "ReportItemWise";
            ReportItemWise.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ReportItemWise.Size = new Size(180, 45);
            ReportItemWise.TabIndex = 0;
            ReportItemWise.Text = "Report";
            ReportItemWise.Click += ReportItemWise_Click;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges7;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(118, 66);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2PictureBox1.Size = new Size(734, 368);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 6;
            guna2PictureBox1.TabStop = false;
            // 
            // AdminCheckoutFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 775);
            Controls.Add(guna2PictureBox1);
            Controls.Add(ReportItemWise);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(EndDate);
            Controls.Add(StartDate);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminCheckoutFrm";
            Text = "AdminCheckoutFrm";
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2DateTimePicker StartDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker EndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button ReportItemWise;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}