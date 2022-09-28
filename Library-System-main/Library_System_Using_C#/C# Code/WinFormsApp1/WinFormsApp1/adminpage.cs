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
    public partial class adminpage : Form
    {
        public adminpage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter sqld = new SqlDataAdapter("SELECT PRODUCTNAME,PRICE,AUTHOR,BOUGHT_QUANTITY AS Least_selling FROM PRODUCTS ORDER BY BOUGHT_QUANTITY ASC", con);
                DataTable dtbl = new DataTable();
                sqld.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter sqld = new SqlDataAdapter("SELECT distinct AUTHOR,PRODUCTNAME AS NO_UPLOADS FROM PRODUCTS WHERE  BOUGHT_QUANTITY=0", con);
                DataTable dtbl = new DataTable();
                sqld.Fill(dtbl);
                dataGridView3.DataSource = dtbl;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(numericUpDown1.Value);
            int year = Convert.ToInt32(numericUpDown2.Value);
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                con.Open();
                SqlDataAdapter sqld = new SqlDataAdapter("SELECT distinct AUTHOR,PRODUCTS.PRODUCTNAME,CART.MONTH,CART.YEAR AS No_Buyers FROM PRODUCTS,CART WHERE  BOUGHT_QUANTITY=0 and CART.MONTH = '"+ month+ "'  and CART.YEAR = '" + year + "' ", con);
                DataTable dtbl = new DataTable();
                SqlCommand number = new SqlCommand("SELECT   COUNT(distinct AUTHOR ) AS NUMBER FROM PRODUCTS WHERE BOUGHT_QUANTITY = 0");
                number.Connection = con;
                SqlDataReader rdr1 = number.ExecuteReader();
                rdr1.Read();
                label4.Text = rdr1["NUMBER"].ToString();
                sqld.Fill(dtbl);

                dataGridView2.DataSource = dtbl;
                con.Close();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter sqld = new SqlDataAdapter("select COUNT(CATEGORIES) , CATEGORIES  AS Category FROM PRODUCTS   GROUP BY CATEGORIES ORDER BY Category ASC", con);
                DataTable dtbl = new DataTable();


                sqld.Fill(dtbl);
                dataGridView4.DataSource = dtbl;
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var checkout = new checkout();
            this.Hide();
            checkout.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var Form1 = new Form1();
            this.Hide();
            Form1.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
