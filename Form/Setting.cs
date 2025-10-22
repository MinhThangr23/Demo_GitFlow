using Guna.UI2.WinForms;
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
    public partial class Setting : Form
    {
        
        public Guna2Button changeMenuBtn => ChangeMenuBtn;

        public Guna2Button addEmployeeBtn => AddEmployee;
        Panel mainpanel;
        private BillForm billform;
        public Setting(Panel main, BillForm billform)
        {
            InitializeComponent();
            Login.PhanQuyen(this, Login.Role);
            mainpanel = main;
            this.billform = billform;

        }

        private void ChangeMenuBtn_Click(object sender, EventArgs e)
        {
            ChangeMenuForm ChangeMenuForm = new ChangeMenuForm(mainpanel);
            MainHelper.ShowForm(ChangeMenuForm, mainpanel);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm(billform);
            MainHelper.ShowForm(homeForm, mainpanel);
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            DeleteEmployeeButton addform = new DeleteEmployeeButton(); //do cái form nó tên vậy á, còn tên file là EmployeeManagement.cs
            MainHelper.ShowForm(addform, mainpanel);
        }

        private void AdminCheckOut_Click(object sender, EventArgs e)
        {
            AdminCheckoutFrm admincheckout = new AdminCheckoutFrm();
            MainHelper.ShowForm(admincheckout, mainpanel);
        }

        private void ChangePassbtn_Click(object sender, EventArgs e)
        {
            ChangePassForm changePassForm = new ChangePassForm();
            changePassForm.Show();
        }
    }
}
