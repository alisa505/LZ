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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Globals.User.checkname(textBox1.Text))
            {
                MessageBox.Show("Не верное ФИО ");
                return;
            }
            if (!Globals.User.checkphone(maskedTextBox1.Text))
            {
                MessageBox.Show("Не верный номер телефона");
                return;
            }
            if (!Globals.User.checkdate(maskedTextBox2.Text))
            {
                MessageBox.Show("Не верная дата рождения");
                return;
            }
            if (!Globals.User.checkemail(textBox2.Text))
            {
                MessageBox.Show("не верный email ");
                return;
            }
            if (!Globals.User.checkpassword(textBox4.Text))
            {
                MessageBox.Show("Не верный пароль");
                return;
            }
        }
    }
}
