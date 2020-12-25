using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Checkpassword : Form
    {
        public String password = "admin";
        public bool loged = false;
        public Checkpassword()
        {
            InitializeComponent();
        }

        private void Checkpassword_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString() == password)
            {
                loged = true;
                label2.Visible = false;
            } else
            {
                label2.Text = "Неверный пароль";
                label2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
