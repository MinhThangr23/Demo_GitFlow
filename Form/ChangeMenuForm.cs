using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Menu_Management.Class;
using System.IO;

namespace Menu_Management
{
    public partial class ChangeMenuForm : Form
    {
        Panel mainpanel;
        public ChangeMenuForm(Panel mainpanel)
        {
            InitializeComponent();
            this.mainpanel=mainpanel;
        }

        private void LoadDishes()
        {
            ShowData.ColumnHeadersHeight = 30; // Đặt chiều cao tiêu đề cột
            ShowData.Columns.Clear(); // Xóa các cột hiện tại trong DataGridView
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Dishes WHERE IsDeleted = 0", sqlcon);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu vào DataGridView
                    ShowData.DataSource = dt;

                    ShowData.Columns["DishIMG"].Visible = false; // Ẩn cột ảnh gốc nếu không cần thiết
                    ShowData.Columns["IsDeleted"].Visible = false; 

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }

        }
        private void AddBtn_Click(object sender, EventArgs e)
        { 
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {

                    sqlcon.Open();

                    if (pictureBox.Image == null)
                    {
                        MessageBox.Show("Vui lòng chọn ảnh món ăn.");
                        return;
                    }

                    // Xử lý ảnh
                    byte[] imageBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                        imageBytes = ms.ToArray();
                    }

                    // Thêm món ăn vào bảng Dishes
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO Dishes (DishID, DishName, CategoryID, Price, DishIMG) VALUES (@DishID, @DishName, @CategoryID, @Price, @DishIMG)", sqlcon);
                    insertCmd.Parameters.AddWithValue("@DishID", DishIdTxt.Text);
                    insertCmd.Parameters.AddWithValue("@DishName", NameTxt.Text);
                    insertCmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                    insertCmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text));
                    insertCmd.Parameters.AddWithValue("@DishIMG", imageBytes);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm món ăn thành công!");
                        LoadDishes();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm món ăn.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void AlterBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();

                // Xử lý ảnh
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Image imgClone = new Bitmap(pictureBox.Image)) // Clone lại ảnh
                    {
                        imgClone.Save(ms, pictureBox.Image.RawFormat); // Lưu clone thay vì ảnh gốc
                    }
                    imageBytes = ms.ToArray();
                }
                DataGridViewRow selectedRow = ShowData.CurrentRow;
                string DishId = selectedRow.Cells["DishID"].Value.ToString();


                SqlCommand updateCmd = new SqlCommand("UPDATE Dishes SET DishName=@DishName, CategoryID=@CategoryID, Price=@Price, DishIMG=@DishIMG WHERE DishID=@DishID", sqlcon);
                updateCmd.Parameters.AddWithValue("@DishID", DishId);
                updateCmd.Parameters.AddWithValue("@DishName", NameTxt.Text);
                updateCmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                updateCmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text));
                updateCmd.Parameters.AddWithValue("@DishIMG", imageBytes);

                int rows = updateCmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Không cập nhật được!");

                LoadDishes();
            }
        }


        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    SqlCommand deleteCmd = new SqlCommand("UPDATE Dishes SET IsDeleted = '1' WHERE DishID=@DishID", sqlcon);
                    DataGridViewRow selectedRow = ShowData.CurrentRow;
                    if (selectedRow == null || selectedRow.Cells["DishID"].Value == null)
                    {
                        MessageBox.Show("Vui lòng chọn món ăn cần xóa.");
                        return;
                    }
                    string dishId = selectedRow.Cells["DishID"].Value.ToString();
                    deleteCmd.Parameters.AddWithValue("@DishID", dishId);

                    int rows = deleteCmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Xóa thành công!");
                    else
                        MessageBox.Show("Không tìm thấy món ăn cần xóa.");

                    LoadDishes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có đơn vẫn chưa thanh toán chứa món này");
            }

        }


        private void ChangeMenuForm_Load(object sender, EventArgs e)
        {

            using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Categories", sqlcon);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CategoryCBB.DataSource = dt;
                CategoryCBB.DisplayMember = "CategoryName"; // Hiển thị tên loại món ăn
                CategoryCBB.ValueMember = "CategoryID"; // Lưu giá trị ID loại món ăn
                LoadDishes();
            }
        }


        private void Browse_Click(object sender, EventArgs e)
        {
            pictureBox.Controls.Clear(); // Đặt lại ảnh trước khi chọn ảnh mới
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void ShowData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ShowData.CurrentRow != null && ShowData.CurrentRow.Index >= 0)
                {
                    DataGridViewRow row = ShowData.CurrentRow;

                    DishIdTxt.Text = row.Cells["DishID"].Value.ToString();
                    NameTxt.Text = row.Cells["DishName"].Value.ToString();
                    PriceTxt.Text = row.Cells["Price"].Value.ToString();

                    if (row.Cells["DishIMG"].Value != DBNull.Value)
                    {
                        object cellValue = row.Cells["DishIMG"].Value;

                        if (cellValue is byte[] imgBytes)
                        {
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else if (cellValue is Image img)
                        {
                            pictureBox.Image = img;
                        }
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox.Image = null;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn món ăn: " + ex.Message);

            }

        }
    }
}
