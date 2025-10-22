namespace Menu_Management
{
    partial class AlertPrintForm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertPrintForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            NotPrintButton = new Guna.UI2.WinForms.Guna2Button();
            PrintButton = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(NotPrintButton);
            panel1.Controls.Add(PrintButton);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(guna2PictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 330);
            panel1.TabIndex = 0;
            // 
            // NotPrintButton
            // 
            NotPrintButton.BorderRadius = 20;
            NotPrintButton.CustomizableEdges = customizableEdges1;
            NotPrintButton.DisabledState.BorderColor = Color.DarkGray;
            NotPrintButton.DisabledState.CustomBorderColor = Color.DarkGray;
            NotPrintButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            NotPrintButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            NotPrintButton.FillColor = Color.FromArgb(255, 107, 0);
            NotPrintButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NotPrintButton.ForeColor = Color.White;
            NotPrintButton.Location = new Point(203, 250);
            NotPrintButton.Name = "NotPrintButton";
            NotPrintButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            NotPrintButton.Size = new Size(115, 50);
            NotPrintButton.TabIndex = 25;
            NotPrintButton.Text = "No";
            NotPrintButton.Click += NotPrintButton_Click;
            // 
            // PrintButton
            // 
            PrintButton.BorderRadius = 20;
            PrintButton.CustomizableEdges = customizableEdges3;
            PrintButton.DisabledState.BorderColor = Color.DarkGray;
            PrintButton.DisabledState.CustomBorderColor = Color.DarkGray;
            PrintButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            PrintButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            PrintButton.FillColor = Color.FromArgb(28, 40, 51);
            PrintButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrintButton.ForeColor = Color.White;
            PrintButton.Location = new Point(39, 250);
            PrintButton.Name = "PrintButton";
            PrintButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            PrintButton.Size = new Size(115, 50);
            PrintButton.TabIndex = 26;
            PrintButton.Text = "Yes";
            PrintButton.Click += PrintButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 177);
            label2.Name = "label2";
            label2.Size = new Size(304, 30);
            label2.TabIndex = 24;
            label2.Text = "Are you sure you want to print?";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2PictureBox1.CustomizableEdges = customizableEdges5;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(96, 26);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.Size = new Size(156, 130);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 23;
            guna2PictureBox1.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE;
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // AlertPrintForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 330);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlertPrintForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AlertPrintForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button NotPrintButton;
        private Guna.UI2.WinForms.Guna2Button PrintButton;
        private Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}