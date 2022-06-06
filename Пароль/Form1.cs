using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Пароль
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string password;
        bool big;
        bool isDig;
        bool c;
        static FileStream file = new FileStream(@"F:\Михаил\Прога2\Пароль\Пароль\password.txt", FileMode.Append);
        StreamWriter writer = new StreamWriter(file);

        private void button1_Click(object sender, EventArgs e)
        {
            big = password.Any(char.IsUpper);
            isDig = password.Any(char.IsDigit);

            if (password.Length<5) label1.Text = "Пароль должен быть не менее 6 символов";
            else if (big==false) label1.Text = "Пароль не содержит прописную букву";
            else if (isDig == false) label1.Text = "Пароль не содержит цифр";
            else c = true;

            if (c==true)
            {
                if (password.Contains("!") || password.Contains("@") || password.Contains("#")
                    || password.Contains("$") || password.Contains("%") || password.Contains("^"))
                {
                    label1.Text = "Пароль подходит" + "\nЗаписано в password.txt";
                    writer.WriteLine(password);
                }
                else label1.Text = "Нет спецсимволов";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            password = textBox1.Text;
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            writer.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space) e.Handled = true;
        }
    }
}
