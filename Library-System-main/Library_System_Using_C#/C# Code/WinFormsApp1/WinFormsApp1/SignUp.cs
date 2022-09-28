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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        public static class Globals
        {

            public static string theText; // Modifiable
             
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = "";
            bool isChecked1 = radioButton1.Checked;
            bool isChecked2 = radioButton2.Checked;
            bool isChecked3 = radioButton3.Checked;
            /*SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "select ADMINUSER , READERUSER , AUTHORUSER from ADMIN , AUTHOR,READER  WHERE " +
                                         "'READERUSER ='" + textBox4.Text + "' or  ADMINUSER='"+ textBox4.Text + "'AUTHORUSER ='" + textBox4.Text + "'";


                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();*/
                if (isChecked1)
                {
                   SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True");
                   SqlCommand sqlCommand = new SqlCommand();
                   sqlCommand.Connection = sqlConnection;
                   sqlConnection.Open();
                   sqlCommand.CommandText = "insert into READER (READERNAME,READERUSER,READERPASSWD) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "')";
                   sqlCommand.ExecuteNonQuery();
                   sqlConnection.Close();
                }
                else if (isChecked3)
                {
                   SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True");
                   SqlCommand sqlCommand = new SqlCommand();
                   sqlCommand.Connection = sqlConnection;
                   sqlConnection.Open();
                   sqlCommand.CommandText = "insert into admin (ADMINNAME,ADMINUSER,ADMINPASSWD) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "')";
                   sqlCommand.ExecuteNonQuery();
                   sqlConnection.Close();
                }
                else if (isChecked2)
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "insert into AUTHOR (AUTHORNAME,AUTHORUSER,AUTHORPASSWD) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "')";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                var Form1 = new Form1();
                this.Hide();
                Form1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            ////-----------------------------------------------   
            /*SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "insert into admin (ADMINNAME,ADMINUSER,ADMINPASSWD) values('" + textBox1.Text + "','" +textBox4.Text+ "','" + textBox2.Text+"')";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            //--------------------*/
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
