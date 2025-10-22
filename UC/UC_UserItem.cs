using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Management
{
    public partial class UC_UserItem : UserControl
    {
        public string username;
        public string fullname;
        public string gender;
        public string role;
        public UC_UserItem(string username, string fullname, string gender, string role)
        {
            InitializeComponent();
            UsernameValue.Text = username;
            FullnameValue.Text = fullname;
            GenderValue.Text = gender;
            RoleValue.Text = role;
            this.username = username;
            this.fullname = fullname;
            this.gender = gender;
            this.role = role;
        }

        public UC_UserItem()
        {
            InitializeComponent();
        }
    }
}
