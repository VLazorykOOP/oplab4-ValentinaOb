using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void datapres(SqlCommand com)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = " Error ";
            bool fieldInput = true;
            if (textBox1.Text == "")
            {
                fieldInput = false; msg += "Brand";
            }
            if (textBox2.Text == "")
            {
                fieldInput = false; msg += "Production";
            }
            if (textBox3.Text == "")
            {
                fieldInput = false; msg += "Expiration date";
            }
            if (textBox4.Text == "")
            {
                fieldInput = false; msg += "Nicotine";
            }
            if (textBox5.Text == "")
            {
                fieldInput = false; msg += "Name ";
            }
            if (textBox6.Text == "")
            {
                fieldInput = false; msg += "Price ";
            }
            if (!fieldInput)
            {
                msg += " Input Data !!! ";
                label7.Text = msg;
                return;
            }

            try
            {
                string connectstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Practice; Integrated Security = True; Connect Timeout = 30; Encrypt = False";
                
                SqlConnection con = new SqlConnection(connectstr);
                con.Open();
                string sqlQuery = "INSERT INTO cigarettes VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + textBox5.Text + "'," + textBox6.Text + ");";
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.ExecuteNonQuery();
                SqlCommand com1 = new SqlCommand("SELECT * FROM cigarettes;", con);
                datapres(com1);

                con.Close();
            }
            catch (Exception)
            {
                label7.Text = "Connect to Db";
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string msg = " Error ";
            bool fieldInput = true;
            if (textBox1.Text == "")
            {
                fieldInput = false; msg += "Brand";
            }            
            if (!fieldInput)
            {
                msg += " Input Data !!! ";
                label7.Text = msg;
                return;
            }
            try
            {
                string connectstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Practice; Integrated Security = True; Connect Timeout = 30; Encrypt = False";

                SqlConnection con = new SqlConnection(connectstr);
                con.Open();
                string sqlQuery="";

                if (textBox2.Text != "")
                {
                    sqlQuery = "UPDATE dbo.cigarettes SET production='" + textBox2.Text + "' WHERE brand='" + textBox1.Text + "';";
                }
                if (textBox3.Text != "")
                {
                    sqlQuery = "UPDATE dbo.cigarettes SET expiration_date='" + textBox3.Text + "' WHERE brand='" + textBox1.Text + "';";
                }
                if (textBox4.Text != "")
                {
                    sqlQuery = "UPDATE dbo.cigarettes SET nicotine=" + textBox4.Text + " WHERE brand='" + textBox1.Text + "';";
                }
                if (textBox5.Text != "")
                {
                    sqlQuery = "UPDATE dbo.cigarettes SET name_='" + textBox5.Text + "' WHERE brand='" + textBox1.Text + "';";
                }
                if (textBox6.Text != "")
                {
                    sqlQuery = "UPDATE dbo.cigarettes SET price=" + textBox6.Text + " WHERE brand='" + textBox1.Text + "';";   
                }
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.ExecuteNonQuery();
                SqlCommand com1 = new SqlCommand("SELECT * FROM cigarettes;", con);
                datapres(com1);

                con.Close();
            }
            catch (Exception)
            {
                label7.Text = "Connect to Db";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connectstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Practice; Integrated Security = True; Connect Timeout = 30; Encrypt = False";

                SqlConnection con = new SqlConnection(connectstr);
                con.Open();
                string sqlQuery = "SELECT * FROM cigarettes";

                if (textBox1.Text != "")
                {
                    sqlQuery = "SELECT * FROM cigarettes WHERE brand='" + textBox1.Text + "';";
                }
                if (textBox2.Text != ""){
                    sqlQuery = "SELECT * FROM cigarettes WHERE production='" + textBox2.Text + "';";
                }
                if (textBox3.Text != ""){
                    sqlQuery = "SELECT * FROM cigarettes WHERE expiration_date='" + textBox3.Text + "';";
                }
                if (textBox4.Text != ""){
                    sqlQuery = "SELECT * FROM cigarettes WHERE nicotine=" + textBox4.Text + ";";
                }
                if (textBox5.Text != ""){
                    sqlQuery = "SELECT * FROM cigarettes WHERE name_='" + textBox5.Text + "';";
                }
                if (textBox6.Text != ""){
                    sqlQuery = "SELECT * FROM cigarettes WHERE price=" + textBox6.Text + ";";
                }
                SqlCommand com = new SqlCommand(sqlQuery, con);
                datapres(com);
                con.Close();
            }
            catch (Exception)
            {
                label7.Text = "Error Connect to Db";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Practice; Integrated Security = True; Connect Timeout = 30; Encrypt = False";

                SqlConnection con = new SqlConnection(connectstr);
                con.Open();
                string sqlQuery="";

                if (textBox1.Text != "")
                {
                    sqlQuery = "DELETE FROM dbo.cigarettes WHERE brand='" + textBox1.Text + "';";
                }
                if (textBox2.Text != "")
                {
                    sqlQuery = "DELETE FROM dbo.cigarettes WHERE production='" + textBox2.Text + "';";
                }
                if (textBox3.Text != "")
                {
                    sqlQuery = "DELETE FROM dbo.cigarettes WHERE expiration_date='" + textBox3.Text + "';";
                }
                if (textBox4.Text != "")
                {
                    sqlQuery = "DELETE FROM dbo.cigarettes WHERE nicotine=" + textBox4.Text + ";";
                }
                if (textBox5.Text != "")
                {
                    sqlQuery = "DELETE FROM dbo.cigarettes WHERE name_='" + textBox5.Text + "';";
                }
                if (textBox6.Text != "")
                {
                    sqlQuery = "DELETE FROM dbo.cigarettes WHERE price=" + textBox6.Text + ";";
                }

                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.ExecuteNonQuery();
                SqlCommand com1 = new SqlCommand("SELECT * FROM cigarettes;", con);
                datapres(com1);
                con.Close();
            }
            catch (Exception)
            {
                label7.Text = "Connect to Db";
            }
        }
    }
}
