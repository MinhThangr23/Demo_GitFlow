namespace Menu_Management
{
    partial class LoginForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            LoginButton = new Guna.UI2.WinForms.Guna2Button();
            label3 = new Label();
            label2 = new Label();
            Password = new Guna.UI2.WinForms.Guna2TextBox();
            Username = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // LoginButton
            // 
            LoginButton.BorderRadius = 10;
            LoginButton.CustomizableEdges = customizableEdges5;
            LoginButton.DisabledState.BorderColor = Color.DarkGray;
            LoginButton.DisabledState.CustomBorderColor = Color.DarkGray;
            LoginButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            LoginButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            LoginButton.FillColor = Color.FromArgb(255, 107, 0);
            LoginButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.White;
            LoginButton.Location = new Point(597, 375);
            LoginButton.Name = "LoginButton";
            LoginButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            LoginButton.Size = new Size(282, 49);
            LoginButton.TabIndex = 3;
            LoginButton.Text = "Login";
            LoginButton.Click += LoginButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(493, 273);
            label3.Name = "label3";
            label3.Size = new Size(76, 21);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(493, 186);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // Password
            // 
            Password.BackColor = Color.Transparent;
            Password.BorderRadius = 10;
            Password.CustomizableEdges = customizableEdges7;
            Password.DefaultText = "";
            Password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Password.FillColor = Color.WhiteSmoke;
            Password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Password.Font = new Font("Segoe UI", 9F);
            Password.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Password.Location = new Point(493, 306);
            Password.Margin = new Padding(3, 4, 3, 4);
            Password.Name = "Password";
            Password.PlaceholderText = "Your password";
            Password.SelectedText = "";
            Password.ShadowDecoration.CustomizableEdges = customizableEdges8;
            Password.Size = new Size(486, 45);
            Password.TabIndex = 1;
            Password.UseSystemPasswordChar = true;
            // 
            // Username
            // 
            Username.BackColor = Color.Transparent;
            Username.BorderRadius = 10;
            Username.CustomizableEdges = customizableEdges9;
            Username.DefaultText = "";
            Username.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Username.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Username.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Username.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Username.FillColor = Color.WhiteSmoke;
            Username.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Username.Font = new Font("Segoe UI", 9F);
            Username.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Username.Location = new Point(493, 219);
            Username.Margin = new Padding(3, 4, 3, 4);
            Username.Name = "Username";
            Username.PlaceholderText = "Enter your username";
            Username.SelectedText = "";
            Username.ShadowDecoration.CustomizableEdges = customizableEdges10;
            Username.Size = new Size(486, 45);
            Username.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(705, 128);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 4;
            label1.Text = "Login";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.Dock = DockStyle.Left;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(0, 0);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(392, 600);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 22;
            guna2PictureBox1.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.CustomizableEdges = customizableEdges1;
            guna2PictureBox2.Image = (Image)resources.GetObject("guna2PictureBox2.Image");
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.Location = new Point(659, 0);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox2.Size = new Size(158, 125);
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox2.TabIndex = 23;
            guna2PictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 600);
            Controls.Add(guna2PictureBox2);
            Controls.Add(guna2PictureBox1);
            Controls.Add(LoginButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button LoginButton;
        private Label label3;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox Password;
        private Guna.UI2.WinForms.Guna2TextBox Username;
        private Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}