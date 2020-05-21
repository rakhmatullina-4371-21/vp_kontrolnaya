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
    public partial class Form2 : Form
    {
        list_of_postcards postcards;
        public Form2(list_of_postcards p, Image image )
        {
            this.postcards = p;
            InitializeComponent();
            pictureBox1.Image = image;
            label1.Text = p.name_recipient;
            label2.Text = p.text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                postcards.Save(postcards);
                label3.Visible = true;
                label3.Text = $"Открытка  отправлена адресату {postcards.name_recipient} \r\n по адресу  {postcards.adress}";
                button1.Visible = false;
                button1.Visible = false;
                Form3 f = new Form3();
                f.Show();
            }
            catch { MessageBox.Show("Ошибка"); }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(postcards);
            f.Show();

        }
    }
}
