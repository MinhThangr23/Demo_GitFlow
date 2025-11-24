using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private bool DoesUsernameExist(string username) // Trả về true nếu username đã tồn tại
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
        #endregion
        #region Xóa nhân viên
        private void DelelteEmployee_Click(object sender, EventArgs e)
        {
            if (EmployeeViewer.SelectedRows.Count == 0 || EmployeeViewer.SelectedRows[0].Cells["UserName"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.", "Chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (MessageBox.Show
                ("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return; // Người dùng hủy xóa
            string username = EmployeeViewer.SelectedRows[0].Cells["UserName"].Value.ToString();
            if (Login.isOnline(username))
            {
                MessageBox.Show("Tài khoản này đang online, không thể xóa!", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
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
                    MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // rows == 0
                {
                    MessageBox.Show("Không tìm thấy tài khoản để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547) // FK constraint
            {
                MessageBox.Show("Không thể xóa tài khoản vì đang có dữ liệu liên quan (ví dụ: hóa đơn).", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu khi xóa: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            finally
            {
                DatabaseHelper.ShowEmployee(EmployeeViewer); // Cập nhật lại danh sách nhân viên
            }
        }
        #endregion
        #region Xóa tất cả nhân viên (trừ admin)
        private void DeleteAllEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Cảnh báo: Hành động này sẽ xóa TẤT CẢ tài khoản nhân viên (trừ admin) đang offline.\nBạn có chắc chắn muốn tiếp tục?",
                "Xác nhận xóa hàng loạt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return; // Người dùng hủy xóa
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();
                const string sql = @"
                    DELETE FROM Accounts 
                    WHERE RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Employee') 
                      AND Status = 'Offline'";
                using var cmd = new SqlCommand(sql, con);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Xóa tất cả tài khoản nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // rows == 0
                {
                    MessageBox.Show("Không có tài khoản nhân viên nào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu khi xóa hàng loạt: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Rethrow để xử lý thêm nếu cần
            }
            finally
            {
                DatabaseHelper.ShowEmployee(EmployeeViewer); // Cập nhật lại danh sách nhân viên
            }
        }
        #endregion
        #region Hiển thị thông tin khi chọn dòng
        private void EmployeeViewer_SelectionChanged(object sender, EventArgs e)
        {
            CurrentEmployeeFlowPanel.Controls.Clear();
            if (EmployeeViewer.SelectedRows.Count == 0) // Không có dòng nào được chọn
            {
                DeleteEmployee.Enabled = false;
                CurrentEmployeeFlowPanel.Controls.Add(new UC_UserItem());
                return;
            }
            DeleteEmployee.Enabled = true;
            var row = EmployeeViewer.SelectedRows[0];
            var userItem = new UC_UserItem(
                row.Cells["UserName"].Value?.ToString() ?? string.Empty,
                row.Cells["FullName"].Value?.ToString() ?? string.Empty,
                row.Cells["Gender"].Value?.ToString() ?? string.Empty,
                row.Cells["RoleName"].Value?.ToString() ?? string.Empty
            );
            CurrentEmployeeFlowPanel.Controls.Add(userItem);
        }
        #endregion
        #region Xóa dữ liệu nhập
        private void ClearInputFields()
        {
            Username.Clear();
            Password.Clear();
            Fullname.Clear();
            GenderComboBox.SelectedIndex = -1;
            RoleComboBox.SelectedIndex = -1;
        }
        #endregion
    }
}
