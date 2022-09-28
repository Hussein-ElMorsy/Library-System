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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Search = new Search();
            this.Hide();
            Search.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
            conn1.Open();
             
            SqlCommand cmd3 = new SqlCommand("UPDATE READER SET READERUSER = @new_user , READERPASSWD = @newpass WHERE READERUSER = @old_user;", conn1);
            //SqlCommand cmd4 = new SqlCommand();
            cmd3.Connection = conn1;
            cmd3.Parameters.AddWithValue("@new_user", textBox2.Text);
            cmd3.Parameters.AddWithValue("@newpass", textBox5.Text);
            cmd3.Parameters.AddWithValue("@old_user", textBox4.Text);
            SqlDataReader randomrdr = cmd3.ExecuteReader();
            conn1.Close();


            string message = "Updated Successfully";
            string title = "MSG";
            MessageBox.Show(message, title);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
