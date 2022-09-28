using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public static string usr = "";
        public static string pass = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sQLconnection = new SqlConnection("Data Source=DESKTOP-M6U87QL\\MNSQLSERVER;Initial Catalog=library;Integrated Security=True");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         

            var SignUp = new SignUp();
            this.Hide();
            SignUp.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            usr = textBox1.Text;
            pass = textBox2.Text;
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select ADMINUSER from ADMIN where ADMINUSER=@ADMIN_USER ",conn1);
            cmd1.Connection = conn1;
            cmd1.Parameters.AddWithValue("@ADMIN_USER", textBox1.Text);
          
            SqlCommand cmd2 = new SqlCommand("Select ADMINPASSWD from ADMIN where ADMINPASSWD=@ADMIN_PASSWD ",conn1);
            cmd2.Connection = conn1;
            //conn1.Open();
            cmd2.Parameters.AddWithValue("@ADMIN_PASSWD", textBox2.Text);
            
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            if(rdr1.Read() && rdr2.Read())
            {
                var adminpage = new adminpage();
                this.Hide();
                adminpage.Show();
            }
            else
            {
                SqlCommand cmd3 = new SqlCommand("Select AUTHORUSER from AUTHOR where AUTHORUSER=@AUTHOR_USER ", conn1);
                cmd3.Connection = conn1;
                cmd3.Parameters.AddWithValue("@AUTHOR_USER", textBox1.Text);
                SqlCommand cmd4 = new SqlCommand("Select AUTHORPASSWD from AUTHOR where AUTHORPASSWD=@AUTHOR_PASSWD ",conn1);
                cmd4.Parameters.AddWithValue("@AUTHOR_PASSWD", textBox2.Text);
                cmd4.Connection = conn1;

                SqlDataReader rdr3 = cmd3.ExecuteReader();
                SqlDataReader rdr4 = cmd4.ExecuteReader();
                if (rdr3.Read() && rdr4.Read())
                {
                    var authorpage = new authorpage();
                    this.Hide();
                    authorpage.Show();
                }
                else
                {
                    SqlCommand cmd5 = new SqlCommand("Select READERUSER from READER where READERUSER=@READER_USER",conn1);
                    cmd5.Connection = conn1;
                    cmd5.Parameters.AddWithValue("@READER_USER", textBox1.Text);
                    SqlCommand cmd6 = new SqlCommand("Select READERPASSWD from READER where READERPASSWD=@READER_PASSWD ",conn1);
                    cmd6.Parameters.AddWithValue("@READER_PASSWD", textBox2.Text);
                    cmd6.Connection = conn1;
                    SqlDataReader rdr5 = cmd5.ExecuteReader();
                    SqlDataReader rdr6 = cmd6.ExecuteReader();
                    if (rdr5.Read() && rdr6.Read())
                    {
                        var Search = new Search();
                        this.Hide();
                        Search.Show();
                    }
                    else
                    {
                        string message = "Wrong UserName Or PassWord";
                        string title = "Title";
                        MessageBox.Show(message, title);
                    }
                }
            }

            conn1.Close();
            //---------
            /*var authorpage = new authorpage();
            this.Hide();
            authorpage.Show();*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}