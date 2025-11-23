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
        private readonly Panel mainPanel;
        public ChangeMenuForm(Panel mainPanel)
        {
            InitializeComponent();
            this.mainPanel = mainPanel;
        }
        #region Load dữ liệu
        private void ChangeMenuForm_Load(object sender, EventArgs e)
        {
            LoadCategories(); // Load danh mục vào ComboBox
            LoadDishes(); // Load món ăn vào DataGridView
        }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải danh mục: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDishes()
        {
            ShowData.ColumnHeadersHeight = 30; // Đặt chiều cao tiêu đề cột
            ShowData.Columns.Clear();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải danh sách món ăn: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Kiểm tra đầu vào (guard clause + throw)
        private void ValidateInputOrThrow(bool requireImage = true)
        {
            if (string.IsNullOrWhiteSpace(DishIdTxt.Text))
                throw new ArgumentException("Vui lòng nhập ID món ăn.");
            if (string.IsNullOrWhiteSpace(NameTxt.Text))
                throw new ArgumentException("Vui lòng nhập tên món ăn.");
            if (CategoryCBB.SelectedValue == null)
                throw new ArgumentException("Vui lòng chọn danh mục.");
            if (!float.TryParse(PriceTxt.Text.Trim(), out float price) || price <= 0)
                throw new ArgumentException("Giá phải là số dương hợp lệ.");
            if (requireImage && pictureBox.Image == null)
                throw new ArgumentException("Vui lòng chọn ảnh món ăn.");
        }
        #endregion
        #region Xử lý ảnh
        private byte[] GetImageBytesFromPictureBox()
        {
            if (pictureBox.Image == null) return null;
            using var ms = new MemoryStream();
            using var imgClone = new Bitmap(pictureBox.Image); // tránh lock file
            imgClone.Save(ms, pictureBox.Image.RawFormat);
            return ms.ToArray();
        }
        private void LoadImageToPictureBox(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                pictureBox.Image = null;
                return;
            }
            using var ms = new MemoryStream(imageBytes);
            pictureBox.Image = Image.FromStream(ms);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion
        #region Thêm món ăn
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputOrThrow(requireImage: true); // Yêu cầu ảnh khi thêm món
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            byte[] imageBytes = GetImageBytesFromPictureBox();
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();
                const string sql = @"
                    INSERT INTO Dishes (DishID, DishName, CategoryID, Price, DishIMG)
                    VALUES (@DishID, @DishName, @CategoryID, @Price, @DishIMG)";

                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@DishID", DishIdTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@DishName", NameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text.Trim()));
                cmd.Parameters.AddWithValue("@DishIMG", imageBytes);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Thêm món ăn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { 
                    MessageBox.Show("Không thể thêm món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu khi thêm món: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; //throw để an toàn hơn thì sao không throw nhỉ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; //tại sao lại không throw ở đây nhỉ
            }
            finally
            {
                LoadDishes(); // luôn reload danh sách dù thành công hay lỗi
            }
        }
        #endregion
        #region Cập nhật món ăn
        private void AlterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputOrThrow(requireImage: false);
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return;
            }
            if (ShowData.CurrentRow == null || ShowData.CurrentRow.Cells["DishID"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần cập nhật.", "Chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            string dishId = ShowData.CurrentRow.Cells["DishID"].Value.ToString();
            byte[] imageBytes = GetImageBytesFromPictureBox();
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();
                const string sql = @"
                    UPDATE Dishes
                    SET DishName = @DishName,
                        CategoryID = @CategoryID,
                        Price = @Price,
                        DishIMG = @DishIMG
                    WHERE DishID = @DishID";
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@DishID", dishId);
                cmd.Parameters.AddWithValue("@DishName", NameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryID", CategoryCBB.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", float.Parse(PriceTxt.Text.Trim()));
                cmd.Parameters.AddWithValue("@DishIMG", imageBytes ?? (object)DBNull.Value);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
                else
                {
                    MessageBox.Show("Không cập nhật được (không tìm thấy món).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu khi cập nhật: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; //throw để an toàn hơn thì sao không throw nhỉ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; //tại sao lại không throw ở đây nhỉ
            }
            finally
            {
                LoadDishes(); // luôn reload danh sách dù thành công hay lỗi
            }
        }
        #endregion
        #region Xóa món ăn (soft delete)
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null || ShowData.CurrentRow.Cells["DishID"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa.", "Chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            string dishId = ShowData.CurrentRow.Cells["DishID"].Value.ToString();
            try
            {
                using var con = new SqlConnection(DatabaseHelper.GetConnectionString());
                con.Open();

                using var cmd = new SqlCommand("UPDATE Dishes SET IsDeleted = 1 WHERE DishID = @DishID", con);
                cmd.Parameters.AddWithValue("@DishID", dishId);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy món ăn để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547) // FK constraint (có hóa đơn chưa thanh toán)
            {
                MessageBox.Show("Không thể xóa món ăn vì vẫn còn trong hóa đơn chưa thanh toán.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw; // vẫn cho finally chạy
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu khi xóa: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;//throw để an toàn hơn thì sao không throw nhỉ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; //throw dài dòng hơn nhưng throw còn hơn nhỉ
            }
            finally
            {
                LoadDishes(); // luôn reload danh sách dù thành công hay lỗi
            }
        }
        #endregion
        #region Chọn ảnh
        private void Browse_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            using var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif" // Lọc các định dạng ảnh phổ biến
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(dlg.FileName); // Load ảnh từ file đã chọn
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Điều chỉnh kích thước ảnh hiển thị
            }
        }
        #endregion
        #region Khi chọn dòng trong DataGridView
        private void ShowData_SelectionChanged(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null || ShowData.CurrentRow.Index < 0) return;// không có dòng nào được chọn
            try
            {
                var row = ShowData.CurrentRow;
                DishIdTxt.Text = row.Cells["DishID"].Value?.ToString() ?? string.Empty;
                NameTxt.Text = row.Cells["DishName"].Value?.ToString() ?? string.Empty;
                PriceTxt.Text = row.Cells["Price"].Value?.ToString() ?? string.Empty;
                if (row.Cells["CategoryID"].Value != null)
                {
                    CategoryCBB.SelectedValue = row.Cells["CategoryID"].Value;
                }    
                if (row.Cells["DishIMG"].Value != DBNull.Value && row.Cells["DishIMG"].Value is byte[] bytes)
                {
                    LoadImageToPictureBox(bytes); // Có ảnh
                }    
                else
                {
                    pictureBox.Image = null; // Không có ảnh
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông tin món ăn: {ex.Message}",  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion//////
    }
}