using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_11
{
    public partial class Form1 : Form
    {
        public string FirstElement;
        public string SecondElement;
        public bool SecondCheck(string SecondString)
        {
            if (SecondString == null || SecondString == " " || SecondString == "")
                return false;
            else
                return true;
        }
        public bool FirstCheck(string FirstString)
        {
            string[] helper = FirstString.Split(' ');
            FirstElement = helper[0];
            SecondElement = "";
            bool Check = true;
            for (int i = 0; i < helper.Length; i++)
            {
                if (helper[i] != FirstElement)
                {
                    if (SecondElement == "")
                        SecondElement = helper[i];
                    else if (helper[i] != SecondElement)
                        Check = false;
                }
            }
            return Check;
        }
        public string EncryptString(string FirstString)
        {
            string[] helper = FirstString.Split(' ');
            string pred = FirstElement;
            string EncryptedString = pred + " ";
            for (int i = 1; i < helper.Length; i++)
            {
                if (i == helper.Length - 1)
                {
                    if (helper[i] == pred)
                        EncryptedString += "1";
                    else
                    {
                        EncryptedString += "0";
                    }
                }
                else
                {
                    if (helper[i] == pred)
                        EncryptedString += "1 ";
                    else
                    {
                        EncryptedString += "0 ";
                        pred = helper[i];
                    }
                }
            }
            return EncryptedString;
        }
        public string DecryptString(string FirstString)
        {
            string[] helper = FirstString.Split(' ');
            string pred = FirstElement;
            string DecryptedString = pred + " ";
            for (int i = 1; i < helper.Length; i++)
            {
                if (i == helper.Length - 1)
                {
                    if (helper[i] == "1")
                    {
                        DecryptedString += pred;
                    }
                    else
                    {
                        if (pred == FirstElement)
                        {
                            DecryptedString += SecondElement;
                            pred = SecondElement;
                        }
                        else
                        {
                            DecryptedString += FirstElement;
                            pred = FirstElement;
                        }
                    }
                }
                else
                {
                    if (helper[i] == "1")
                    {
                        DecryptedString += pred + " ";
                    }
                    else
                    {
                        if (pred == FirstElement)
                        {
                            DecryptedString += SecondElement + " ";
                            pred = SecondElement;
                        }
                        else
                        {
                            DecryptedString += FirstElement + " ";
                            pred = FirstElement;
                        }
                    }
                }
            }
            return DecryptedString;
        }
        public Form1()
        {
            InitializeComponent();
            Encrypt.Enabled = false;
            Decrypt.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            textBox2.Text = EncryptString(textBox1.Text);
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            textBox3.Text = DecryptString(textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (SecondCheck(textBox1.Text))
            {
                if (FirstCheck(textBox1.Text))
                    Encrypt.Enabled = true;
                else
                    Encrypt.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (SecondCheck(textBox2.Text))
            {
                Decrypt.Enabled = true;
            }
        }
    }
}
