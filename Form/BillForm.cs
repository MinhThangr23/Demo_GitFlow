using Menu_Management.Class;
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
    public partial class BillForm : Form
    {
        public FlowLayoutPanel billflowpanel => BillflowPanel;
        public BillForm()
        {
            InitializeComponent();
            Login.PhanQuyen(this, Login.Role);
            this.StartPosition = FormStartPosition.Manual; // Không cho tự căn giữa
            this.Location = new Point(0, 0);
            BillHelper.LoadBills(BillflowPanel, this);
        }
    }
}
