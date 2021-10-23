using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DataBaseApp
{
    public partial class Form1 : Form
    {

        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;database=Training;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void dgData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDissconnect_Click(object sender, EventArgs e)
        {
            string sql = "Select * from Dept";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "dept");

            dgData.DataSource = ds.Tables["dept"];
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string sql = "Select * from Emp";
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            connection.Close();

            dgData.DataSource = table;  //display data on datagrid
        }
    }
}
