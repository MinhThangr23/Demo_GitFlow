using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Menu_Management.Class
{
    public class MainHelper
    {
        public static string currentCategoryID = ""; // ID của danh mục hiện tại

        public static string GetCurrentCategory(string categoryID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoryID))
                {
                    Log.Warning("CategoryID rỗng hoặc null"); // Log mức Warning nếu input không hợp lệ
                    throw new Exception("CategoryID không được để trống!");
                }
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    Log.Information("Đã mở kết nối SQL thành công"); // Log mức Information khi kết nối thành công
                    SqlCommand sqlcmd = new SqlCommand("SELECT CategoryName FROM Categories WHERE CategoryID = @CategoryID",sqlcon);
                    sqlcmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    SqlDataReader reader = sqlcmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string categoryName = reader["CategoryName"].ToString();
                        currentCategoryID = categoryID;
                        Log.Information("Lấy Category thành công: {Name}", categoryName); // Log mức Information khi lấy dữ liệu thành công
                        return categoryName;
                    }
                    else
                    {
                        Log.Warning("Không tìm thấy Category với ID = {ID}", categoryID); // Log mức Warning nếu không tìm thấy dữ liệu
                        throw new Exception("Category not found.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.Error(ex, "Lỗi SQL khi lấy CategoryID = {ID}", categoryID); // Log mức Error với chi tiết lỗi SQL
                throw; // ném lỗi lại cho nơi gọi xử lý
            }
        }
        internal static void ShowForm(Form f, Panel MainPanel)
        {
            // Nếu chưa có thì mới add
            if (!MainPanel.Controls.Contains(f))
            {
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.StartPosition = FormStartPosition.Manual;
                f.Location = new Point(0, 0);
                MainPanel.Controls.Add(f);
            }

            // Đưa form lên đầu (hiển thị)
            f.BringToFront();
            f.Show();
        }
    }
}
