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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridView1.DataSource = list_of_postcards.Return();
            dataGridView1.Columns[0].HeaderText = "ФИО \r\n получателя";
            dataGridView1.Columns[1].HeaderText = "Эл. адрес \r\n получателя";
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
