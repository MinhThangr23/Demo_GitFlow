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
        private bool IsValidInput()
        {
            return !string.IsNullOrWhiteSpace(Username.Text) &&
                   !string.IsNullOrWhiteSpace(Password.Text) &&
                   !string.IsNullOrWhiteSpace(Fullname.Text) &&
                   GenderComboBox.SelectedItem != null &&
                   RoleComboBox.SelectedItem != null;
        }
        private bool DoesUsernameExist(string username)
        {
            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();
                var query = "SELECT COUNT(*) FROM Accounts WHERE UserName = @username";
                using var sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", username);
                return (int)sqlcmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra username: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void AddEmployee_Click(object sender, EventArgs e)
        {
            if (!IsValidInput())
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            var username = Username.Text.Trim();
            if (DoesUsernameExist(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }
            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();
                var query = @"INSERT INTO Accounts (UserName, Password, FullName, Gender, RoleID)
                              VALUES (@username, @password, @FullName, @Gender,
                              (SELECT RoleID FROM Roles WHERE RoleName = @RoleName))";
                using var sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", username);
                sqlcmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@FullName", Fullname.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem.ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@RoleName", RoleComboBox.SelectedItem.ToString().Trim());
                if (sqlcmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Account added successfully");
                    DatabaseHelper.ShowEmployee(EmployeeViewer);
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Fail to add account");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm tài khoản: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelelteEmployee_Click(object sender, EventArgs e)
        {
            if (EmployeeViewer.SelectedRows.Count == 0 || EmployeeViewer.SelectedRows[0].Cells["UserName"].Value == null)
            {
                MessageBox.Show("Please select an account to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure to delete this account?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.No) return;

            var username = EmployeeViewer.SelectedRows[0].Cells["UserName"].Value.ToString();
            if (Login.isOnline(username))
            {
                MessageBox.Show("This account is currently online!!");
                return;
            }
            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();
                var query = "DELETE FROM Accounts WHERE UserName = @username";
                using var sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", username);
                if (sqlcmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Account deleted successfully");
                    DatabaseHelper.ShowEmployee(EmployeeViewer);
                }
                else
                {
                    MessageBox.Show("Fail to delete account");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa tài khoản: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var selectedRow = EmployeeViewer.SelectedRows[0];
                user = new UC_UserItem(
                    selectedRow.Cells["UserName"].Value?.ToString() ?? string.Empty,
                    selectedRow.Cells["FullName"].Value?.ToString() ?? string.Empty,
                    selectedRow.Cells["Gender"].Value?.ToString() ?? string.Empty,
                    selectedRow.Cells["RoleName"].Value?.ToString() ?? string.Empty
                );
            }
            CurrentEmployeeFlowPanel.Controls.Add(user);
        }

        private void DeleteAllEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "This gonna delete all of the employees'accounts exclude admins\nThink twice before decide",
                "Confirm All Deletion",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();
                var query = "DELETE FROM Accounts WHERE RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Employee') AND Status = 'Offline'";
                using var sqlcmd = new SqlCommand(query, sqlcon);

                int rowsAffected = sqlcmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Accounts deleted successfully");
                    DatabaseHelper.ShowEmployee(EmployeeViewer);
                }
                else
                {
                    MessageBox.Show("Fail to delete all or no accounts to delete");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa tất cả tài khoản: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            Username.Clear();
            Password.Clear();
            Fullname.Clear();
            GenderComboBox.SelectedIndex = -1;
            RoleComboBox.SelectedIndex = -1;
        }
    }
}