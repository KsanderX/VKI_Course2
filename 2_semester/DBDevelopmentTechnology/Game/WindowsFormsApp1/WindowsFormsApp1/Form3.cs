using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3(string text)
        {
            InitializeComponent();   
            label1.Text = text;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(label1.Text);
            this.Hide();
            form2.Show();

        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT [Nickname],[Characters].[Level],[Origin],[Sex] FROM [PositionCharacter],[Characters],[Locations] where [Locations].ID = 1 and [ID_Player] = '" + label1.Text + "' and [PositionCharacter].ID_character = [Characters].ID and [PositionCharacter].ID_location = [Locations].ID", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataSet = new DataTable();
            DataTable dataSet1 = new DataTable();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            sqlCommand.CommandText = "SELECT [Features],[dbo].[Enemy].[Level] FROM [Enemy],[PositionEnemy],[Locations] where [Locations].ID = 1 and [PositionEnemy].ID_enemy = [Enemy].ID and [Locations].ID = [PositionEnemy].ID_location";
            sqlDataAdapter.Fill(dataSet1);
            dataGridView2.DataSource = dataSet1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT [Nickname],[Characters].[Level],[Origin],[Sex] FROM [PositionCharacter],[Characters],[Locations] where [Locations].ID = 2 and [ID_Player] = '" + label1.Text + "' and [PositionCharacter].ID_character = [Characters].ID and [PositionCharacter].ID_location = [Locations].ID", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataSet = new DataTable();
            DataTable dataSet1 = new DataTable();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;

            sqlCommand.CommandText = "SELECT [Features],[dbo].[Enemy].[Level] FROM [Enemy],[PositionEnemy],[Locations] where [Locations].ID = 2 and [PositionEnemy].ID_enemy = [Enemy].ID and [Locations].ID = [PositionEnemy].ID_location";
            sqlDataAdapter.Fill(dataSet1);
            dataGridView2.DataSource = dataSet1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT [Nickname],[Characters].[Level],[Origin],[Sex] FROM [PositionCharacter],[Characters],[Locations] where [Locations].ID = 3 and [ID_Player] = '" + label1.Text + "' and [PositionCharacter].ID_character = [Characters].ID and [PositionCharacter].ID_location = [Locations].ID", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataSet = new DataTable();
            DataTable dataSet1 = new DataTable();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            sqlCommand.CommandText = "SELECT [Features],[dbo].[Enemy].[Level] FROM [Enemy],[PositionEnemy],[Locations] where [Locations].ID = 3 and [PositionEnemy].ID_enemy = [Enemy].ID and [Locations].ID = [PositionEnemy].ID_location";
            sqlDataAdapter.Fill(dataSet1);
            dataGridView2.DataSource = dataSet1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DBSRV\vip2024; Initial Catalog = Aganichev_Game; Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT [Nickname],[Characters].[Level],[Origin],[Sex] FROM [PositionCharacter],[Characters],[Locations] where [Locations].ID = 2 and [id_player] = '" + label1.Text + "' and [PositionCharecter].id_character = [Characters].ID and [PositionCharecter].id_location = [Locations].ID", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataSet = new DataTable();
            DataTable dataSet1 = new DataTable();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            sqlCommand.CommandText = "SELECT [Features],[dbo].[Enemy].[Level] FROM [Enemy],[PositionEnemy],[Locations] where [Locations].ID = 2 and [PositionEnemy].id_enemy = [Enemy].ID and [Locations].ID = [PositionEnemy].id_location";
            sqlDataAdapter.Fill(dataSet1);
            dataGridView2.DataSource = dataSet1;
        }
    }
}
