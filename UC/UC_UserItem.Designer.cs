namespace Menu_Management
{
    partial class UC_UserItem
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
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_UserItem));
            panel1 = new Panel();
            RoleLabel = new Label();
            GenderLabel = new Label();
            RoleValue = new Label();
            GenderValue = new Label();
            FullnameValue = new Label();
            FullnameLabel = new Label();
            panel2 = new Panel();
            UsernameValue = new Label();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(RoleLabel);
            panel1.Controls.Add(GenderLabel);
            panel1.Controls.Add(RoleValue);
            panel1.Controls.Add(GenderValue);
            panel1.Controls.Add(FullnameValue);
            panel1.Controls.Add(FullnameLabel);
            panel1.Controls.Add(panel2);
            guna2Transition1.SetDecoration(panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 300);
            panel1.TabIndex = 0;
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            guna2Transition1.SetDecoration(RoleLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            RoleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoleLabel.ForeColor = Color.FromArgb(255, 107, 0);
            RoleLabel.Location = new Point(27, 261);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(47, 21);
            RoleLabel.TabIndex = 1;
            RoleLabel.Text = "Role:";
            // 
            // GenderLabel
            // 
            GenderLabel.AutoSize = true;
            guna2Transition1.SetDecoration(GenderLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            GenderLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GenderLabel.ForeColor = Color.FromArgb(255, 107, 0);
            GenderLabel.Location = new Point(27, 217);
            GenderLabel.Name = "GenderLabel";
            GenderLabel.Size = new Size(69, 21);
            GenderLabel.TabIndex = 1;
            GenderLabel.Text = "Gender:";
            // 
            // RoleValue
            // 
            RoleValue.AutoSize = true;
            guna2Transition1.SetDecoration(RoleValue, Guna.UI2.AnimatorNS.DecorationType.None);
            RoleValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoleValue.ForeColor = Color.DarkRed;
            RoleValue.Location = new Point(134, 261);
            RoleValue.Name = "RoleValue";
            RoleValue.Size = new Size(77, 21);
            RoleValue.TabIndex = 1;
            RoleValue.Text = "Unknown";
            // 
            // GenderValue
            // 
            GenderValue.AutoSize = true;
            guna2Transition1.SetDecoration(GenderValue, Guna.UI2.AnimatorNS.DecorationType.None);
            GenderValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GenderValue.ForeColor = Color.Black;
            GenderValue.Location = new Point(134, 217);
            GenderValue.Name = "GenderValue";
            GenderValue.Size = new Size(77, 21);
            GenderValue.TabIndex = 1;
            GenderValue.Text = "Unknown";
            // 
            // FullnameValue
            // 
            FullnameValue.AutoSize = true;
            guna2Transition1.SetDecoration(FullnameValue, Guna.UI2.AnimatorNS.DecorationType.None);
            FullnameValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FullnameValue.ForeColor = Color.Black;
            FullnameValue.Location = new Point(134, 174);
            FullnameValue.Name = "FullnameValue";
            FullnameValue.Size = new Size(77, 21);
            FullnameValue.TabIndex = 1;
            FullnameValue.Text = "Unknown";
            // 
            // FullnameLabel
            // 
            FullnameLabel.AutoSize = true;
            guna2Transition1.SetDecoration(FullnameLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            FullnameLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FullnameLabel.ForeColor = Color.FromArgb(255, 107, 0);
            FullnameLabel.Location = new Point(27, 174);
            FullnameLabel.Name = "FullnameLabel";
            FullnameLabel.Size = new Size(86, 21);
            FullnameLabel.TabIndex = 1;
            FullnameLabel.Text = "Full Name:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(28, 40, 51);
            panel2.Controls.Add(UsernameValue);
            panel2.Controls.Add(guna2CirclePictureBox1);
            guna2Transition1.SetDecoration(panel2, Guna.UI2.AnimatorNS.DecorationType.None);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 151);
            panel2.TabIndex = 0;
            // 
            // UsernameValue
            // 
            UsernameValue.AutoSize = true;
            guna2Transition1.SetDecoration(UsernameValue, Guna.UI2.AnimatorNS.DecorationType.None);
            UsernameValue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameValue.ForeColor = Color.FromArgb(255, 107, 0);
            UsernameValue.Location = new Point(134, 114);
            UsernameValue.Name = "UsernameValue";
            UsernameValue.Size = new Size(86, 21);
            UsernameValue.TabIndex = 1;
            UsernameValue.Text = "UserName";
            // 
            // guna2CirclePictureBox1
            // 
            guna2Transition1.SetDecoration(guna2CirclePictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            guna2CirclePictureBox1.Image = (Image)resources.GetObject("guna2CirclePictureBox1.Image");
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(125, 16);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(100, 95);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2Transition1
            // 
            guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = (PointF)resources.GetObject("animation1.BlindCoeff");
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = (PointF)resources.GetObject("animation1.MosaicCoeff");
            animation1.MosaicShift = (PointF)resources.GetObject("animation1.MosaicShift");
            animation1.MosaicSize = 0;
            animation1.Padding = new Padding(0, 0, 0, 0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = (PointF)resources.GetObject("animation1.ScaleCoeff");
            animation1.SlideCoeff = (PointF)resources.GetObject("animation1.SlideCoeff");
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            guna2Transition1.DefaultAnimation = animation1;
            // 
            // UC_UserItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            Name = "UC_UserItem";
            Size = new Size(350, 300);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label RoleLabel;
        private Label GenderLabel;
        private Label FullnameLabel;
        private Panel panel2;
        private Label UsernameValue;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Label RoleValue;
        private Label GenderValue;
        private Label FullnameValue;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
    }
}
