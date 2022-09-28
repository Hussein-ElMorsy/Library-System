using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class checkout : Form
    {
        public checkout()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkout_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var adminpage = new adminpage();
            this.Hide();
            adminpage.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkout_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter sqld = new SqlDataAdapter("select PRODUCTNAME , BOUGHT_QUANTITY , PRICE from PRODUCTS  WHERE BOUGHT_QUANTITY > 0", con);
                DataTable dtbl = new DataTable();
                sqld.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}
