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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Menu_Management
{
    public partial class DeleteEmployeeButton : Form
    {
        public DeleteEmployeeButton()
        {
            InitializeComponent();
            DeleteEmployee.Enabled = false;
            DatabaseHelper.LoadRoles(RoleComboBox);
            DatabaseHelper.ShowEmployee(EmployeeViewer);

        }
        private bool isValidInput()
        {
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text) || string.IsNullOrWhiteSpace(Fullname.Text) || GenderComboBox.SelectedItem == null || RoleComboBox.SelectedItem == null)
            {
                return false;
            }
            return true;
        }
        private bool isExist(string username)
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string query = "SELECT COUNT(*) FROM Accounts WHERE UserName = @username";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", username);
                int count = (int)sqlcmd.ExecuteScalar();
                if (count > 0)
                {
                    return true; // Tài khoản hoặc tên đầy đủ đã tồn tại
                }
                else
                {
                    return false; // Tài khoản chưa tồn tại
                }
            }
        }
        private void AddEmployee_Click(object sender, EventArgs e)
        {
            if (!isValidInput())
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            string username = Username.Text.Trim();
            string fullname = Fullname.Text.Trim();
            if (isExist(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string query = "INSERT INTO Accounts (UserName, Password, FullName, Gender, RoleID) VALUES\r\n(@username, @password, @FullName, @Gender, (SELECT RoleID FROM Roles WHERE RoleName= @RoleID))";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@FullName", Fullname.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem.ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@RoleID", RoleComboBox.SelectedItem.ToString().Trim());
                int rows = sqlcmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    MessageBox.Show("Fail to add account");
                }
                else
                {
                    MessageBox.Show("Account added successfully");
                    DatabaseHelper.ShowEmployee(EmployeeViewer);
                    Username.Clear();
                    Password.Clear();
                    Fullname.Clear();
                }
            }
        }
        private void DelelteEmployee_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to delete this account?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
            {
                return;
            }    
            DataGridViewRow selectedRow = EmployeeViewer.SelectedRows[0];
            if (selectedRow.Cells[0].Value == null)
            {
                MessageBox.Show("Please select an account to delete.");
                return;
            }
            string username = selectedRow.Cells["UserName"].Value.ToString();
            if(Login.isOnline(username))
            {
                MessageBox.Show("This account is currently online!!");
                return;
            }
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string query = "DELETE FROM Accounts WHERE UserName = @username";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", username);
                int rows = sqlcmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    MessageBox.Show("Fail to delete account");
                    return;
                }
                else
                {
                    MessageBox.Show("Account deleted successfully");
                    DatabaseHelper.ShowEmployee(EmployeeViewer);
                    return;
                }
            }
        }

        private void EmployeeViewer_SelectionChanged(object sender, EventArgs e)
        {
            CurrentEmployeeFlowPanel.Controls.Clear();
            UC_UserItem user;
            if (EmployeeViewer.SelectedRows.Count == 0)
            {
                DeleteEmployee.Enabled = false;
                user = new UC_UserItem();
            }
            else
            {
                DeleteEmployee.Enabled = true;
                DataGridViewRow selectedrow = EmployeeViewer.SelectedRows[0];
                string username = selectedrow.Cells["UserName"].Value.ToString();
                string fullname = selectedrow.Cells["FullName"].Value.ToString();
                string gender = selectedrow.Cells["Gender"].Value.ToString();
                string role = selectedrow.Cells["RoleName"].Value.ToString();
                user = new UC_UserItem(username, fullname, gender, role);
            }
            CurrentEmployeeFlowPanel.Controls.Add(user);


        }

        private void DeleteAllEmployee_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("This gonna delete all of the employees'accounts exclude admins\nThink twice before decide",
            "Confirm All Deletion",
            MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
            {
                return;
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    string query = "DELETE FROM Accounts WHERE RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Employee') AND Status = 'Offline'";
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    int rows = sqlcmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        MessageBox.Show("Fail to delete all");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Accounts deleted successfully");
                        DatabaseHelper.ShowEmployee(EmployeeViewer);
                        return;
                    }
                }
            }
        }
    }
}
