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
    public partial class ChangePassForm : Form
    {
        public ChangePassForm()
        {
            InitializeComponent();
            CurrentPasswordtxt.KeyDown += Input_KeyDown;
            NewPasswordtxt.KeyDown += Input_KeyDown;
            ConfirmNewPasswordtxt.KeyDown += Input_KeyDown;
        }
        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangePwdButton.PerformClick(); // Gọi hàm đăng nhập
            }
        }
        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isValidInput()
        {
            if (string.IsNullOrWhiteSpace(CurrentPasswordtxt.Text) ||
                string.IsNullOrWhiteSpace(NewPasswordtxt.Text) ||
                string.IsNullOrWhiteSpace(ConfirmNewPasswordtxt.Text))
            {
                return false;
            }
            return true;
        }
        private bool isCorrectPassword(string password)
        {
            return CurrentPasswordtxt.Text == Login.Password;
        }
        private void ChangePwdButton_Click(object sender, EventArgs e)
        {
            if (!isValidInput())
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isCorrectPassword(CurrentPasswordtxt.Text))
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsMatchingNewPassword())
            {
                MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UpdatePasswordInDatabase())
            {
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.Password = NewPasswordtxt.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Kiểm tra mật khẩu mới khớp nhau
        private bool IsMatchingNewPassword()
        {
            return NewPasswordtxt.Text == ConfirmNewPasswordtxt.Text;
        }
        //Cập nhật mật khẩu vào SQL
        private bool UpdatePasswordInDatabase()
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string query = "UPDATE Accounts SET Password = @NewPassword WHERE Username = @Username";

                using (SqlCommand sqlcmd = new SqlCommand(query, sqlcon))
                {
                    sqlcmd.Parameters.AddWithValue("@NewPassword", NewPasswordtxt.Text);
                    sqlcmd.Parameters.AddWithValue("@Username", Login.User);

                    return sqlcmd.ExecuteNonQuery() == 1;
                }
            }
        }


    }
}
