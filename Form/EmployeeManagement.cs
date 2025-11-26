using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Serilog;
using Serilog.Events;

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
                int count = (int)cmd.ExecuteScalar();
                Log.Debug("Kiểm tra username tồn tại: {Username} → {Exists}", username, count > 0);
                return count > 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi kiểm tra username tồn tại: {Username}", username);
                MessageBox.Show($"Lỗi khi kiểm tra tên đăng nhập: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
        #region Thêm nhân viên
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
                MessageBox.Show(aex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string username = Username.Text.Trim();
            if (DoesUsernameExist(username))
            {
                Log.Warning("Thử thêm nhân viên với username đã tồn tại: {Username}", username);
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Log.Information("Thêm nhân viên thành công: {Username} - {FullName}", username, Fullname.Text.Trim());
                    MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Warning("Thêm nhân viên thất bại: không có dòng nào bị ảnh hưởng.");
                    MessageBox.Show("Không thể thêm tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601)
            {
                Log.Warning(sqlEx, "Trùng khóa chính khi thêm nhân viên: {Username}", username);
                MessageBox.Show("Tên đăng nhập đã tồn tại (lỗi CSDL).", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi thêm nhân viên: {Username}", username);
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Log.Information("Người dùng nhấn nút Xóa nhân viên.");

            if (EmployeeViewer.SelectedRows.Count == 0 || EmployeeViewer.SelectedRows[0].Cells["UserName"].Value == null)
            {
                Log.Warning("Người dùng cố xóa nhưng chưa chọn tài khoản.");
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.", "Chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                Log.Information("Người dùng hủy thao tác xóa tài khoản.");
                return;
            }
            string username = EmployeeViewer.SelectedRows[0].Cells["UserName"].Value.ToString();
            if (Login.isOnline(username))
            {
                Log.Warning("Không thể xóa tài khoản đang online: {Username}", username);
                MessageBox.Show("Tài khoản này đang online, không thể xóa!", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    Log.Information("Xóa nhân viên thành công: {Username}", username);
                    MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Warning("Không tìm thấy tài khoản để xóa: {Username}", username);
                    MessageBox.Show("Không tìm thấy tài khoản để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            {
                Log.Warning(sqlEx, "Không thể xóa nhân viên do ràng buộc FK: {Username}", username);
                MessageBox.Show("Không thể xóa tài khoản vì đang có dữ liệu liên quan (hóa đơn, lịch sử...).", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi xóa nhân viên: {Username}", username);
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseHelper.ShowEmployee(EmployeeViewer);
            }
        }
        #endregion
        #region Xóa tất cả nhân viên (trừ admin)
        private void DeleteAllEmployee_Click(object sender, EventArgs e)
        {
            Log.Information("Người dùng nhấn nút Xóa tất cả nhân viên.");

            if (MessageBox.Show(
                "Cảnh báo: Hành động này sẽ xóa TẤT CẢ tài khoản nhân viên (trừ admin) đang offline.\nBạn có chắc chắn muốn tiếp tục?",
                "Xác nhận xóa hàng loạt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                Log.Information("Người dùng hủy thao tác xóa hàng loạt.");
                return;
            }
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
                    Log.Information("Xóa hàng loạt thành công: {Count} tài khoản nhân viên.", rows);
                    MessageBox.Show($"Đã xóa thành công {rows} tài khoản nhân viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Information("Không có tài khoản nhân viên nào để xóa (offline).");
                    MessageBox.Show("Không có tài khoản nhân viên nào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi xóa hàng loạt nhân viên.");
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseHelper.ShowEmployee(EmployeeViewer);
            }
        }
        #endregion
        #region Hiển thị thông tin khi chọn dòng
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
                row.Cells["UserName"].Value?.ToString() ?? string.Empty,
                row.Cells["FullName"].Value?.ToString() ?? string.Empty,
                row.Cells["Gender"].Value?.ToString() ?? string.Empty,
                row.Cells["RoleName"].Value?.ToString() ?? string.Empty
            );
            CurrentEmployeeFlowPanel.Controls.Add(userItem);
            Log.Debug("Hiển thị thông tin nhân viên: {Username}", row.Cells["UserName"].Value?.ToString());
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