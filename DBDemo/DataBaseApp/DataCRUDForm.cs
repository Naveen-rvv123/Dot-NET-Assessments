using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLibrary;
using DataLibrary.cs;

namespace DataBaseApp
{
    public partial class DataCRUDForm : Form
    {
        EmpDataStore dataStore = new EmpDataStore(@"server=(localdb)\MSSQLLocalDB; database=Training; Integrated Security=True");
        public DataCRUDForm()
        {
            InitializeComponent();
        }

        private void DataCRUDForm_Load(object sender, EventArgs e)
        {
            dgData.DataSource = dataStore.GetEmps();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Emp newEmp = new Emp();
                newEmp.EmpNo = int.Parse(txtEmpNo.Text);
                newEmp.EmpName = txtEmpName.Text;
                newEmp.HireDate = Convert.ToDateTime(txtHDate.Text);
                newEmp.Salary = decimal.Parse(txtSalary.Text);

                int count = dataStore.AddEmp(newEmp);

                if(count==1)
                {
                    MessageBox.Show("Record inserted");
                    dgData.DataSource = dataStore.GetEmps();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmpNo.Clear();
            txtEmpName.Clear();
            txtHDate.Clear();
            txtSalary.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Emp empList = new Emp();
                empList.EmpNo = int.Parse(txtEmpNo.Text);
                empList.EmpName = txtEmpName.Text;
                empList.HireDate = Convert.ToDateTime(txtHDate.Text);
                empList.Salary = decimal.Parse(txtSalary.Text);

                int count = dataStore.EditEmps(empList);

                if (count == 1)
                {
                    MessageBox.Show($"Empno {txtEmpNo.Text} is edited");
                    dgData.DataSource = dataStore.GetEmps();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpNo.Text == "")
                {
                    return;
                }
                else
                {
                    int empid = int.Parse(txtEmpNo.Text);
                    int count = dataStore.delEmps(empid);

                    if (count == 1)
                    {
                        MessageBox.Show($"{txtEmpNo.Text} is deleted");
                        dgData.DataSource = dataStore.GetEmps();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text ==string.Empty)
            {
                return;
            }
            try
            {
                int empno = int.Parse(txtEmpNo.Text);
                Emp emp = dataStore.GetEmpByNo(empno);

                if (emp != null)
                {
                    txtEmpName.Text = emp.EmpName;
                }
                else
                {
                    MessageBox.Show($"Emplypoyee by no {empno} not found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
