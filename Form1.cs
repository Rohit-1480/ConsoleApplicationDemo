using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace encyption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public enum EncryptKeys
        {

            EnKey0 = 1,

            EnKey1 = 2,

            EnKey2 = 3,

            EnKey3 = 4,

            EnKey4 = 5,

            EnKey5 = 6,

            EnKey6 = 7,

            EnKey7 = 8,

            EnKey8 = 9,

            EnKey9 = 10,
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text= Encrypt(EncryptKeys.EnKey0, textBox1.Text);
           MessageBox.Show("Hello World");
            MessageBox.Show("Login");
        }
        public string Decrypt(EncryptKeys Number, string EncryptedPassword)
        {
            string Password = "";
            byte Counter;
            int temp;
            Counter = 1;
            while (!(Counter == EncryptedPassword.Length + 1))
            {
                temp = (int)Char.Parse(EncryptedPassword.Substring((Counter - 1), 1)) ^ (10 - (int)Number);
                if (((Counter % 2) == 0))
                {
                    temp = (temp + (int)Number);
                }
                else
                {
                    temp = (temp - (int)Number);
                }

                Password = (Password + ((char)(temp)));
                Counter = (byte)(Convert.ToInt16(Counter) + 1);
            }

            return Password;
        }
        public string Encrypt(EncryptKeys Number, string DecryptedPassword)
        {
            string Password = "";
            byte Counter;
            int temp;
            Counter = 1;
            while (!(Counter == DecryptedPassword.Length + 1))
            {
                temp = (int)Char.Parse(DecryptedPassword.Substring((Counter - 1), 1));
                if (((Counter % 2) == 0))
                {
                    temp = (temp - (int)Number);
                }
                else
                {
                    temp = (temp + (int)Number);
                }

                temp = temp ^ (10 - (int)Number);
                Password = (Password + ((char)(temp)));
                Counter = (byte)(Convert.ToInt16(Counter) + 1);
            }

            return Password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox2.Text = "";
            textBox2.Text = Decrypt(EncryptKeys.EnKey0, textBox2.Text);
        }
    }
}
