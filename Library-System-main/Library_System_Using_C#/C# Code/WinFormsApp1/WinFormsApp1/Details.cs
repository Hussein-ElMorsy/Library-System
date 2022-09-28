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
    
    public partial class Details : Form
    {
        public static int q;
        public Details()
        {
            InitializeComponent();
            label8.Text = Search.search_res;
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT PRODUCTNAME,AUTHOR,YEAR,PRICE,CATEGORIES from PRODUCTS where PRODUCTNAME = '" + Search.search_res + "' ", conn1);
            cmd1.Connection = conn1;
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            /*if (!rdr1.Read())
            {
                string message = "Item Not Found";
                string title = "MSG";
                MessageBox.Show(message, title);
            }*/
            rdr1.Read();
            label8.Text = rdr1["PRODUCTNAME"].ToString();
       
            label9.Text = rdr1["AUTHOR"].ToString();
   
            label10.Text = rdr1["YEAR"].ToString();
          
            label11.Text = rdr1["PRICE"].ToString();
          
            label12.Text = rdr1["CATEGORIES"].ToString();
            
            SqlCommand bookcmd1 = new SqlCommand("SELECT AVAILABLEBOOK,BOOKLANG from BOOK where PRODUCTNAME = '" + Search.search_res + "' ", conn1);
            bookcmd1.Connection = conn1;
            SqlDataReader bookrdr1 = bookcmd1.ExecuteReader();
            if (bookrdr1.Read())
            {
               
                label13.Text = bookrdr1["AVAILABLEBOOK"].ToString();
                
                label14.Text = bookrdr1["BOOKLANG"].ToString();
            }
            else
            {
                SqlCommand comic_bookcmd1 = new SqlCommand("SELECT AVAILABLECOMIC,COMICLANG from COMICBOOK where PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                comic_bookcmd1.Connection = conn1;
                SqlDataReader comic_bookrdr1 = comic_bookcmd1.ExecuteReader();
                if (comic_bookrdr1.Read())
                {
                 
                    label13.Text = comic_bookrdr1["AVAILABLECOMIC"].ToString();
                  
                    label14.Text = comic_bookrdr1["COMICLANG"].ToString();
                }
                else
                {
                    SqlCommand magazine_cmd1 = new SqlCommand("SELECT AVAILABLEMAGAZINE,MAGAZINELANG from MAGAZINE where PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                    magazine_cmd1.Connection = conn1;
                    SqlDataReader magazine_rdr1 = magazine_cmd1.ExecuteReader();
                    if (magazine_rdr1.Read())
                    {
                         
                        label13.Text = magazine_rdr1["AVAILABLEMAGAZINE"].ToString();
                       
                        label14.Text = magazine_rdr1["MAGAZINELANG"].ToString();
                    }
                    else
                    {
                        SqlCommand research_cmd1 = new SqlCommand("SELECT AVAILABLERESEARCH,RESEARCHLANG from RESEARCHPAPERS where PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                        research_cmd1.Connection = conn1;
                        SqlDataReader research_rdr1 = research_cmd1.ExecuteReader();
                        if (research_rdr1.Read())
                        {
                             
                            label13.Text = research_rdr1["AVAILABLERESEARCH"].ToString();
                            
                            label14.Text = research_rdr1["RESEARCHLANG"].ToString();
                        }
                    }
                }
            }
            conn1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Search = new Search();
            this.Hide();
            Search.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            q = Convert.ToInt32(numericUpDown1.Value);
            int month = Convert.ToInt32(numericUpDown3.Value);
            int year = Convert.ToInt32(numericUpDown2.Value);
            //Search.search_res
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-M6U87QL\MNSQLSERVER;Initial Catalog=library;Integrated Security=True;MultipleActiveResultSets=true");
            conn1.Open();

            SqlCommand bookcmd1 = new SqlCommand("UPDATE BOOK SET AVAILABLEBOOK = AVAILABLEBOOK - '" + q + "' WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
            bookcmd1.Connection = conn1;
            SqlDataReader bookrdr1 = bookcmd1.ExecuteReader();
            
            SqlCommand select1 = new SqlCommand("SELECT PRICE FROM BOOK WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
            select1.Connection = conn1;
            SqlDataReader rdr = select1.ExecuteReader();
            if(rdr.Read())
            {
                double PRICE = 0;
                PRICE = (double)rdr["PRICE"];
                double total_price = q * PRICE;
                string message = "total price : '" + total_price + "'";
                string title = "MSG";
                MessageBox.Show(message, title);

                SqlCommand usercmd = new SqlCommand(" UPDATE READER set BOUGHTBOOKS = BOUGHTBOOKS+ '"+q+"' where READERUSER = '" +Form1.usr+ "' ", conn1);
                usercmd.Connection = conn1;
                SqlDataReader userrdr = usercmd.ExecuteReader();

                SqlCommand qu1 = new SqlCommand("UPDATE PRODUCTS SET BOUGHT_QUANTITY = BOUGHT_QUANTITY + '"+q+"' WHERE PRODUCTNAME ='"+ Search.search_res + "';", conn1);
                qu1.Connection = conn1;
                SqlDataReader rdrquan = qu1.ExecuteReader();

                SqlCommand insert1 = new SqlCommand("insert into CART (PRODUCTNAME,QUANTITY,TOTAL_PRICE,MONTH,YEAR) values ('" + Search.search_res + "' ,'" + q + "' , '" + total_price + "' , '"+month+"','"+year+"' )", conn1);
                insert1.Connection = conn1;
                SqlDataReader rdr1 = insert1.ExecuteReader();
            }
           
           else 
            {
                ///------------------------------------------------------------------------------------------  

                SqlCommand comicbookcmd1 = new SqlCommand("UPDATE COMICBOOK SET AVAILABLECOMIC = AVAILABLECOMIC - '" + q + "' WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                comicbookcmd1.Connection = conn1;
                SqlDataReader comicbookrdr1 = comicbookcmd1.ExecuteReader();

                SqlCommand select2 = new SqlCommand("SELECT PRICE FROM COMICBOOK WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                select2.Connection = conn1;
                SqlDataReader rdr2 = select2.ExecuteReader();
                if(rdr2.Read())
                {
                    double comic_PRICE = 0.0;
                    comic_PRICE = (double)rdr2["PRICE"];
                    double total_price_comic = q * comic_PRICE;
                    string message1 = "total price : '" + total_price_comic + "'";
                    string title1 = "MSG";
                    MessageBox.Show(message1, title1);

                    SqlCommand usercmd = new SqlCommand(" UPDATE READER set BOUGHTBOOKS = BOUGHTBOOKS+ '" + q + "' where READERUSER = '" + Form1.usr + "' ", conn1);
                    usercmd.Connection = conn1;
                    SqlDataReader userrdr = usercmd.ExecuteReader();


                    SqlCommand qu1 = new SqlCommand("UPDATE PRODUCTS SET BOUGHT_QUANTITY = BOUGHT_QUANTITY + '" + q + "' WHERE PRODUCTNAME ='" + Search.search_res + "';", conn1);
                    qu1.Connection = conn1;
                    SqlDataReader rdrquan = qu1.ExecuteReader();

                    SqlCommand insert2 = new SqlCommand("insert into CART (PRODUCTNAME,QUANTITY,TOTAL_PRICE,MONTH,YEAR) values ('" + Search.search_res + "' ,'" + q + "' , '" + total_price_comic + "', '" + month + "','" + year + "')", conn1);
                    insert2.Connection = conn1;
                    SqlDataReader rdr22 = insert2.ExecuteReader();
                }
                
                else
                {
                    //-----------------------------------------------------------------------------------------
                    SqlCommand magazinecmd1 = new SqlCommand("UPDATE MAGAZINE SET AVAILABLEMAGAZINE = AVAILABLEMAGAZINE - '" + q + "' WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                    magazinecmd1.Connection = conn1;
                    SqlDataReader magazinerdr1 = magazinecmd1.ExecuteReader();

                    SqlCommand select3 = new SqlCommand("SELECT PRICE FROM MAGAZINE WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                    select3.Connection = conn1;
                    SqlDataReader rdr3 = select3.ExecuteReader();
                    if(rdr3.Read())
                    {
                        double m_PRICE = 0.0;
                        m_PRICE = (double)rdr3["PRICE"];
                        double total_price__ = q * m_PRICE;
                        string message2 = "total price : '" + total_price__ + "'";
                        string title2 = "MSG";
                        MessageBox.Show(message2, title2);

                        SqlCommand usercmd = new SqlCommand(" UPDATE READER set BOUGHTBOOKS = BOUGHTBOOKS+ '" + q + "' where READERUSER = '" + Form1.usr + "' ", conn1);
                        usercmd.Connection = conn1;
                        SqlDataReader userrdr = usercmd.ExecuteReader();

                        SqlCommand qu1 = new SqlCommand("UPDATE PRODUCTS SET BOUGHT_QUANTITY = BOUGHT_QUANTITY + '" + q + "' WHERE PRODUCTNAME ='" + Search.search_res + "';", conn1);
                        qu1.Connection = conn1;
                        SqlDataReader rdrquan = qu1.ExecuteReader();

                        SqlCommand insert3 = new SqlCommand("insert into CART (PRODUCTNAME,QUANTITY,TOTAL_PRICE,MONTH,YEAR) values ('" + Search.search_res + "' ,'" + q + "' , '" + total_price__ + "', '" + month + "','" + year + "')", conn1);
                        insert3.Connection = conn1;
                        SqlDataReader rdr33 = insert3.ExecuteReader();
                    }
                  
                    else
                    {
                        ///---------------------------------------------------------------------------------------------
                        SqlCommand researchcmd1 = new SqlCommand("UPDATE RESEARCHPAPERS SET AVAILABLERESEARCH = AVAILABLERESEARCH - '" + q + "' WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                        researchcmd1.Connection = conn1;
                        SqlDataReader rdrcmd4 = researchcmd1.ExecuteReader();

                        SqlCommand select4 = new SqlCommand("SELECT PRICE FROM RESEARCHPAPERS WHERE PRODUCTNAME = '" + Search.search_res + "' ", conn1);
                        select4.Connection = conn1;
                        SqlDataReader rdr4 = select4.ExecuteReader();
                        rdr4.Read();
                        double r_PRICE = (double)rdr4["PRICE"];
                        double total_price__r = q * r_PRICE;
                        string message3 = "total price : '" + total_price__r + "'";
                        string title3 = "MSG";
                        MessageBox.Show(message3, title3);

                        SqlCommand usercmd = new SqlCommand(" UPDATE READER set BOUGHTBOOKS = BOUGHTBOOKS+ '" + q + "' where READERUSER = '" + Form1.usr + "' ", conn1);
                        usercmd.Connection = conn1;
                        SqlDataReader userrdr = usercmd.ExecuteReader();

                        SqlCommand qu1 = new SqlCommand("UPDATE PRODUCTS SET BOUGHT_QUANTITY = BOUGHT_QUANTITY + '" + q + "' WHERE PRODUCTNAME ='" + Search.search_res + "';", conn1);
                        qu1.Connection = conn1;
                        SqlDataReader rdrquan = qu1.ExecuteReader();

                        SqlCommand insert4 = new SqlCommand("insert into CART (PRODUCTNAME,QUANTITY,TOTAL_PRICE,MONTH,YEAR) values ('" + Search.search_res + "' ,'" + q + "' , '" + total_price__r + "' , '" + month + "','" + year + "')", conn1);
                        insert4.Connection = conn1;
                        SqlDataReader rdr44 = insert4.ExecuteReader();
                    }
                }
            }
            
            









            conn1.Close();

            
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
