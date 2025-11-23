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
        #region Kiểm tra đầu vào - Guard Clause + Throw
        private void ValidateInputOrThrow()
        {
            if (string.IsNullOrWhiteSpace(Username.Text))
                throw new ArgumentException("Vui lòng nhập tên đăng nhập.");

            if (string.IsNullOrWhiteSpace(Password.Text))
                throw new ArgumentException("Vui lòng nhập mật khẩu.");

            if (string.IsNullOrWhiteSpace(Fullname.Text))
                throw new ArgumentException("Vui lòng nhập họ tên.");

            if (GenderComboBox.SelectedItem == null)
                throw new ArgumentException("Vui lòng chọn giới tính.");

            if (RoleComboBox.SelectedItem == null)
                throw new ArgumentException("Vui lòng chọn vai trò.");
        }
        #endregion
        #region Kiểm tra username tồn tại
        private bool DoesUsernameExist(string username)
        {
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();
                using var cmd = new SqlCommand("SELECT COUNT(*) FROM Accounts WHERE UserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);
                return (int)cmd.ExecuteScalar() > 0; // Trả về true nếu username tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tên đăng nhập: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Giả định username không tồn tại trong trường hợp lỗi
            }
        }
        #endregion
        #region Thêm nhân viên
        private void AddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputOrThrow(); // Kiểm tra đầu vào
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            string username = Username.Text.Trim();

            if (DoesUsernameExist(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();
                const string sql = @"
                    INSERT INTO Accounts (UserName, Password, FullName, Gender, RoleID)
                    VALUES (@username, @password, @FullName, @Gender,
                            (SELECT RoleID FROM Roles WHERE RoleName = @RoleName))";
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                cmd.Parameters.AddWithValue("@FullName", Fullname.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem.ToString().Trim());
                cmd.Parameters.AddWithValue("@RoleName", RoleComboBox.SelectedItem.ToString().Trim());
                int rows = cmd.ExecuteNonQuery(); // Thực thi lệnh và lấy số hàng bị ảnh hưởng
                if (rows > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể thêm tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Trùng khóa chính
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại (lỗi cơ sở dữ liệu).", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu khi thêm tài khoản: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            finally
            {
                DatabaseHelper.ShowEmployee(EmployeeViewer);
                ClearInputFields();
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