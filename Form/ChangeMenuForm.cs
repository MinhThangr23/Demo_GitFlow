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
        private Panel mainpanel;

        public ChangeMenuForm(Panel mainpanel)
        {
            InitializeComponent();
            this.mainpanel = mainpanel;
        }

        private void LoadDishes()
        {
            ShowData.ColumnHeadersHeight = 30;
            ShowData.Columns.Clear();
            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();
                using var cmd = new SqlCommand("SELECT * FROM Dishes WHERE IsDeleted = 0", sqlcon);
                using var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                ShowData.DataSource = dt;
                ShowData.Columns["DishIMG"].Visible = false;
                ShowData.Columns["IsDeleted"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private byte[] GetImageBytes(Image image)
        {
            if (image == null) return null;
            using var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Use PNG format
            return ms.ToArray();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh món ăn.");
                return;
            }

            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();

                using var insertCmd = new SqlCommand(
                    "INSERT INTO Dishes (DishID, DishName, CategoryID, Price, DishIMG) VALUES (@DishID, @DishName, @CategoryID, @Price, @DishIMG)", sqlcon);
                insertCmd.Parameters.AddWithValue("@DishID", DishIdTxt.Text);
                insertCmd.Parameters.AddWithValue("@DishName", NameTxt.Text);
                insertCmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                insertCmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text));
                insertCmd.Parameters.AddWithValue("@DishIMG", GetImageBytes(pictureBox.Image));

                if (insertCmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm món ăn thành công!");
                    LoadDishes();
                }
                else
                {
                    MessageBox.Show("Không thể thêm món ăn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterBtn_Click(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn để cập nhật.");
                return;
            }

            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();

                var dishId = ShowData.CurrentRow.Cells["DishID"].Value.ToString();
                using var updateCmd = new SqlCommand(
                    "UPDATE Dishes SET DishName=@DishName, CategoryID=@CategoryID, Price=@Price, DishIMG=@DishIMG WHERE DishID=@DishID", sqlcon);
                updateCmd.Parameters.AddWithValue("@DishID", dishId);
                updateCmd.Parameters.AddWithValue("@DishName", NameTxt.Text);
                updateCmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                updateCmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text));
                updateCmd.Parameters.AddWithValue("@DishIMG", GetImageBytes(pictureBox.Image));

                if (updateCmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Không cập nhật được!");

                LoadDishes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null || ShowData.CurrentRow.Cells["DishID"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa.");
                return;
            }

            try
            {
                using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
                sqlcon.Open();
                var dishId = ShowData.CurrentRow.Cells["DishID"].Value.ToString();
                using var deleteCmd = new SqlCommand("UPDATE Dishes SET IsDeleted = 1 WHERE DishID=@DishID", sqlcon);
                deleteCmd.Parameters.AddWithValue("@DishID", dishId);

                if (deleteCmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Xóa thành công!");
                else
                    MessageBox.Show("Không tìm thấy món ăn cần xóa.");

                LoadDishes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có đơn vẫn chưa thanh toán chứa món này");
            }
        }

        private void ChangeMenuForm_Load(object sender, EventArgs e)
        {
            using var sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString());
            sqlcon.Open();
            using var sqlcmd = new SqlCommand("SELECT * FROM Categories", sqlcon);
            using var adapter = new SqlDataAdapter(sqlcmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            CategoryCBB.DataSource = dt;
            CategoryCBB.DisplayMember = "CategoryName";
            CategoryCBB.ValueMember = "CategoryID";
            LoadDishes();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            pictureBox.Controls.Clear();
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var img = Image.FromFile(openFileDialog.FileName))
                {
                    pictureBox.Image = new Bitmap(img); // Clone image to release file lock
                }
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
                    var row = ShowData.CurrentRow;
                    DishIdTxt.Text = row.Cells["DishID"].Value?.ToString();
                    NameTxt.Text = row.Cells["DishName"].Value?.ToString();
                    PriceTxt.Text = row.Cells["Price"].Value?.ToString();

                    if (row.Cells["DishIMG"].Value is byte[] imgBytes)
                    {
                        using var ms = new MemoryStream(imgBytes);
                        pictureBox.Image = Image.FromStream(ms);
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
