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
    public partial class EditStudentForm : Form
    {
        public EditStudentForm()
        {
            InitializeComponent();
        }
        public countEntities db = new countEntities();
        s_students st;
        public EditStudentForm(s_students stud)
        {
            st = stud;
            InitializeComponent();
            var groups= (from g in db.s_in_group
                                  select g.id_group).Distinct();
            foreach (int it in groups)
            {
                comboBox1.Items.Add(it);
            }
            textBox1.Text = st.surname.ToString();
            textBox2.Text = st.name.ToString();
            textBox3.Text = st.middlename.ToString();

            var query1 = (from g in db.s_in_group
                         where g.id_group == st.id_group
                         select g.group_num).ToList();
            comboBox1.SelectedItem = query1[0];
          
        }
        public void proverka(TextBox a)
        {
            string str = a.Text;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]) || char.IsPunctuation(str[i]))
                {
                    MessageBox.Show("         Введено недопустимое значение!");
                    a.Text = str.Remove(i, 1);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stt = ((FormStud)Owner).db.s_students.SingleOrDefault(w => w.id == st.id);
            proverka(textBox1);
            proverka(textBox2);
            proverka(textBox3);
            stt.surname = textBox1.Text;
            stt.name = textBox2.Text;
            stt.middlename=textBox3.Text;
            var q = (from g in db.s_in_group
                         where g.id_group == int.Parse(comboBox1.SelectedItem.ToString())
                         select g.group_num).ToList();
            st.id_group = q[0];
            ((FormStud)Owner).studList = ((FormStud)Owner).db.s_students.OrderBy(o => o.id).ToList();
            foreach (var stud in db.s_students.Where(w => w.id == st.id))
            {
                stud.name = st.name;
                stud.surname = st.surname;
                stud.middlename = st.middlename;
                stud.id_group = q[0];
            }
            db.SaveChanges();
            this.Close();
        }
    }
}
