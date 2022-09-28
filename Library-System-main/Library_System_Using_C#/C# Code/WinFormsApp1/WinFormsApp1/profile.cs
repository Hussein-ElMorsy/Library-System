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
    public partial class profile : Form
    {
        public profile( )
        {
            InitializeComponent();
            label8.Text = Form1.usr;
            label9.Text = Form1.pass;
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select READERNAME from READER where READERUSER='"+ Form1.usr + "' ", conn1);
            cmd1.Connection = conn1;
             

            SqlDataReader rdr1 = cmd1.ExecuteReader();
            rdr1.Read();
            label7.Text = rdr1["READERNAME"].ToString();
            
            //------------
            SqlCommand cmd2 = new SqlCommand("Select BOUGHTBOOKS from READER where READERUSER='" + Form1.usr + "' ", conn1);
            cmd2.Connection = conn1;
        

            SqlDataReader rdr2 = cmd2.ExecuteReader();
            rdr2.Read();
            label11.Text = rdr2["BOUGHTBOOKS"].ToString();
            conn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var update = new update();
            this.Hide();
            update.Show();
        }

        private void profile_Load(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
