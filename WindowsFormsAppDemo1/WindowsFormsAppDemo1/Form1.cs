using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassword.Text == "123")
            {
                lblMsg.Text = "Valid";
            }
            else if (txtUserName.Text != "admin")
            {
                lblMsg.Text = "User Name is Invalid";
            }
            else if (txtPassword.Text != "admin")
            {
                lblMsg.Text = "Password is Invalid";
            }
        }
    }
}
