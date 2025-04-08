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
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void getUser() 
        {
            string text;
            try
            {
                if
                    ((textBox1.Text != "") && (textBox2.Text != ""))
                {                    
                    string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
                    SqlConnection sqlConnection = new SqlConnection(connString);
                 
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("select ID_Player from [Players] where [Login] = '" + textBox1.Text + "' and [Password] = '" + textBox2.Text + "'", sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {            
                        text = sqlDataReader.GetValue(0).ToString();
                        MessageBox.Show("Успешный вход!");
                        Form2 form2 = new Form2(text);
                        this.Hide();
                        form2.Show();

                    }
                    else
                    {
                        MessageBox.Show("Данные не верны!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                try
                {
                    string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
                    SqlConnection sqlConnection = new SqlConnection(connString);

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("insert into [Players] values ('" + textBox1.Text + "','" + textBox2.Text + "','12.20.231.129','kljjkd@mas.com')", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    textBox1.Text = null;
                    textBox2.Text = null;

                    MessageBox.Show(" добавлена");
                }
                catch
                {
                    MessageBox.Show("Exception", "Error");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }

        }
    }
}
