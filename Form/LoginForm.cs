using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Serilog;

namespace Menu_Management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Username.KeyDown += Input_KeyDown;
            Password.KeyDown += Input_KeyDown;

            Log.Information("Khởi tạo LoginForm thành công.");
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton.PerformClick();
            }
        }

        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(Username.Text) ||
                string.IsNullOrWhiteSpace(Password.Text))
            {
                Log.Warning("Người dùng để trống Username hoặc Password.");
                return false;
            }
            return true;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Log.Information("Người dùng đang đăng nhập với username: {User}", Username.Text);

            try
            {
                if (!IsValidInput())
                {
                    throw new Exception("All fields must be filled!");
                }

                if (CheckLogin(Username.Text, Password.Text))
                {
                    Log.Information("Đăng nhập thành công cho user: {User}", Username.Text);
                    OpenMainForm(Login.Fullname);
                }
                else
                {
                    throw new Exception("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xử lý đăng nhập.");
                MessageBox.Show(ex.Message, "Login Error");
            }
            finally
            {
                Log.Debug("Hoàn tất LoginButton_Click()");
                Log.Debug("---------------------------------------");
            }
        }

        // =========================================================
        // HÀM CHECKLOGIN – ĐÃ FIX HOÀN CHỈNH
        // =========================================================
        private bool CheckLogin(string username, string password)
        {
            Log.Verbose("Bắt đầu CheckLogin()");
            Log.Debug("Username nhận vào: {User}", username);

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    Log.Information("Kết nối SQL thành công.");

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM Accounts WHERE UserName = @username AND Password = @password",
                        sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            LoadUserData(reader);
                            return true;
                        }
                        else
                        {
                            Log.Warning("Không tìm thấy tài khoản.");
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.Error(ex, "Lỗi SQL ở CheckLogin()");
                throw;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Lỗi nghiêm trọng ở CheckLogin()");
                throw;
            }
            finally
            {
                Log.Debug("Kết thúc CheckLogin()");
            }
        }

        // =========================================================

        private void LoadUserData(SqlDataReader reader)
        {
            try
            {
                Login.User = reader["UserName"].ToString();
                Login.Password = reader["Password"].ToString();
                Login.Fullname = reader["FullName"].ToString();
                Login.Role = Login.GetRole(Convert.ToInt32(reader["RoleID"]));

                Login.SetAccountStatus(Login.User, "Online");

                Log.Information("Load dữ liệu user thành công: {User}", Login.User);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi load dữ liệu user");
                throw;
            }
        }

        private void OpenMainForm(string fullname)
        {
            try
            {
                Log.Information("Mở MainForm cho user: {User}", fullname);

                this.Hide();
                MainForm mainForm = new MainForm(fullname);
                mainForm.Show();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Không thể mở MainForm");
                throw;
            }
        }
    }
}
