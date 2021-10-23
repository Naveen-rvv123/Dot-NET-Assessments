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
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double result = double.Parse(txtFirst.Text) + double.Parse(txtSecond.Text);
            lblMsg.Text = result.ToString();
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            double result = double.Parse(txtFirst.Text) - double.Parse(txtSecond.Text);
            lblMsg.Text = result.ToString();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            double result = double.Parse(txtFirst.Text) * double.Parse(txtSecond.Text);
            lblMsg.Text = result.ToString();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if(double.Parse(txtSecond.Text) > 1)
            {
                double result = double.Parse(txtFirst.Text) / double.Parse(txtSecond.Text);
                lblMsg.Text = result.ToString();
            }
            else
            {
                lblMsg.Text = "cannot divide by 0";
            }
        }
    }
}
