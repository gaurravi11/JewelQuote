using JewelQuote_ver2;
using JewelQuote_ver2.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelQuote
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.ToUpper() == "ADMIN" && txtPassword.Text == "123")
            {
                FormMainMenu frm = new FormMainMenu();
                frm.Show();
                this.Hide();
            }
            else
            {
                UtilityUI.ShowInfoMsg("Invalid Login Password");
            }
        }
    }
}
