using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KONTROLNAYA
{
    public partial class addGroupForm : Form
    {
        public addGroupForm()
        {
            InitializeComponent();

        }
       public countEntities db = new countEntities();
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void proverka(TextBox a)
        {
            string b = a.Text;
            //a = a.Replace(" ", "");

            for (int i = 0; i < b.Length; i++)
            {
                if (char.IsDigit(b[i]))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("         Введено недопустимое значение! \r\nВ этих полях допускаются только числа");
                    a.Text = b.Remove(i, 1);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            proverka(textBox1);
            proverka(textBox2);
            var q = (from gr in db.s_in_group
                     select gr.id_group).ToList();

            var codde_gr = db.s_in_group.Max(r => r.id_group) + 1;
            s_in_group gropNew = new s_in_group { id_group = codde_gr, kurs_num = int.Parse(textBox1.Text.Replace(" ", "")), group_num = int.Parse(textBox2.Text.Replace(" ", ""))};
            db.s_in_group.Add(gropNew);
            db.SaveChanges();
            this.Close();

        }
    }
}
