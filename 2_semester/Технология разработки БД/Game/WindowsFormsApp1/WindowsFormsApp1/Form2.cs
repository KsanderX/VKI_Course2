using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2(string text)
        {
            InitializeComponent();
            label6.Text = text;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            int i = trackBar1.Value;
            if (textBox1.Text != " " && textBox3.Text != " " && textBox4.Text != " ")
            {
                try
                {
                    string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
                    SqlConnection sqlConnection = new SqlConnection(connString);

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("insert into [Characters] values ('" + textBox1.Text + "','" + i + "','" + textBox3.Text + "','" + textBox4.Text + "','" + label6.Text + "' )", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    textBox1.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Characters] where [ID_Player] = '" + label6.Text + "'", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Characters] where ID_Player = '" + label6.Text + "' order by Nickname", sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Characters] where [ID_Player] = '" + label6.Text + "' order by [Level]", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(label6.Text);
            this.Hide();
            form3.Show();
        }
    }
}
