using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KONTROLNAYA_2
{
    public partial class Form1 : Form
    {
        list_of_postcards postcard = new list_of_postcards();
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(list_of_postcards p)
        {
            this.postcard = p;
            textBox1.Text = p.name_sender;
            textBox2.Text = p.name_recipient;
            textBox4.Text = p.adress;
            textBox3.Text = p.text;
            InitializeComponent();
        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '_' || e.KeyChar == '@' || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list_of_postcards.ProverkaAdress(textBox4.Text))
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                {
                    try
                    {
                         postcard = list_of_postcards.postcardss(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text);
                        MessageBox.Show($"{postcard.name_sender}    {postcard.name_recipient}    {postcard.adress}");
                        Image image=null;
                        if (radioButton1.Checked)
                        {
                            image = radioButton1.Image;
                        }
                        else if (radioButton2.Checked)
                        {
                            image = radioButton2.Image;
                        }
                        else if (radioButton3.Checked) 
                        {
                            image = radioButton3.Image;
                        }
                        Form2 f = new Form2(postcard,image); f.Show(); this.Hide();
                    }
                    catch { MessageBox.Show(" "); }
                }
                else { MessageBox.Show("Выберите одну из открыток"); }
            }
            else MessageBox.Show("Адрес электронной почты введен некорректно"); 
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
