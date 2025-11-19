using Guna.UI2.WinForms;

namespace Menu_Management
{
    partial class MainForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2PictureBox1 = new Guna2PictureBox();
            SidePanel = new Guna2Panel();
            CurrentUser = new Label();
            guna2PictureBox2 = new Guna2PictureBox();
            Logout = new Guna2Button();
            Exit = new Guna2Button();
            Settings = new Guna2Button();
            Reports = new Guna2Button();
            btnBill = new Guna2Button();
            Home = new Guna2Button();
            MainPanel = new Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.Image = Properties.Resources.delicousrestaurantlogo;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(38, 12);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(211, 127);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 0;
            guna2PictureBox1.TabStop = false;
            // 
            // SidePanel
            // 
            SidePanel.BackColor = Color.WhiteSmoke;
            SidePanel.BorderThickness = 1;
            SidePanel.Controls.Add(CurrentUser);
            SidePanel.Controls.Add(guna2PictureBox2);
            SidePanel.Controls.Add(Logout);
            SidePanel.Controls.Add(Exit);
            SidePanel.Controls.Add(Settings);
            SidePanel.Controls.Add(Reports);
            SidePanel.Controls.Add(btnBill);
            SidePanel.Controls.Add(Home);
            SidePanel.Controls.Add(guna2PictureBox1);
            SidePanel.CustomizableEdges = customizableEdges17;
            SidePanel.Dock = DockStyle.Left;
            SidePanel.Location = new Point(0, 0);
            SidePanel.Name = "SidePanel";
            SidePanel.ShadowDecoration.CustomizableEdges = customizableEdges18;
            SidePanel.Size = new Size(276, 775);
            SidePanel.TabIndex = 0;
            // 
            // CurrentUser
            // 
            CurrentUser.AutoSize = true;
            CurrentUser.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CurrentUser.Location = new Point(106, 678);
            CurrentUser.Name = "CurrentUser";
            CurrentUser.Size = new Size(69, 17);
            CurrentUser.TabIndex = 3;
            CurrentUser.Text = "Username";
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.CustomizableEdges = customizableEdges3;
            guna2PictureBox2.Image = (Image)resources.GetObject("guna2PictureBox2.Image");
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.Location = new Point(47, 659);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox2.Size = new Size(53, 55);
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox2.TabIndex = 2;
            guna2PictureBox2.TabStop = false;
            // 
            // Logout
            // 
            Logout.BorderColor = Color.FromArgb(255, 107, 0);
            Logout.BorderRadius = 20;
            Logout.BorderThickness = 2;
            Logout.CheckedState.BorderColor = Color.FromArgb(255, 107, 0);
            Logout.CheckedState.FillColor = Color.WhiteSmoke;
            Logout.CheckedState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Logout.CheckedState.ForeColor = Color.FromArgb(255, 107, 0);
            Logout.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            Logout.CustomizableEdges = customizableEdges5;
            Logout.DisabledState.BorderColor = Color.DarkGray;
            Logout.DisabledState.CustomBorderColor = Color.DarkGray;
            Logout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Logout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Logout.FillColor = Color.WhiteSmoke;
            Logout.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Logout.ForeColor = Color.FromArgb(255, 107, 0);
            Logout.HoverState.BorderColor = Color.FromArgb(255, 162, 80);
            Logout.HoverState.FillColor = Color.WhiteSmoke;
            Logout.HoverState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Logout.HoverState.ForeColor = Color.FromArgb(255, 162, 80);
            Logout.HoverState.Image = (Image)resources.GetObject("resource.Image1");
            Logout.Image = (Image)resources.GetObject("Logout.Image");
            Logout.ImageAlign = HorizontalAlignment.Left;
            Logout.ImageOffset = new Point(50, 0);
            Logout.ImageSize = new Size(25, 25);
            Logout.Location = new Point(38, 718);
            Logout.Name = "Logout";
            Logout.PressedColor = Color.LightGray;
            Logout.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Logout.Size = new Size(211, 45);
            Logout.TabIndex = 1;
            Logout.Text = "Log Out";
            Logout.TextOffset = new Point(20, 0);
            Logout.Click += Logout_Click;
            // 
            // Exit
            // 
            Exit.BorderColor = Color.Empty;
            Exit.BorderRadius = 20;
            Exit.BorderThickness = 2;
            Exit.CheckedState.BorderColor = Color.FromArgb(255, 107, 0);
            Exit.CheckedState.FillColor = Color.WhiteSmoke;
            Exit.CheckedState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Exit.CheckedState.ForeColor = Color.FromArgb(255, 107, 0);
            Exit.CheckedState.Image = (Image)resources.GetObject("resource.Image2");
            Exit.CustomizableEdges = customizableEdges7;
            Exit.DisabledState.BorderColor = Color.DarkGray;
            Exit.DisabledState.CustomBorderColor = Color.DarkGray;
            Exit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Exit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Exit.FillColor = Color.WhiteSmoke;
            Exit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Exit.ForeColor = Color.FromArgb(28, 40, 51);
            Exit.HoverState.BorderColor = Color.FromArgb(255, 162, 80);
            Exit.HoverState.FillColor = Color.WhiteSmoke;
            Exit.HoverState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Exit.HoverState.ForeColor = Color.FromArgb(255, 162, 80);
            Exit.HoverState.Image = (Image)resources.GetObject("resource.Image3");
            Exit.Image = (Image)resources.GetObject("Exit.Image");
            Exit.ImageAlign = HorizontalAlignment.Left;
            Exit.ImageOffset = new Point(15, 0);
            Exit.ImageSize = new Size(25, 25);
            Exit.Location = new Point(38, 375);
            Exit.Name = "Exit";
            Exit.PressedColor = Color.LightGray;
            Exit.ShadowDecoration.CustomizableEdges = customizableEdges8;
            Exit.Size = new Size(211, 45);
            Exit.TabIndex = 1;
            Exit.Text = "Exit";
            Exit.TextAlign = HorizontalAlignment.Left;
            Exit.TextOffset = new Point(20, 0);
            Exit.Click += Exit_Click;
            // 
            // Settings
            // 
            Settings.BorderColor = Color.Empty;
            Settings.BorderRadius = 20;
            Settings.BorderThickness = 2;
            Settings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            Settings.CheckedState.BorderColor = Color.FromArgb(255, 107, 0);
            Settings.CheckedState.FillColor = Color.WhiteSmoke;
            Settings.CheckedState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Settings.CheckedState.ForeColor = Color.FromArgb(255, 107, 0);
            Settings.CheckedState.Image = (Image)resources.GetObject("resource.Image4");
            Settings.CustomizableEdges = customizableEdges9;
            Settings.DisabledState.BorderColor = Color.DarkGray;
            Settings.DisabledState.CustomBorderColor = Color.DarkGray;
            Settings.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Settings.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Settings.FillColor = Color.WhiteSmoke;
            Settings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Settings.ForeColor = Color.FromArgb(28, 40, 51);
            Settings.HoverState.BorderColor = Color.FromArgb(255, 162, 80);
            Settings.HoverState.FillColor = Color.WhiteSmoke;
            Settings.HoverState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Settings.HoverState.ForeColor = Color.FromArgb(255, 162, 80);
            Settings.HoverState.Image = (Image)resources.GetObject("resource.Image5");
            Settings.Image = (Image)resources.GetObject("Settings.Image");
            Settings.ImageAlign = HorizontalAlignment.Left;
            Settings.ImageOffset = new Point(15, 0);
            Settings.ImageSize = new Size(25, 25);
            Settings.Location = new Point(38, 324);
            Settings.Name = "Settings";
            Settings.PressedColor = Color.LightGray;
            Settings.ShadowDecoration.CustomizableEdges = customizableEdges10;
            Settings.Size = new Size(211, 45);
            Settings.TabIndex = 1;
            Settings.Text = "Settings";
            Settings.TextAlign = HorizontalAlignment.Left;
            Settings.TextOffset = new Point(20, 0);
            Settings.Click += Settings_Click;
            // 
            // Reports
            // 
            Reports.BorderColor = Color.Empty;
            Reports.BorderRadius = 20;
            Reports.BorderThickness = 2;
            Reports.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            Reports.CheckedState.BorderColor = Color.FromArgb(255, 107, 0);
            Reports.CheckedState.FillColor = Color.WhiteSmoke;
            Reports.CheckedState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Reports.CheckedState.ForeColor = Color.FromArgb(255, 107, 0);
            Reports.CheckedState.Image = (Image)resources.GetObject("resource.Image6");
            Reports.CustomizableEdges = customizableEdges11;
            Reports.DisabledState.BorderColor = Color.DarkGray;
            Reports.DisabledState.CustomBorderColor = Color.DarkGray;
            Reports.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Reports.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Reports.FillColor = Color.WhiteSmoke;
            Reports.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Reports.ForeColor = Color.FromArgb(28, 40, 51);
            Reports.HoverState.BorderColor = Color.FromArgb(255, 162, 80);
            Reports.HoverState.FillColor = Color.WhiteSmoke;
            Reports.HoverState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Reports.HoverState.ForeColor = Color.FromArgb(255, 162, 80);
            Reports.HoverState.Image = (Image)resources.GetObject("resource.Image7");
            Reports.Image = (Image)resources.GetObject("Reports.Image");
            Reports.ImageAlign = HorizontalAlignment.Left;
            Reports.ImageOffset = new Point(15, 0);
            Reports.ImageSize = new Size(25, 25);
            Reports.Location = new Point(38, 273);
            Reports.Name = "Reports";
            Reports.PressedColor = Color.LightGray;
            Reports.ShadowDecoration.CustomizableEdges = customizableEdges12;
            Reports.Size = new Size(211, 45);
            Reports.TabIndex = 1;
            Reports.Text = "Reports";
            Reports.TextAlign = HorizontalAlignment.Left;
            Reports.TextOffset = new Point(20, 0);
            Reports.Click += Reports_Click;
            // 
            // btnBill
            // 
            btnBill.BorderColor = Color.Empty;
            btnBill.BorderRadius = 20;
            btnBill.BorderThickness = 2;
            btnBill.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnBill.CheckedState.BorderColor = Color.FromArgb(255, 107, 0);
            btnBill.CheckedState.FillColor = Color.WhiteSmoke;
            btnBill.CheckedState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnBill.CheckedState.ForeColor = Color.FromArgb(255, 107, 0);
            btnBill.CheckedState.Image = (Image)resources.GetObject("resource.Image8");
            btnBill.CustomizableEdges = customizableEdges13;
            btnBill.DisabledState.BorderColor = Color.DarkGray;
            btnBill.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBill.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBill.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBill.FillColor = Color.WhiteSmoke;
            btnBill.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBill.ForeColor = Color.FromArgb(28, 40, 51);
            btnBill.HoverState.BorderColor = Color.FromArgb(255, 162, 80);
            btnBill.HoverState.FillColor = Color.WhiteSmoke;
            btnBill.HoverState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnBill.HoverState.ForeColor = Color.FromArgb(255, 162, 80);
            btnBill.HoverState.Image = (Image)resources.GetObject("resource.Image9");
            btnBill.Image = (Image)resources.GetObject("btnBill.Image");
            btnBill.ImageAlign = HorizontalAlignment.Left;
            btnBill.ImageOffset = new Point(15, 0);
            btnBill.ImageSize = new Size(25, 25);
            btnBill.Location = new Point(38, 222);
            btnBill.Name = "btnBill";
            btnBill.PressedColor = Color.LightGray;
            btnBill.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnBill.Size = new Size(211, 45);
            btnBill.TabIndex = 1;
            btnBill.Text = "Bill";
            btnBill.TextAlign = HorizontalAlignment.Left;
            btnBill.TextOffset = new Point(20, 0);
            btnBill.Click += btnBill_Click;
            // 
            // Home
            // 
            Home.BorderColor = Color.Empty;
            Home.BorderRadius = 20;
            Home.BorderThickness = 2;
            Home.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            Home.Checked = true;
            Home.CheckedState.BorderColor = Color.FromArgb(255, 107, 0);
            Home.CheckedState.FillColor = Color.WhiteSmoke;
            Home.CheckedState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Home.CheckedState.ForeColor = Color.FromArgb(255, 107, 0);
            Home.CheckedState.Image = (Image)resources.GetObject("resource.Image10");
            Home.CustomizableEdges = customizableEdges15;
            Home.DisabledState.BorderColor = Color.DarkGray;
            Home.DisabledState.CustomBorderColor = Color.DarkGray;
            Home.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Home.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Home.FillColor = Color.WhiteSmoke;
            Home.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Home.ForeColor = Color.FromArgb(28, 40, 51);
            Home.HoverState.BorderColor = Color.FromArgb(255, 162, 80);
            Home.HoverState.FillColor = Color.WhiteSmoke;
            Home.HoverState.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Home.HoverState.ForeColor = Color.FromArgb(255, 162, 80);
            Home.HoverState.Image = (Image)resources.GetObject("resource.Image11");
            Home.Image = (Image)resources.GetObject("Home.Image");
            Home.ImageAlign = HorizontalAlignment.Left;
            Home.ImageOffset = new Point(15, 0);
            Home.ImageSize = new Size(25, 25);
            Home.Location = new Point(38, 171);
            Home.Name = "Home";
            Home.PressedColor = Color.LightGray;
            Home.ShadowDecoration.CustomizableEdges = customizableEdges16;
            Home.Size = new Size(211, 45);
            Home.TabIndex = 1;
            Home.Text = "Home";
            Home.TextAlign = HorizontalAlignment.Left;
            Home.TextOffset = new Point(20, 0);
            Home.Click += Home_Click;
            // 
            // MainPanel
            // 
            MainPanel.CustomizableEdges = customizableEdges19;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(276, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges20;
            MainPanel.Size = new Size(974, 775);
            MainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1250, 775);
            Controls.Add(MainPanel);
            Controls.Add(SidePanel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            SidePanel.ResumeLayout(false);
            SidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button Home;
        private Guna.UI2.WinForms.Guna2Button Settings;
        private Guna.UI2.WinForms.Guna2Button Reports;
        private Guna.UI2.WinForms.Guna2Button Exit;
        private Label CurrentUser;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna2Panel SidePanel;
        private Guna2Button btnBill;
        private Guna2Button Logout;
    }
}