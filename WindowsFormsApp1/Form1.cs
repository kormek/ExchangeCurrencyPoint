using MySql.Data.MySqlClient;
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


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
             connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Владимир\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True");

            await connection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Transactions]",connection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while(await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id"]) + "  " + Convert.ToString(sqlReader["time"]));
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),ex.Source.ToString(),MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) {
                    sqlReader.Close();
                }
            }
        }

        private void выходToolStripName()
        {
            if (connection != null && connection.State != ConnectionState.Closed) connection.Close();
        }

        private void Form1_FormClosing() {
            if (connection != null && connection.State != ConnectionState.Closed) connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Transactions]",connection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while(await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id"]) + "  " + Convert.ToString(sqlReader["time"]));  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (sqlReader != null) sqlReader.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label2.Visible == true) label2.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Transactions] (time)VALUES(@time)", connection);

                command.Parameters.AddWithValue("time", textBox1.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label2.Text = "Строка Пуста";
                label2.Visible = true;
            }

            textBox1.Clear();
            label2.Text = "Успешно добавлено";
            label2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            double i;
            if (label20.Visible == true) label20.Visible = false;
            if(!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !double.TryParse(textBox8.Text,out i))
            {
                if (!(comboBox1.SelectedIndex< 0) && 
                    !(comboBox2.SelectedIndex<0) && 
                    !(comboBox1.SelectedIndex == comboBox2.SelectedIndex))
                {
                    if (comboBox1.SelectedIndex.ToString() == "USD" && //попробовать через switch case для повышения производительности
                        comboBox3.SelectedIndex.ToString() == "BYN") {

                        printCheck(2, "USD", "EUR", 20, 18);
                    }
                    if (comboBox1.SelectedIndex.ToString() == "USD" && 
                        comboBox3.SelectedIndex.ToString() == "EUR")
                    {
                        printCheck(2, "USD", "EUR", 20, 18);
                    }
                    if (comboBox1.SelectedIndex.ToString() == "EUR" && 
                        comboBox3.SelectedIndex.ToString() == "BYN")
                    {
                        printCheck(2, "USD", "EUR", 20, 18);
                    }
                    if (comboBox1.SelectedIndex.ToString() == "EUR" && 
                        comboBox3.SelectedIndex.ToString() == "USD")
                    {
                        printCheck(2, "EUR", "USD", 20, 18);
                    }
                    if (comboBox1.SelectedIndex.ToString() == "BYN" && 
                        comboBox3.SelectedIndex.ToString() == "USD")
                    {
                        printCheck(2, "USD", "EUR", 20, 18);
                    }
                    if (comboBox1.SelectedIndex.ToString() == "BYN" && 
                        comboBox3.SelectedIndex.ToString() == "EUR")
                    {
                        printCheck(2, "USD", "EUR", 20, 18);
                    }

                }
                else
                {
                    label20.Text = "Не выбран тип валюты";
                    label20.Visible = true;
                }
            }
            else
            {
                label20.Text = "Поле не заполнено";
                label20.Visible = true;
            }
        }

        private void printCheck(int id,String currency1, String currency2,double input,
            double output,String name="Не указано",String surname="Не указано") {
            listBox2.Items.Clear();
            listBox2.Items.Add("Номер транзакции " + id.ToString());
            listBox2.Items.Add("Перевод из " + currency1 + " в " + currency2);
            listBox2.Items.Add("Вход: " + input.ToString() + " выход: " + output.ToString());
            listBox2.Items.Add("Имя " + name);
            listBox2.Items.Add("Фамилия " + surname);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex) {
                case 0:
                    if (!string.IsNullOrEmpty(textBox1.Text) //заполнена первая дата не заполнена вторая 
                        && !string.IsNullOrWhiteSpace(textBox1.Text) 
                        && string.IsNullOrEmpty(textBox13.Text)
                        && string.IsNullOrWhiteSpace(textBox13.Text)) {


                    }
                    if (string.IsNullOrEmpty(textBox1.Text) //не заполнена первая дата заполнена вторая
                        && string.IsNullOrWhiteSpace(textBox1.Text) 
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    if (!string.IsNullOrEmpty(textBox1.Text)// обе заполнены
                         && !string.IsNullOrWhiteSpace(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text)
                        ) {

                    }
                    if (string.IsNullOrEmpty(textBox1.Text)//обе не заполнены
                        && string.IsNullOrWhiteSpace(textBox1.Text)
                       && string.IsNullOrEmpty(textBox13.Text)
                        && string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(textBox1.Text)
                        && !string.IsNullOrWhiteSpace(textBox1.Text)
                        && string.IsNullOrEmpty(textBox13.Text)
                        && string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    if (string.IsNullOrEmpty(textBox1.Text)
                        && string.IsNullOrWhiteSpace(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    if (!string.IsNullOrEmpty(textBox1.Text)
                         && !string.IsNullOrWhiteSpace(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text)
                        )
                    {

                    }
                    if (string.IsNullOrEmpty(textBox1.Text)
                        && string.IsNullOrWhiteSpace(textBox1.Text)
                       && string.IsNullOrEmpty(textBox13.Text)
                        && string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(textBox1.Text)
                        && !string.IsNullOrWhiteSpace(textBox1.Text)
                        && string.IsNullOrEmpty(textBox13.Text)
                        && string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    if (string.IsNullOrEmpty(textBox1.Text)
                        && string.IsNullOrWhiteSpace(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    if (!string.IsNullOrEmpty(textBox1.Text)
                         && !string.IsNullOrWhiteSpace(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text)
                        )
                    {

                    }
                    if (string.IsNullOrEmpty(textBox1.Text)
                        && string.IsNullOrWhiteSpace(textBox1.Text)
                       && string.IsNullOrEmpty(textBox13.Text)
                        && string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    break;
                default:
                    if (!string.IsNullOrEmpty(textBox1.Text)
                        && !string.IsNullOrWhiteSpace(textBox1.Text)
                        && string.IsNullOrEmpty(textBox13.Text)
                        && string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    if (string.IsNullOrEmpty(textBox1.Text)
                        && string.IsNullOrWhiteSpace(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    if (!string.IsNullOrEmpty(textBox1.Text)
                         && !string.IsNullOrWhiteSpace(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox13.Text)
                         && !string.IsNullOrWhiteSpace(textBox13.Text)
                        )
                    {

                    }
                    if (string.IsNullOrEmpty(textBox1.Text)
                         && string.IsNullOrWhiteSpace(textBox1.Text)
                        && string.IsNullOrEmpty(textBox13.Text)
                         && string.IsNullOrWhiteSpace(textBox13.Text))
                    {

                    }
                    break;
            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
