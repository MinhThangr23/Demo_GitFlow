using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Menu_Management
{
    public partial class ChangeMenuForm : Form
    {
        private readonly Panel mainPanel;

        public ChangeMenuForm(Panel mainPanel)
        {
            InitializeComponent();
            this.mainPanel = mainPanel;
        }

        // =================== FORM LOAD ===================
        private void ChangeMenuForm_Load(object sender, EventArgs e)
        {
            Log.Information("Mở form ChangeMenuForm - Bắt đầu tải dữ liệu.");
            LoadCategories();
            LoadDishes();
        }

        // =================== TẢI DANH MỤC ===================
        private void LoadCategories()
        {
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();
                using var cmd = new SqlCommand("SELECT * FROM Categories", con);
                using var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                CategoryCBB.DataSource = dt;
                CategoryCBB.DisplayMember = "CategoryName";
                CategoryCBB.ValueMember = "CategoryID";

                Log.Debug("Tải danh mục thành công: {Count}", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi tải danh mục");
                MessageBox.Show(ex.Message);
            }
        }

        // =================== TẢI DANH SÁCH MÓN ĂN ===================
        private void LoadDishes()
        {
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();
                using var cmd = new SqlCommand("SELECT * FROM Dishes WHERE IsDeleted = 0", con);
                using var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                ShowData.DataSource = dt;
                if (ShowData.Columns.Contains("DishIMG")) ShowData.Columns["DishIMG"].Visible = false;
                if (ShowData.Columns.Contains("IsDeleted")) ShowData.Columns["IsDeleted"].Visible = false;

                Log.Debug("Tải món ăn thành công: {Count}", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi tải món ăn");
            }
        }

        // =================== KIỂM TRA INPUT ===================
        private void ValidateInputOrThrow(bool requireImage = true)
        {
            if (string.IsNullOrWhiteSpace(DishIdTxt.Text))
                throw new ArgumentException("Vui lòng nhập ID món ăn");
            if (string.IsNullOrWhiteSpace(NameTxt.Text))
                throw new ArgumentException("Vui lòng nhập tên món ăn");
            if (CategoryCBB.SelectedValue == null)
                throw new ArgumentException("Vui lòng chọn danh mục");

            if (!float.TryParse(PriceTxt.Text.Trim(), out float price) || price <= 0)
                throw new ArgumentException("Giá phải hợp lệ");

            if (requireImage && pictureBox.Image == null)
                throw new ArgumentException("Vui lòng chọn ảnh");
        }

        // =================== LẤY ẢNH ===================
        private byte[] GetImageBytesFromPictureBox()
        {
            if (pictureBox.Image == null) return null;

            using var ms = new MemoryStream();
            pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
            return ms.ToArray();
        }

        // =================== LOAD ẢNH RA PICTUREBOX ===================
        private void LoadImageToPictureBox(byte[] imageBytes)
        {
            try
            {
                using var ms = new MemoryStream(imageBytes);
                pictureBox.Image = Image.FromStream(ms);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                pictureBox.Image = null;
            }
        }

        // =================== THÊM MÓN ĂN ===================
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputOrThrow(true);
                byte[] img = GetImageBytesFromPictureBox();

                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();

                using var cmd = new SqlCommand(@"
                    INSERT INTO Dishes (DishID, DishName, CategoryID, Price, DishIMG)
                    VALUES (@DishID, @Name, @Cate, @Price, @Img)", con);

                cmd.Parameters.AddWithValue("@DishID", DishIdTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", NameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Cate", CategoryCBB.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text.Trim()));
                cmd.Parameters.AddWithValue("@Img", img ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm món thành công!");
                LoadDishes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== CẬP NHẬT MÓN ĂN ===================
        private void AlterBtn_Click(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null) return;

            string dishId = ShowData.CurrentRow.Cells["DishID"].Value.ToString();

            try
            {
                ValidateInputOrThrow(false);
                byte[] img = GetImageBytesFromPictureBox();

                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();

                using var cmd = new SqlCommand(@"
                    UPDATE Dishes
                    SET DishName=@Name, CategoryID=@Cate, Price=@Price, DishIMG=@Img
                    WHERE DishID=@ID", con);

                cmd.Parameters.AddWithValue("@ID", dishId);
                cmd.Parameters.AddWithValue("@Name", NameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Cate", CategoryCBB.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text.Trim()));
                cmd.Parameters.AddWithValue("@Img", img ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công!");
                LoadDishes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== XÓA MỀM ===================
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null) return;

            string dishId = ShowData.CurrentRow.Cells["DishID"].Value.ToString();

            using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
            con.Open();

            using var cmd = new SqlCommand("UPDATE Dishes SET IsDeleted = 1 WHERE DishID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", dishId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Xóa thành công!");
            LoadDishes();
        }

        // =================== CHỌN ẢNH ===================
        private void Browse_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(dlg.FileName);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // =================== CHỌN DÒNG ===================
        private void ShowData_SelectionChanged(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null) return;

            DishIdTxt.Text = ShowData.CurrentRow.Cells["DishID"].Value?.ToString();
            NameTxt.Text = ShowData.CurrentRow.Cells["DishName"].Value?.ToString();
            PriceTxt.Text = ShowData.CurrentRow.Cells["Price"].Value?.ToString();

            if (ShowData.CurrentRow.Cells["CategoryID"].Value != null)
                CategoryCBB.SelectedValue = ShowData.CurrentRow.Cells["CategoryID"].Value;

            if (ShowData.CurrentRow.Cells["DishIMG"].Value is byte[] bytes)
                LoadImageToPictureBox(bytes);
            else
                pictureBox.Image = null;
        }
    }
}
