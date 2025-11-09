using Azure.Identity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Management.Class
{
    public class Login
    {
        public static string User;
        public static string Password;
        public static string Fullname;
        public static string Role;


        public static void PhanQuyen(Form form, string role)
        {
            if(form is Setting settingform)
            {
                if(role != "Admin")
                {
                    settingform.addEmployeeBtn.Enabled = false;
                    settingform.changeMenuBtn.Enabled = false;
                    
                }    
            }
        }
        public static string GetRole(int RoleID)
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("SELECT RoleName FROM Roles WHERE RoleID = @RoleID", sqlcon);
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["RoleName"].ToString();
                }
                else
                {
                    return "Unknown Role";
                }
            }    
        }

        public static bool isOnline(string username)
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string query = "SELECT COUNT(*) FROM Accounts WHERE UserName = @username AND Status = 'Online'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", username);
                int count = (int)sqlcmd.ExecuteScalar();
                return count == 1; // Trả về true nếu tài khoản đang online, false nếu không
            }
        }

        public static void SetAccountStatus(string username, string status)
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                string query = "UPDATE Accounts SET Status = @status WHERE UserName = @username";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@status", status);
                sqlcmd.Parameters.AddWithValue("@username", username);
                sqlcmd.ExecuteNonQuery();
            }
        }
    }

}


