using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        SqlConnection connection;
        Currency[] currencies = new Currency[3];
        


        public Form1()
        {
            InitializeComponent();
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
           // Currency[] currencies = new Currency[3];
            currencies[0] = new Currency("USD");
            currencies[1] = new Currency("EUR");
            currencies[2] = new Currency("BYN");
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            label21.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Владимир\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True");

            await connection.OpenAsync();

           

            Thread thread = new Thread(async () => {
                while(connection.State != ConnectionState.Closed)
                {
                    SqlDataReader sqlReader1 = null;

                    SqlCommand command4 = new SqlCommand("select * from [Restrictions] where Currency = 'USD' ", connection);
                    SqlCommand command6 = new SqlCommand("select * from [Restrictions] where Currency = 'BYN' ", connection);
                    SqlCommand command5 = new SqlCommand("select * from [Restrictions] where  Currency = 'EUR'", connection);
                    SqlCommand command1 = new SqlCommand("select * from [CurrencyOne] where id = (select MAX(id) from [CurrencyOne])", connection);
                    SqlCommand command2 = new SqlCommand("select * from [CurrencyTwo] where id = (select MAX(id) from [CurrencyTwo])", connection);

                    try
                    {
                        sqlReader1 = await command1.ExecuteReaderAsync();
                       

                        while (sqlReader1.Read())
                        {
                           
                            textBox2.Text = Convert.ToString(sqlReader1.GetValue(3));
                            textBox7.Text = Convert.ToString(sqlReader1.GetValue(4));
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader1 != null)
                        {
                            sqlReader1.Close();
                        }
                        
                    }


                    //Обновление EUR

                    try
                    {
                        sqlReader1 = await command2.ExecuteReaderAsync();


                        while (sqlReader1.Read())
                        {
                            
                            textBox3.Text = Convert.ToString(sqlReader1.GetValue(3));
                            textBox6.Text = Convert.ToString(sqlReader1.GetValue(4));
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader1 != null)
                        {
                            sqlReader1.Close();
                        }

                    }
                    

                    try
                    {
                        sqlReader1 = await command4.ExecuteReaderAsync();

                        
                        while (sqlReader1.Read())
                        {
                            
                            label21.Text = (sqlReader1.GetValue(4).ToString() == "true      ").ToString();
                            if (sqlReader1.GetValue(4).ToString() == "true      ")
                            {
                                currencies[0].setRestricted(true);
                                currencies[0].set_amount(Convert.ToDouble(sqlReader1.GetValue(3)));
                                label21.Text = "Включено ограничение на покупку USD " + currencies[0].get_amount().ToString() + " ед.";
                                label21.Visible = true;
                                
                            }
                            else
                            {
                                currencies[0].setRestricted(false);
                                label21.Text = "Нет ограничений";
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader1 != null)
                        {
                            sqlReader1.Close();
                        }

                    }

                    try
                    {
                        sqlReader1 = command5.ExecuteReader();

                        //label22.Text = "z2";
                        //label22.Visible = true;
                        while (sqlReader1.Read())
                        {

                            //label22.Text = (sqlReader1.GetValue(4).ToString() == "true      ").ToString();
                            if (sqlReader1.GetValue(4).ToString() == "true      ")
                            {
                                currencies[1].setRestricted(true);
                                currencies[1].set_amount(Convert.ToDouble(sqlReader1.GetValue(3)));
                                label22.Text = "Включено ограничение на покупку  EUR" + currencies[1].get_amount().ToString() + " ед.";
                                label22.Visible = true;

                            }
                            else
                            {
                                currencies[1].setRestricted(false);
                                label22.Text = "Нет ограничений";
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader1 != null)
                        {
                            sqlReader1.Close();
                        }

                    }


                    try
                    {
                        sqlReader1 = await command6.ExecuteReaderAsync();


                        while (sqlReader1.Read())
                        {

                            ; label21.Text = (sqlReader1.GetValue(4).ToString() == "true      ").ToString();
                            if (sqlReader1.GetValue(4).ToString() == "true      ")
                            {
                                currencies[2].setRestricted(true);
                                currencies[2].set_amount(Convert.ToDouble(sqlReader1.GetValue(3)));
                                label23.Text = "Включено ограничение на покупку BYN " + currencies[2].get_amount().ToString() + " ед.";
                                label23.Visible = true;

                            }
                            else
                            {
                                currencies[2].setRestricted(false);
                                label23.Text = "Нет ограничений";
                            }
                           
                        }
                        if (sqlReader1.Read()) { label23.Text = "Нет ограничений"; }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader1 != null)
                        {
                            sqlReader1.Close();
                        }

                    }


                    Thread.Sleep(3000);
                   
                }
            });
            thread.Start();

            /*Thread thread1 = new Thread(async () => {
                while (connection.State != ConnectionState.Closed)
                {
                    SqlDataReader sqlReader2 = null;

                    

                     SqlCommand command4 = new SqlCommand("SELECT FROM [Restrictions] WHERE id=(SELECT max(id) FROM [Restrictions])" +
                     " VALUES(@Date,@Time,@Value_Buy,@Value_Sell) ", connection);
                    SqlCommand command5 = new SqlCommand("SELECT FROM [Restrictions] WHERE id=(SELECT max(id) FROM TableName) and Currency=EUR" +
                     " VALUES(@Date,@Time,@Value_Buy,@Value_Sell) ", connection);
                    SqlCommand command6 = new SqlCommand("SELECT FROM [Restrictions] WHERE id=(SELECT max(id) FROM TableName) and Currency=BYN" +
                     " VALUES(@Date,@Time,@Value_Buy,@Value_Sell) ", connection);

                    try
                    {
                        sqlReader2 = await command4.ExecuteReaderAsync();


                        while (sqlReader2.Read())
                        {
                            if (Convert.ToString(sqlReader2.GetValue(5)) == "true")
                            {
                                currencies[0].setRestricted(true);
                                currencies[0].set_amount(Convert.ToDouble(sqlReader2.GetValue(4)));
                                label20.Text = "Включено ограничение на покупу USD";
                                label20.Visible = true;
                            }
                            else
                            {
                                currencies[0].setRestricted(false);
                                label20.Visible = false;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader2 != null)
                        {
                            sqlReader2.Close();
                        }

                    }


                    //Обновление EUR

                    
                    Thread.Sleep(4000);

                }
            });
            thread1.Start();*/
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
            //if (label2.Visible == true) label2.Visible = false;
            //if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            //{
            //    SqlCommand command = new SqlCommand("INSERT INTO [Transactions] (time)VALUES(@time)", connection);

            //    command.Parameters.AddWithValue("time", textBox1.Text);

            //    await command.ExecuteNonQueryAsync();
            //}
            //else
            //{
            //    label2.Text = "Строка Пуста";
            //    label2.Visible = true;
            //}

            //textBox1.Clear();
            //label2.Text = "Успешно добавлено";
            //label2.Visible = true;
        }

        private async void button2_Click(object sender, EventArgs e)
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
           
            if(!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && double.TryParse(textBox8.Text,out i))
            {
                Console.WriteLine(comboBox1.SelectedIndex.ToString());
                Console.WriteLine(comboBox1.SelectedIndex.ToString());

                if (!(comboBox1.SelectedIndex < 0) && 
                    !(comboBox3.SelectedIndex < 0) && 
                    !(comboBox1.SelectedIndex == comboBox3.SelectedIndex))
                {
                    if (comboBox1.SelectedIndex.ToString() == "0" && //попробовать через switch case для повышения производительности
                        comboBox3.SelectedIndex.ToString() == "2") {
                        double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text);
                        double value1 = Convert.ToDouble(textBox8.Text);
                        if (!currencies[2].isRestricted) {
                             value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text);
                             value1 = Convert.ToDouble(textBox8.Text);
                            sendToTransactions("usd", "byn", value1.ToString(), value2.ToString());
                            label20.Visible = false;
                            printCheck(2, "USD", "BYN", value1, value2);
                        } else
                        {
                            if(value2 > currencies[2].get_amount())
                            {
                                label20.Text = "Операция не проведена из-за ограничения";
                            } else
                            {
                                 value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text);
                                 value1 = Convert.ToDouble(textBox8.Text);
                                sendToTransactions("usd", "byn", value1.ToString(), value2.ToString());
                                label20.Visible = false;
                                printCheck(2, "USD", "BYN", value1, value2);
                            }
                        }
                    }
                    if (comboBox1.SelectedIndex.ToString() == "0" && 
                        comboBox3.SelectedIndex.ToString() == "1")
                    {
                        double value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text), 2);
                        double value1 = Convert.ToDouble(textBox8.Text);

                        if (!currencies[1].isRestricted)
                        {
                             value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text), 2);
                             value1 = Convert.ToDouble(textBox8.Text);
                            sendToTransactions("usd", "eur", value1.ToString(), value2.ToString());
                            label20.Visible = false;
                            printCheck(2, "USD", "EUR", value1, value2);
                        }
                        else
                        {
                            if (value2 > currencies[1].get_amount())
                            {
                                label20.Text = "Операция не проведена из-за ограничения";
                                label20.Visible = true;
                            }
                            else
                            {
                                 value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text), 2);
                                 value1 = Convert.ToDouble(textBox8.Text);
                                sendToTransactions("usd", "eur", value1.ToString(), value2.ToString());
                                label20.Visible = false;
                                printCheck(2, "USD", "EUR", value1, value2);
                            }
                        }

                    }
                    if (comboBox1.SelectedIndex.ToString() == "1" && 
                        comboBox3.SelectedIndex.ToString() == "2")
                    {
                        double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text);
                        double value1 = Convert.ToDouble(textBox8.Text);
                        

                        if (!currencies[2].isRestricted)
                        {
                            value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text);
                            value1 = Convert.ToDouble(textBox8.Text);
                            sendToTransactions("eur", "byn", value1.ToString(), value2.ToString());
                            label20.Visible = false;
                            printCheck(2, "EUR", "BYN", value1, value2);
                        }
                        else
                        {
                            if (value2 > currencies[2].get_amount())
                            {
                                label20.Text = "Операция не проведена из-за ограничения";
                                label20.Visible = true;
                            }
                            else
                            {
                                value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text);
                                value1 = Convert.ToDouble(textBox8.Text);
                                sendToTransactions("eur", "byn", value1.ToString(), value2.ToString());
                                label20.Visible = false;
                                printCheck(2, "EUR", "BYN", value1, value2);
                            }
                        }
                    }
                    if (comboBox1.SelectedIndex.ToString() == "1" && 
                        comboBox3.SelectedIndex.ToString() == "0")
                    {
                        double value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text) / Convert.ToDouble(textBox7.Text), 2);
                        double value1 = Convert.ToDouble(textBox8.Text);
                        

                        if (!currencies[0].isRestricted)
                        {
                            value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text) / Convert.ToDouble(textBox7.Text), 2);
                            value1 = Convert.ToDouble(textBox8.Text);
                            sendToTransactions("eur", "usd", value1.ToString(), value2.ToString());
                            label20.Visible = false;
                            printCheck(2, "EUR", "USD", value1, value2);
                        }
                        else
                        {
                            if (value2 > currencies[0].get_amount())
                            {
                                label20.Text = "Операция не проведена из-за ограничения";
                                label20.Visible = true;
                            }
                            else
                            {
                                value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text) / Convert.ToDouble(textBox7.Text), 2);
                                value1 = Convert.ToDouble(textBox8.Text);
                                sendToTransactions("eur", "usd", value1.ToString(), value2.ToString());
                                label20.Visible = false;
                                printCheck(2, "EUR", "USD", value1, value2);
                            }
                        }
                    }
                    if (comboBox1.SelectedIndex.ToString() == "2" && 
                        comboBox3.SelectedIndex.ToString() == "0")
                    {
                        double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox2.Text);
                        double value1 = Convert.ToDouble(textBox8.Text);
                       

                        if (!currencies[0].isRestricted)
                        {
                             value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox2.Text);
                             value1 = Convert.ToDouble(textBox8.Text);
                            sendToTransactions("byn", "usd", value1.ToString(), value2.ToString());
                            label20.Visible = false;
                            printCheck(2, "BYN", "USD", value1, value2);
                        }
                        else
                        {
                            if (value2 > currencies[0].get_amount())
                            {
                                label20.Text = "Операция не проведена из-за ограничения";
                                label20.Visible = true;
                            }
                            else
                            {
                                 value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox2.Text);
                                 value1 = Convert.ToDouble(textBox8.Text);
                                sendToTransactions("byn", "usd", value1.ToString(), value2.ToString());
                                label20.Visible = false;
                                printCheck(2, "BYN", "USD", value1, value2);
                            }
                        }

                    }
                    if (comboBox1.SelectedIndex.ToString() == "2" && 
                        comboBox3.SelectedIndex.ToString() == "1")
                    {
                        double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox3.Text);
                        double value1 = Convert.ToDouble(textBox8.Text);
                        sendToTransactions("byn", "eur", value1.ToString(), value2.ToString());
                        label20.Visible = false;
                        printCheck(2, "BYN", "EUR", value1, value2);

                        if (!currencies[1].isRestricted)
                        {
                             value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox3.Text);
                             value1 = Convert.ToDouble(textBox8.Text);
                            
                        }
                        else
                        {
                            if (value2 > currencies[1].get_amount())
                            {
                                label20.Text = "Операция не проведена из-за ограничения";
                                label20.Visible = true;
                            }
                            else
                            {
                                 value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox3.Text);
                                 value1 = Convert.ToDouble(textBox8.Text);
                                sendToTransactions("byn", "eur", value1.ToString(), value2.ToString());
                                label20.Visible = false;
                                printCheck(2, "BYN", "EUR", value1, value2);
                            }
                        }

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

        private async void sendToTransactions(String currency1,String currency2,String value1,String value2)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Transactions] (date,time,Currency1,Currency2,Value1,Value2,Name,Surname)" +
                " VALUES(@date,@time,@Currency1,@Currency2,@Value1,@Value2,@Name,@Surname) ", connection);

            DateTime now = DateTime.Now;
            command.Parameters.AddWithValue("date",now.ToString("dd:MM:yyyy") );
            command.Parameters.AddWithValue("time", now.ToString("hh:mm"));
            command.Parameters.AddWithValue("Currency1", currency1);
            command.Parameters.AddWithValue("Currency2", currency2);
            command.Parameters.AddWithValue("Value1", value1);
            command.Parameters.AddWithValue("Value2", value2);
            command.Parameters.AddWithValue("Name", "No Value");
            command.Parameters.AddWithValue("Surname", "No Value");

            await command.ExecuteNonQueryAsync();       
        }

            private void button4_Click(object sender, EventArgs e)//показ базы данных
        {
            
            switch (comboBox2.SelectedIndex) {
                case 0:
                    listBox1.Items.Clear();
                    showTransactionsTable();
                    break;
                case 1:
                    
                    listBox1.Items.Clear();
                    if (!checkBox1.Checked)
                    {
                        SqlCommand command1 = new SqlCommand("SELECT * FROM [CurrencyOne] WHERE Date > '2019.03.03'  ", connection);
                        showCurrencyTable(command1);
                        //SqlCommand command1 = new SqlCommand("SELECT * FROM [CurrencyOne]", connection);
                        //showCurrencyTable(command1);
                    } else
                    {

                        SqlCommand command1 = new SqlCommand("SELECT * FROM [CurrencyOne] WHERE date BETWEEN '01-09-2019' AND '01-11-2020'", connection);
                        showCurrencyTable(command1);
                    }
                    break;
                case 2:
                    listBox1.Items.Clear();
                    SqlCommand command2 = new SqlCommand("SELECT * FROM [CurrencyTwo]", connection);
                    showCurrencyTable(command2);
                    break;
                default:
                    listBox1.Items.Clear();
                    showRestrictionsTable();
                    break;
            }
        }

        private async void showTransactionsTable()
        {
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Transactions] WHERE DATE < '20190807'", connection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(
                         Convert.ToString(sqlReader["Date"]) + " "
                        + Convert.ToString(sqlReader["time"]) + ""
                        + Convert.ToString(sqlReader["Currency1"]) + ""
                        + Convert.ToString(sqlReader["Currency2"]) + ""
                        + Convert.ToString(sqlReader["Value1"]) + ""
                        + Convert.ToString(sqlReader["Value2"]) + ""
                        + Convert.ToString(sqlReader["Name"]) + ""
                        + Convert.ToString(sqlReader["Surname"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
        }

        private async void showCurrencyTable(SqlCommand command)
        {
            SqlDataReader sqlReader = null;

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id"]) + "  "
                        + Convert.ToString(sqlReader["Date"]) + " "
                        + Convert.ToString(sqlReader["Time"]) + " "
                        + Convert.ToString(sqlReader["Value_Buy"]) + " "
                        + Convert.ToString(sqlReader["Value_Sell"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
        } 

        private async void showRestrictionsTable()
        {
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Restrictions]", connection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id"]) + "  "
                        + Convert.ToString(sqlReader["Date"]) + " "
                        + Convert.ToString(sqlReader["Currency"]) + " "
                        + Convert.ToString(sqlReader["Value"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
        }

        
        private void button3_Click(object sender, EventArgs e)// ограничения на покупку
        {
            SqlCommand command3 = new SqlCommand("INSERT INTO [Restrictions] (Date,Currency,Value,Status)" +
            " VALUES(@Date,@Currency,@Value,@Status) ", connection);
            label10.Visible = false;
            double i;
            if (!string.IsNullOrEmpty(textBox10.Text)
                && !string.IsNullOrWhiteSpace(textBox10.Text)
                && double.TryParse(textBox10.Text, out i))//нужно что-то с минусом сделать в поле
            {
                switch(comboBox4.SelectedIndex)
                {
                    case 0:
                        setRestrictions(command3,"USD");
                        break;
                    case 1:
                        setRestrictions(command3, "EUR");
                        break;
                    case 2:
                        setRestrictions(command3, "BYN");
                        break;
                    default:

                        break;
                }
            }
            else {
                label10.Text = "Ошибка! Перепроверьте данные.";
                label10.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)// убрать ограничение
        {
            SqlCommand command3 = new SqlCommand("INSERT INTO [Restrictions] (Date,Currency,Value,Status)" +
            " VALUES(@Date,@Currency,@Value,@Status) ", connection);
            // SqlCommand command3 = new SqlCommand("SELECT FROM [Restrictions] WHERE id=(SELECT max(id) FROM TableName) and Currency=USD" +
            // " VALUES(@Date,@Time,@Value_Buy,@Value_Sell) ", connection);
            label10.Text = "Ограничения сняты";
            label10.Visible = true;
            switch (comboBox4.SelectedIndex)
                {
                    case 0:
                    delRestrictions(command3, "USD");
                    break;
                    case 1:
                    delRestrictions(command3, "EUR");
                    break;
                    case 2:
                    delRestrictions(command3, "BYN");

                    break;
                    default:

                        break;
                }
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            } else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)//установить курс валюты
        {
            double i;
            if(!string.IsNullOrEmpty(textBox1.Text) 
                && !string.IsNullOrWhiteSpace(textBox1.Text) 
                && double.TryParse(textBox1.Text, out i) 
                && !string.IsNullOrEmpty(textBox11.Text)
                && !string.IsNullOrWhiteSpace(textBox11.Text)
                && double.TryParse(textBox11.Text, out i))
            {
                switch (comboBox5.SelectedIndex)
                {
                    case 0:
                        SqlCommand command3 = new SqlCommand("INSERT INTO [CurrencyOne] (Date,Time,Value_Buy,Value_Sell)" +
              " VALUES(@Date,@Time,@Value_Buy,@Value_Sell) ", connection);
                        setCurrencyRate(command3);
                        break;
                    case 1:
                        SqlCommand command4 = new SqlCommand("INSERT INTO [CurrencyTwo] (Date,Time,Value_Buy,Value_Sell)" +
              " VALUES(@Date,@Time,@Value_Buy,@Value_Sell) ", connection);
                        setCurrencyRate(command4);
                        break;
                    case 2:
                        break;
                    default:

                        break;
                }
            } else
            {
                label11.Text = "Ошибка! Перепроверьте данные.";
                label11.Visible = true;
            }
        }

        private async void setCurrencyRate(SqlCommand command) {
           

            DateTime now = DateTime.Now;
            command.Parameters.AddWithValue("date", now.ToString("dd:MM:yyyy"));
            command.Parameters.AddWithValue("time", now.ToString("hh:mm"));
            command.Parameters.AddWithValue("Value_Buy",textBox11.Text );
            command.Parameters.AddWithValue("Value_Sell",textBox1.Text);
            textBox1.Text = "";
            textBox11.Text = "";
            await command.ExecuteNonQueryAsync();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double i;
            if (!string.IsNullOrEmpty(textBox8.Text)
                && !string.IsNullOrWhiteSpace(textBox8.Text)
                && double.TryParse(textBox8.Text, out i))
            {
                

                if (comboBox1.SelectedIndex.ToString() == "0" && //попробовать через switch case для повышения производительности
                        comboBox3.SelectedIndex.ToString() == "2")
                {
                    double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text);
                    textBox9.Text = value2.ToString();

                }
                if (comboBox1.SelectedIndex.ToString() == "0" &&
                    comboBox3.SelectedIndex.ToString() == "1")
                {
                    double value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox6.Text), 2);
                    textBox9.Text = value2.ToString();
                }
                if (comboBox1.SelectedIndex.ToString() == "1" &&
                    comboBox3.SelectedIndex.ToString() == "2")
                {
                    double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text);
                    textBox9.Text = value2.ToString();
                }
                if (comboBox1.SelectedIndex.ToString() == "1" &&
                    comboBox3.SelectedIndex.ToString() == "0")
                {
                    double value2 = Math.Round(Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox6.Text) / Convert.ToDouble(textBox7.Text), 2);
                    textBox9.Text = value2.ToString();
                }
                if (comboBox1.SelectedIndex.ToString() == "2" &&
                    comboBox3.SelectedIndex.ToString() == "0")
                {
                    double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox2.Text);
                    textBox9.Text = value2.ToString();
                }
                if (comboBox1.SelectedIndex.ToString() == "2" &&
                    comboBox3.SelectedIndex.ToString() == "1")
                {
                    double value2 = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox3.Text);
                    textBox9.Text = value2.ToString();
                }
            } else
            {
                textBox9.Text = null;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private async void setRestrictions(SqlCommand command,String currency)
        {
           
            DateTime now = DateTime.Now;
            command.Parameters.AddWithValue("date", now.ToString("dd:MM:yyyy"));
            command.Parameters.AddWithValue("Currency", currency);
            command.Parameters.AddWithValue("Value", textBox10.Text);
            command.Parameters.AddWithValue("Status", "true");
           
            textBox10.Text = "";
            await command.ExecuteNonQueryAsync();
        }

        private async void delRestrictions(SqlCommand command, String currency)
        {
            DateTime now = DateTime.Now;
            command.Parameters.AddWithValue("date", now.ToString("dd:MM:yyyy"));
            command.Parameters.AddWithValue("Currency", currency);
            command.Parameters.AddWithValue("Value", 0);
            command.Parameters.AddWithValue("Status", "false");

            textBox10.Text = "";
            await command.ExecuteNonQueryAsync();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void войтиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String password = Microsoft.VisualBasic.Interaction.InputBox("Введите Пароль", "", "", 100, 100);
            if(password == "admin")
            {
                button4.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
                button7.Enabled = true;
                
            }

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false; 
            button7.Enabled = false;
            
        }
    }
}
