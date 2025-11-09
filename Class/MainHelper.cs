using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Management.Class
{
    public class MainHelper
    {
        public static string currentCategoryID = ""; // ID của danh mục hiện tại

        public static string GetCurrentCategory(string categoryID)
        {
            using(SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT CategoryName FROM Categories WHERE CategoryID = @CategoryID", sqlcon);
                sqlcmd.Parameters.AddWithValue("@CategoryID", categoryID.ToString());
                SqlDataReader reader = sqlcmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    string categoryName = reader["CategoryName"].ToString();
                    currentCategoryID = categoryID; // Cập nhật ID của danh mục hiện tại
                    return categoryName;
                }
                else
                {
                    throw new Exception("Category not found.");
                }
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
