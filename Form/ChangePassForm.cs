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
            else if (isCorrectPassword(CurrentPasswordtxt.Text))
            {
                if (NewPasswordtxt.Text == ConfirmNewPasswordtxt.Text)
                {
                    using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        sqlcon.Open();
                        string q = "UPDATE Accounts SET Password = @NewPassword WHERE Username = @Username";
                        SqlCommand sqlcmd = new SqlCommand(q, sqlcon);
                        sqlcmd.Parameters.AddWithValue("@NewPassword", NewPasswordtxt.Text);
                        sqlcmd.Parameters.AddWithValue("@Username", Login.User);
                        int rowsAffected = sqlcmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login.Password = NewPasswordtxt.Text; // Update the static password in Login class
                            this.Close(); // Close the form after successful change
                        }
                        else
                        {
                            MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
