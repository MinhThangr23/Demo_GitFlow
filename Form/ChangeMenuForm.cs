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
        private Panel mainPanel;

        public ChangeMenuForm(Panel mainPanel)
        {
            InitializeComponent();
            this.mainPanel = mainPanel;
        }

        private void ChangeMenuForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadDishes();
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Categories", sqlcon))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        CategoryCBB.DataSource = dt;
                        CategoryCBB.DisplayMember = "CategoryName";
                        CategoryCBB.ValueMember = "CategoryID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load danh mục: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDishes()
        {
            ShowData.ColumnHeadersHeight = 30;
            ShowData.Columns.Clear();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Dishes WHERE IsDeleted = 0", sqlcon))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        ShowData.DataSource = dt;
                        if (ShowData.Columns.Contains("DishIMG")) ShowData.Columns["DishIMG"].Visible = false;
                        if (ShowData.Columns.Contains("IsDeleted")) ShowData.Columns["IsDeleted"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu món ăn: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(bool requireImage = true)
        {
            if (string.IsNullOrWhiteSpace(DishIdTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập ID món ăn.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(NameTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn.");
                return false;
            }
            if (CategoryCBB.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.");
                return false;
            }
            if (!float.TryParse(PriceTxt.Text, out float price) || price <= 0)
            {
                MessageBox.Show("Giá phải là số dương hợp lệ.");
                return false;
            }
            if (requireImage && pictureBox.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh món ăn.");
                return false;
            }
            return true;
        }

        private byte[] GetImageBytesFromPictureBox()
        {
            if (pictureBox.Image == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Image imgClone = new Bitmap(pictureBox.Image)) // Clone để tránh lỗi lock
                {
                    imgClone.Save(ms, pictureBox.Image.RawFormat);
                }
                return ms.ToArray();
            }
        }

        private void LoadImageToPictureBox(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                pictureBox.Image = null;
                return;
            }
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                pictureBox.Image = Image.FromStream(ms);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            byte[] imageBytes = GetImageBytesFromPictureBox();
            if (imageBytes == null) return;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    using (SqlCommand insertCmd = new SqlCommand("INSERT INTO Dishes (DishID, DishName, CategoryID, Price, DishIMG) VALUES (@DishID, @DishName, @CategoryID, @Price, @DishIMG)", sqlcon))
                    {
                        insertCmd.Parameters.AddWithValue("@DishID", DishIdTxt.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@DishName", NameTxt.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text.Trim()));
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món ăn: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(requireImage: false)) return; // Ảnh optional cho update
            byte[] imageBytes = GetImageBytesFromPictureBox();
            DataGridViewRow selectedRow = ShowData.CurrentRow;
            if (selectedRow == null || selectedRow.Cells["DishID"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần cập nhật.");
                return;
            }
            string dishId = selectedRow.Cells["DishID"].Value.ToString();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    using (SqlCommand updateCmd = new SqlCommand("UPDATE Dishes SET DishName=@DishName, CategoryID=@CategoryID, Price=@Price, DishIMG=@DishIMG WHERE DishID=@DishID", sqlcon))
                    {
                        updateCmd.Parameters.AddWithValue("@DishID", dishId);
                        updateCmd.Parameters.AddWithValue("@DishName", NameTxt.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                        updateCmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text.Trim()));
                        updateCmd.Parameters.AddWithValue("@DishIMG", imageBytes ?? (object)DBNull.Value); // Nếu không có ảnh mới, giữ nguyên

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!");
                            LoadDishes();
                        }
                        else
                        {
                            MessageBox.Show("Không cập nhật được!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật món ăn: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = ShowData.CurrentRow;
            if (selectedRow == null || selectedRow.Cells["DishID"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa.");
                return;
            }
            string dishId = selectedRow.Cells["DishID"].Value.ToString();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    sqlcon.Open();
                    using (SqlCommand deleteCmd = new SqlCommand("UPDATE Dishes SET IsDeleted = 1 WHERE DishID=@DishID", sqlcon))
                    {
                        deleteCmd.Parameters.AddWithValue("@DishID", dishId);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!");
                            LoadDishes();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy món ăn cần xóa.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có đơn vẫn chưa thanh toán chứa món này hoặc lỗi: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null; // Reset ảnh trước
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void ShowData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ShowData.CurrentRow != null && ShowData.CurrentRow.Index >= 0)
                {
                    DataGridViewRow row = ShowData.CurrentRow;
                    DishIdTxt.Text = row.Cells["DishID"].Value?.ToString() ?? string.Empty;
                    NameTxt.Text = row.Cells["DishName"].Value?.ToString() ?? string.Empty;
                    PriceTxt.Text = row.Cells["Price"].Value?.ToString() ?? string.Empty;
                    if (row.Cells["DishIMG"].Value != DBNull.Value && row.Cells["DishIMG"].Value is byte[] imageBytes)
                    {
                        LoadImageToPictureBox(imageBytes);
                    }
                    else
                    {
                        pictureBox.Image = null;
                    }
                    if (row.Cells["CategoryID"].Value != null)
                    {
                        CategoryCBB.SelectedValue = row.Cells["CategoryID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn món ăn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}