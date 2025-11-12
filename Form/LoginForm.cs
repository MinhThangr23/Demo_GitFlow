using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Username.KeyDown += Input_KeyDown;
            Password.KeyDown += Input_KeyDown;
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton.PerformClick(); // Gọi hàm đăng nhập
            }
        }
        private bool isValidInput()
        {
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                return false;
            }
            return true;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!isValidInput())
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            if (CheckLogin(Username.Text, Password.Text))
            {
                OpenMainForm(Login.Fullname);
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }

        // ✳️ Hàm 1: kiểm tra đăng nhập trong CSDL
        private bool CheckLogin(string username, string password)
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts WHERE UserName = @username AND Password = @password", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            LoadUserData(reader);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // ✳️ Hàm 2: nạp thông tin người dùng từ kết quả truy vấn
        private void LoadUserData(SqlDataReader reader)
        {
            Login.User = reader["UserName"].ToString();
            Login.Password = reader["Password"].ToString();
            Login.Fullname = reader["FullName"].ToString();
            int roleID = Convert.ToInt32(reader["RoleID"]);
            Login.Role = Login.GetRole(roleID);
            Login.SetAccountStatus(Login.User, "Online");
        }

        // ✳️ Hàm 3: mở form chính sau khi đăng nhập thành công
        private void OpenMainForm(string fullname)
        {
            this.Hide();
            MainForm mainForm = new MainForm(fullname);
            mainForm.Show();
        }


    }
}
