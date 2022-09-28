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
    public partial class authorpage : Form
    {
        public authorpage()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form1 = new Form1();
            this.Hide();
            Form1.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            bool book = radioButton1.Checked;
            bool magazine = radioButton3.Checked;
            bool comic_book = radioButton2.Checked;
            bool research = radioButton4.Checked;
            //------
            if (book)
            {
                SqlConnection conn1= new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("Select AUTHORID from AUTHOR where AUTHORID=@AUTHOR_ID",conn1);
                cmd1.Connection = conn1;
                cmd1.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                int author_id = Int32.Parse(textBox2.Text);
 

                SqlDataReader rdr1 = cmd1.ExecuteReader();
                if(rdr1.Read())
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE AUTHOR SET NUMBOOK = NUMBOOK + 1 where AUTHORID = @AUTHOR_ID", conn1);
                    cmd2.Connection = conn1;
                    cmd2.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                    SqlDataReader random_rdr = cmd2.ExecuteReader();

                    SqlCommand cmd3 = new SqlCommand("insert into PRODUCTS(PRODUCTNAME,TYPE,AUTHORID,YEAR,NUMPAGES,PRICE,AUTHOR,CATEGORIES,BOUGHT_QUANTITY) values(@PRODUCT_NAME, 'book', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES,0) insert into BOOK(PRODUCTNAME, TYPE, AUTHORID, YEAR, NUMPAGES, PRICE, AUTHOR, CATEGORIES, BOOKLANG, AVAILABLEBOOK) values(@PRODUCT_NAME, 'book', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES,@BOOKLANG,@AVAILABLEBOOK)", conn1);
                   //SqlCommand cmd4 = new SqlCommand();
                    cmd3.Connection = conn1;
                    cmd3.Parameters.AddWithValue("@PRODUCT_NAME", textBox1.Text);
                    cmd3.Parameters.AddWithValue("@NUMPAGES", numericUpDown2.Value);
                    cmd3.Parameters.AddWithValue("@AUTHORID", textBox2.Text);
                    cmd3.Parameters.AddWithValue("@PRICE", numericUpDown3.Value);
                    cmd3.Parameters.AddWithValue("@AUTHOR", textBox5.Text);
                    cmd3.Parameters.AddWithValue("@CATEGORIES", textBox3.Text);
                    cmd3.Parameters.AddWithValue("@BOOKLANG", textBox4.Text);
                    cmd3.Parameters.AddWithValue("@AVAILABLEBOOK", numericUpDown4.Value);
                    cmd3.Parameters.AddWithValue("@YEAR", numericUpDown1.Value);
                    SqlDataReader randomrdr = cmd3.ExecuteReader();

                }

                conn1.Close();
                string message = "Uploaded Successfully";
                string title = "MSG";
                MessageBox.Show(message, title);
            }
            if (magazine)
            {
                SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("Select AUTHORID from AUTHOR where AUTHORID=@AUTHOR_ID", conn1);
                cmd1.Connection = conn1;
                cmd1.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                int author_id = Int32.Parse(textBox2.Text);


                SqlDataReader rdr1 = cmd1.ExecuteReader();
                if (rdr1.Read())
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE AUTHOR SET NUMBOOK = NUMBOOK + 1 where AUTHORID = @AUTHOR_ID", conn1);
                    cmd2.Connection = conn1;
                    cmd2.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                    SqlDataReader random_rdr = cmd2.ExecuteReader();

                    SqlCommand cmd3 = new SqlCommand("insert into PRODUCTS(PRODUCTNAME,TYPE,AUTHORID,YEAR,NUMPAGES,PRICE,AUTHOR,CATEGORIES,BOUGHT_QUANTITY) values(@PRODUCT_NAME, 'magazine', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES,0) insert into MAGAZINE(PRODUCTNAME, TYPE, AUTHORID, YEAR, NUMPAGES, PRICE, AUTHOR, CATEGORIES, AVAILABLEMAGAZINE,MAGAZINELANG) values(@PRODUCT_NAME, 'magazine', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES,@AVAILABLEMAGAZINE,@MAGLANG)", conn1);
                    //SqlCommand cmd4 = new SqlCommand();
                    cmd3.Connection = conn1;
                    cmd3.Parameters.AddWithValue("@PRODUCT_NAME", textBox1.Text);
                    cmd3.Parameters.AddWithValue("@NUMPAGES", numericUpDown2.Value);
                    cmd3.Parameters.AddWithValue("@AUTHORID", textBox2.Text);
                    cmd3.Parameters.AddWithValue("@PRICE", numericUpDown3.Value);
                    cmd3.Parameters.AddWithValue("@AUTHOR", textBox5.Text);
                    cmd3.Parameters.AddWithValue("@CATEGORIES", textBox3.Text);
                    cmd3.Parameters.AddWithValue("@MAGLANG", textBox4.Text);
                    cmd3.Parameters.AddWithValue("@AVAILABLEMAGAZINE", numericUpDown4.Value);
                    cmd3.Parameters.AddWithValue("@YEAR", numericUpDown1.Value);
                    SqlDataReader randomrdr = cmd3.ExecuteReader();
                }
                conn1.Close();
                string message = "Uploaded Successfully";
                string title = "MSG";
                MessageBox.Show(message, title);
            }
            if (comic_book)
            {
                SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("Select AUTHORID from AUTHOR where AUTHORID=@AUTHOR_ID", conn1);
                cmd1.Connection = conn1;
                cmd1.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                int author_id = Int32.Parse(textBox2.Text);


                SqlDataReader rdr1 = cmd1.ExecuteReader();
                if (rdr1.Read())
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE AUTHOR SET NUMBOOK = NUMBOOK + 1 where AUTHORID = @AUTHOR_ID", conn1);
                    cmd2.Connection = conn1;
                    cmd2.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                    SqlDataReader random_rdr = cmd2.ExecuteReader();

                    SqlCommand cmd3 = new SqlCommand("insert into PRODUCTS(PRODUCTNAME,TYPE,AUTHORID,YEAR,NUMPAGES,PRICE,AUTHOR,CATEGORIES,BOUGHT_QUANTITY) values(@PRODUCT_NAME, 'comic_book', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES,0) insert into COMICBOOK(PRODUCTNAME, TYPE, AUTHORID, YEAR, NUMPAGES, PRICE, AUTHOR, CATEGORIES, AVAILABLECOMIC,COMICLANG) values(@PRODUCT_NAME, 'comic_book', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES ,@AVAILABLECOMIC,@COMICLANG)", conn1);
                    //SqlCommand cmd4 = new SqlCommand();
                    cmd3.Connection = conn1;
                    cmd3.Parameters.AddWithValue("@PRODUCT_NAME", textBox1.Text);
                    cmd3.Parameters.AddWithValue("@NUMPAGES", numericUpDown2.Value);
                    cmd3.Parameters.AddWithValue("@AUTHORID", textBox2.Text);
                    cmd3.Parameters.AddWithValue("@PRICE", numericUpDown3.Value);
                    cmd3.Parameters.AddWithValue("@AUTHOR", textBox5.Text);
                    cmd3.Parameters.AddWithValue("@CATEGORIES", textBox3.Text);
                    cmd3.Parameters.AddWithValue("@COMICLANG", textBox4.Text);
                    cmd3.Parameters.AddWithValue("@AVAILABLECOMIC", numericUpDown4.Value);
                    cmd3.Parameters.AddWithValue("@YEAR", numericUpDown1.Value);
                    SqlDataReader randomrdr = cmd3.ExecuteReader();
                }
                conn1.Close();
                string message = "Uploaded Successfully";
                string title = "MSG";
                MessageBox.Show(message, title);
            }
            if(research)
            {
                SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("Select AUTHORID from AUTHOR where AUTHORID=@AUTHOR_ID", conn1);
                cmd1.Connection = conn1;
                cmd1.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                int author_id = Int32.Parse(textBox2.Text);


                SqlDataReader rdr1 = cmd1.ExecuteReader();
                if (rdr1.Read())
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE AUTHOR SET NUMBOOK = NUMBOOK + 1 where AUTHORID = @AUTHOR_ID", conn1);
                    cmd2.Connection = conn1;
                    cmd2.Parameters.AddWithValue("@AUTHOR_ID", textBox2.Text);
                    SqlDataReader random_rdr = cmd2.ExecuteReader();

                    SqlCommand cmd3 = new SqlCommand("insert into PRODUCTS(PRODUCTNAME,TYPE,AUTHORID,YEAR,NUMPAGES,PRICE,AUTHOR,CATEGORIES,BOUGHT_QUANTITY) values(@PRODUCT_NAME, 'research_paper', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES,0) insert into RESEARCHPAPERS(PRODUCTNAME, TYPE, AUTHORID, YEAR, NUMPAGES, PRICE, AUTHOR, CATEGORIES, AVAILABLERESEARCH,RESEARCHLANG) values(@PRODUCT_NAME, 'research_paper', @AUTHORID, @YEAR, @NUMPAGES, @PRICE, @AUTHOR, @CATEGORIES ,@AVAILABLERES,@RESLANG)", conn1);
                    //SqlCommand cmd4 = new SqlCommand();
                    cmd3.Connection = conn1;
                    cmd3.Parameters.AddWithValue("@PRODUCT_NAME", textBox1.Text);
                    cmd3.Parameters.AddWithValue("@NUMPAGES", numericUpDown2.Value);
                    cmd3.Parameters.AddWithValue("@AUTHORID", textBox2.Text);
                    cmd3.Parameters.AddWithValue("@PRICE", numericUpDown3.Value);
                    cmd3.Parameters.AddWithValue("@AUTHOR", textBox5.Text);
                    cmd3.Parameters.AddWithValue("@CATEGORIES", textBox3.Text);
                    cmd3.Parameters.AddWithValue("@RESLANG", textBox4.Text);
                    cmd3.Parameters.AddWithValue("@AVAILABLERES", numericUpDown4.Value);
                    cmd3.Parameters.AddWithValue("@YEAR", numericUpDown1.Value);
                    SqlDataReader randomrdr = cmd3.ExecuteReader();
                }
                conn1.Close();
                string message = "Uploaded Successfully";
                string title   = "MSG";
                MessageBox.Show(message, title);
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

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

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void authorpage_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
