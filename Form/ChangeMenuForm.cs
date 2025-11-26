using log4net;
using Menu_Management.Class;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Menu_Management
{
    public partial class ChangeMenuForm : Form
    {
        private readonly Panel mainPanel;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger(); // NLog logger

        public ChangeMenuForm(Panel mainPanel)
        {
            InitializeComponent();
            this.mainPanel = mainPanel;
        }
        #region Load dữ liệu
        private void ChangeMenuForm_Load(object sender, EventArgs e)
        {
            Log.Info("Mở form ChangeMenuForm - Bắt đầu tải dữ liệu.");
            LoadCategories();
            LoadDishes();
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

                Log.Debug("Tải danh mục thành công. Số lượng: {Count}", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không thể tải danh mục từ CSDL.");
                MessageBox.Show($"Không thể tải danh mục: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDishes()
        {
            ShowData.ColumnHeadersHeight = 30;
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
                Log.Debug("Tải danh sách món ăn thành công. Số lượng: {Count}", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không thể tải danh sách món ăn.");
                MessageBox.Show($"Không thể tải danh sách món ăn: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Kiểm tra đầu vào
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
            try
            {
                using var ms = new MemoryStream();
                using var imgClone = new Bitmap(pictureBox.Image);
                imgClone.Save(ms, pictureBox.Image.RawFormat);
                Log.Debug("Chuyển đổi ảnh thành byte[] thành công. Kích thước: {Size} bytes", ms.Length);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi chuyển đổi ảnh sang byte[].");
                throw;
            }
        }
        private void LoadImageToPictureBox(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                pictureBox.Image = null;
                return;
            }
            try
            {
                using var ms = new MemoryStream(imageBytes);
                pictureBox.Image = Image.FromStream(ms);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi load ảnh từ byte[].");
                pictureBox.Image = null;
            }
        }
        #endregion
        #region Thêm món ăn
        private void AddBtn_Click(object sender, EventArgs e)
        {
            Log.Info("Người dùng nhấn nút Thêm món ăn.");
            try
            {
                ValidateInputOrThrow(requireImage: true);
            }
            catch (ArgumentException aex)
            {
                Log.Warning(aex, "Input không hợp lệ khi thêm món ăn.");
                MessageBox.Show(aex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                cmd.Parameters.AddWithValue("@DishIMG", imageBytes ?? (object)DBNull.Value);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Log.Info("Thêm món ăn thành công: {DishID} - {DishName}", DishIdTxt.Text.Trim(), NameTxt.Text.Trim());
                    MessageBox.Show("Thêm món ăn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Warning("Thêm món ăn thất bại: không có dòng nào bị ảnh hưởng.");
                    MessageBox.Show("Không thể thêm món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Trùng khóa chính
            {
                Log.Warning(sqlEx, "Trùng ID món ăn: {DishID}", DishIdTxt.Text.Trim());
                MessageBox.Show("ID món ăn đã tồn tại. Vui lòng chọn ID khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi thêm món ăn.");
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDishes();
            }
        }
        #endregion
        #region Cập nhật món ăn
        private void AlterBtn_Click(object sender, EventArgs e)
        {
            Log.Info("Người dùng nhấn nút Cập nhật món ăn.");
            try
            {
                ValidateInputOrThrow(requireImage: false);
            }
            catch (ArgumentException aex)
            {
                Log.Warning(aex, "Input không hợp lệ khi cập nhật món ăn.");
                MessageBox.Show(aex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ShowData.CurrentRow == null || ShowData.CurrentRow.Cells["DishID"].Value == null)
            {
                Log.Warning("Không có món ăn nào được chọn để cập nhật.");
                MessageBox.Show("Vui lòng chọn món ăn cần cập nhật.", "Chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                    Log.Info("Cập nhật món ăn thành công: {DishID}", dishId);
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Warning("Không tìm thấy món ăn để cập nhật: {DishID}", dishId);
                    MessageBox.Show("Không cập nhật được (không tìm thấy món).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi cập nhật món ăn: {DishID}", dishId);
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDishes();
            }
        }
        #endregion
        #region Xóa món ăn (soft delete)
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            Log.Info("Người dùng nhấn nút Xóa món ăn.");

            if (ShowData.CurrentRow == null || ShowData.CurrentRow.Cells["DishID"].Value == null)
            {
                Log.Warning("Không có món ăn nào được chọn để xóa.");
                MessageBox.Show("Vui lòng chọn món ăn cần xóa.", "Chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                    Log.Info("Xóa mềm món ăn thành công: {DishID}", dishId);
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Warning("Không tìm thấy món ăn để xóa: {DishID}", dishId);
                    MessageBox.Show("Không tìm thấy món ăn để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547) // FK constraint
            {
                Log.Warning(sqlEx, "Không thể xóa món ăn vì còn tồn tại trong hóa đơn chưa thanh toán: {DishID}", dishId);
                MessageBox.Show("Không thể xóa món ăn vì vẫn còn trong hóa đơn chưa thanh toán.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException sqlEx)
            {
                Log.Error(sqlEx, "Lỗi SQL khi xóa món ăn: {DishID}", dishId);
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDishes();
            }
        }
        #endregion
        #region Chọn ảnh
        private void Browse_Click(object sender, EventArgs e)
        {
            Log.Debug("Người dùng mở dialog chọn ảnh món ăn.");
            pictureBox.Image = null;
            using var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image = Image.FromFile(dlg.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    Log.Debug("Load ảnh thành công từ đường dẫn: {Path}", dlg.FileName);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Không thể load ảnh từ file: {Path}", dlg.FileName);
                    MessageBox.Show("Không thể tải ảnh. File có thể bị hỏng.", "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Khi chọn dòng trong DataGridView
        private void ShowData_SelectionChanged(object sender, EventArgs e)
        {
            if (ShowData.CurrentRow == null || ShowData.CurrentRow.Index < 0) return;
            try
            {
                var row = ShowData.CurrentRow;
                DishIdTxt.Text = row.Cells["DishID"].Value?.ToString() ?? string.Empty;
                NameTxt.Text = row.Cells["DishName"].Value?.ToString() ?? string.Empty;
                PriceTxt.Text = row.Cells["Price"].Value?.ToString() ?? string.Empty;

                if (row.Cells["CategoryID"].Value != null)
                    CategoryCBB.SelectedValue = row.Cells["CategoryID"].Value;

                if (row.Cells["DishIMG"].Value != DBNull.Value && row.Cells["DishIMG"].Value is byte[] bytes)
                    LoadImageToPictureBox(bytes);
                else
                    pictureBox.Image = null;

                Log.Debug("Hiển thị thông tin món ăn: {DishID}", DishIdTxt.Text);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi hiển thị thông tin món ăn từ DataGridView.");
                MessageBox.Show($"Lỗi khi hiển thị thông tin món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}