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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;  


namespace Praktika
{
    public partial class Form1 : Form

    {
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;
        private MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user=root;password=root;database=судоходство");
        private MySqlCommand command;
        private MySqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();
            connection.Open();
            updateData();
        }
        private void updateData()
        {
            command = new MySqlCommand("SELECT * FROM `osnova`", connection);
            adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Номер= textBox1.Text;
            string Тип = textBox2.Text;
            string Наименование = textBox3.Text;
            string Количество = textBox4.Text;

            string quary = "INSERT INTO информ(Номер, Тип, Наименование, Количество) VALUES (@Номер, @Тип, @Наименование, @Количество)";

            var command = new MySqlCommand(quary, connection);
            command.Parameters.AddWithValue("@Номер", Номер);
            command.Parameters.AddWithValue("@Тип", Тип);
            command.Parameters.AddWithValue("@Наименование", Наименование);
            command.Parameters.AddWithValue("@Количество", Количество);
            command.ExecuteNonQuery();

            try
            {
                MessageBox.Show("Данные обновлены.");
                string queryy = "SELECT * FROM osnova";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(queryy, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            string Номер = textBox5.Text;

            string quary = "DELETE FROM информ WHERE Номер = @Номер";

            var command = new MySqlCommand(quary, connection);
            command.Parameters.AddWithValue("@Номер", Номер);
            
            command.ExecuteNonQuery();

            try
            {
                MessageBox.Show("Данные удалены.");
                string queryy = "select * from osnova";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(queryy, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        
            {
                string id = textBox6.Text;
                string dt = textBox7.Text;

                string quary = "INSERT INTO data_postavki (id, dt) VALUES (@id, @dt) ON DUPLICATE KEY UPDATE id = @id, dt = @dt;";


                var command = new MySqlCommand(quary, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@dt", dt);
                command.ExecuteNonQuery();

                try
                {
                    MessageBox.Show("Данные обновлены.");
                    string queryy = "select * from Data_postavki";
                    mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(queryy, connection);
                    DataTable table = new DataTable();
                    mySqlDataAdapter.Fill(table);
                    dataGridView1.DataSource = new BindingSource(table, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string queryy = "SELECT * FROM Data_postavki";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(queryy, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string queryy = "SELECT * FROM osnova";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(queryy, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удачи!");
            this.Close();
        }
    }
}

