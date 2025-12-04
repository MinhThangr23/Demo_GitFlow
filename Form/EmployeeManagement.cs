using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Serilog;

namespace Menu_Management
{
    public partial class DeleteEmployeeButton : Form
    {
        public DeleteEmployeeButton()
        {
            InitializeComponent();
            DeleteEmployee.Enabled = false;

            Log.Information("Mở form quản lý nhân viên (DeleteEmployeeButton).");

            DatabaseHelper.LoadRoles(RoleComboBox);
            DatabaseHelper.ShowEmployee(EmployeeViewer);
        }

        //==========================================================
        // 1. Kiểm tra đầu vào
        //==========================================================
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

        //==========================================================
        // 2. Kiểm tra username tồn tại
        //==========================================================
        private bool DoesUsernameExist(string username)
        {
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();

                using var cmd = new SqlCommand("SELECT COUNT(*) FROM Accounts WHERE UserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                int count = (int)cmd.ExecuteScalar();

                Log.Debug("Kiểm tra username tồn tại: {Username} → {Exists}", username, count > 0);
                return count > 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi kiểm tra username tồn tại: {Username}", username);
                MessageBox.Show($"Lỗi khi kiểm tra tên đăng nhập: {ex.Message}",
                    "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //==========================================================
        // 3. Thêm nhân viên
        //==========================================================
        private void AddEmployee_Click(object sender, EventArgs e)
        {
            Log.Information("Người dùng nhấn nút Thêm nhân viên.");

            try
            {
                ValidateInputOrThrow();
            }
            catch (ArgumentException aex)
            {
                Log.Warning(aex, "Input không hợp lệ khi thêm nhân viên.");
                MessageBox.Show(aex.Message, "Thông tin không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = Username.Text.Trim();

            if (DoesUsernameExist(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Trùng lặp",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();

                const string sql = @"
                    INSERT INTO Accounts (UserName, Password, FullName, Gender, RoleID)
                    VALUES (@username, @password, @fullname, @gender,
                            (SELECT RoleID FROM Roles WHERE RoleName = @rolename))";

                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                cmd.Parameters.AddWithValue("@fullname", Fullname.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", GenderComboBox.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@rolename", RoleComboBox.SelectedItem.ToString());

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    Log.Information("Thêm nhân viên thành công: {Username}", username);
                    MessageBox.Show("Thêm tài khoản thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2601 || sqlEx.Number == 2627)
            {
                Log.Warning(sqlEx, "Trùng khóa chính khi thêm: {Username}", username);
                MessageBox.Show("Tên đăng nhập đã tồn tại (CSDL).", "Trùng lặp",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi thêm nhân viên: {Username}", username);
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Lỗi SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseHelper.ShowEmployee(EmployeeViewer);
                ClearInputFields();
            }
        }

        //==========================================================
        // 4. Xóa nhân viên
        //==========================================================
        private void DelelteEmployee_Click(object sender, EventArgs e)
        {
            Log.Information("Người dùng nhấn nút Xóa nhân viên.");

            if (EmployeeViewer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = EmployeeViewer.SelectedRows[0].Cells["UserName"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();

                using var cmd = new SqlCommand("DELETE FROM Accounts WHERE UserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi xóa tài khoản: {Username}", username);
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Lỗi SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseHelper.ShowEmployee(EmployeeViewer);
            }
        }

        //==========================================================
        // 5. Hiển thị thông tin khi chọn dòng
        //==========================================================
        private void EmployeeViewer_SelectionChanged(object sender, EventArgs e)
        {
            CurrentEmployeeFlowPanel.Controls.Clear();

            if (EmployeeViewer.SelectedRows.Count == 0)
            {
                DeleteEmployee.Enabled = false;
                CurrentEmployeeFlowPanel.Controls.Add(new UC_UserItem());
                return;
            }

            DeleteEmployee.Enabled = true;

            var row = EmployeeViewer.SelectedRows[0];

            var userItem = new UC_UserItem(
                row.Cells["UserName"].Value?.ToString(),
                row.Cells["FullName"].Value?.ToString(),
                row.Cells["Gender"].Value?.ToString(),
                row.Cells["RoleName"].Value?.ToString()
            );

            CurrentEmployeeFlowPanel.Controls.Add(userItem);
        }

        //==========================================================
        // 6. Clear input
        //==========================================================
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
