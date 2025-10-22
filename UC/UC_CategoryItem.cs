using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Management
{

    public partial class UC_CategoryItem : UserControl
    {
        public event EventHandler OnCategorySelect; //Khai báo 1 sự kiện
        public string CategoryID;

        public UC_CategoryItem(string name, Image image, string categoryID)
        {
            InitializeComponent();
            CategoryLabel.Text = name;
            CategoryImage.Image = image;
            CategoryID=categoryID;
            this.CategoryID = categoryID;
        }
        private void CategoryLabel_Click(object sender, EventArgs e)
        {
            OnCategorySelect.Invoke(this, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            OnCategorySelect.Invoke(this, e);
        }
        private void UC_CategoryItem_Click(object sender, EventArgs e) //sự kiện nhấp này là để thông báo kích hoạt sự kiện OnCategorySelect
        {
            OnCategorySelect.Invoke(this, e); //gọi sự kiện CategorySelect khi người dùng nhấp vào điều khiển này
        }

        private void CategoryImage_Click(object sender, EventArgs e)
        {
            OnCategorySelect.Invoke(this, e);
        }
    }
}
