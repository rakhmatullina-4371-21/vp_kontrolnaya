﻿using System;
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
    public partial class FormStud : Form
    {
        public FormStud()
        {
            InitializeComponent();
            studList = (from stud in db.s_students
                        select stud).ToList();
            var s = (from stud in studList
                     join gr in db.s_in_group on stud.id_group equals gr.id_group
                     select new { stud.id, stud.surname, stud.name, stud.middlename, gr.kurs_num, gr.group_num }).ToList();

            dataGridView1.DataSource = s;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].HeaderText = "Номер зачетной";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Номер курса";
            dataGridView1.Columns[5].HeaderText = "Номер группы";
        }
        public countEntities db = new countEntities();
        public List<s_students> studList;
        private void button2_Click(object sender, EventArgs e)
        {
            var s = (from stud in studList
                     join gr in db.s_in_group on stud.id_group equals gr.id_group
                     select new { stud.id, stud.surname, stud.name, stud.middlename, gr.kurs_num, gr.group_num }).ToList();
            dataGridView1.DataSource = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var q = (from stud in studList
                     join gr in db.s_in_group on stud.id_group equals gr.id_group
                     select new { stud.id, stud.surname, stud.name, stud.middlename, gr.kurs_num, gr.group_num }).ToList();
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
            {
                if (textBox1.Text != "" && textBox2.Text=="" && textBox3.Text=="")
                {
                    dataGridView1.DataSource = q.Where(p => p.surname == textBox1.Text.ToString());
                }
                if (textBox2.Text != "" && textBox1.Text == "" && textBox3.Text == "")
                {
                    dataGridView1.DataSource = q.Where(p => p.surname == textBox2.Text.ToString());

                }
                if (textBox3.Text != "" && textBox1.Text == "" && textBox2.Text == "")
                {
                    dataGridView1.DataSource = q.Where(p => p.surname == textBox3.Text.ToString());
                }
            }
            else MessageBox.Show("Выберите хотя бы одно поле для поиска");
        } 

                private void button5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                addGroupForm addGr = new addGroupForm();
                addGr.Owner = this;
                addGr.Show();
            }
            else Application.OpenForms[0].Focus();
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<s_students> q = (from stud in db.s_students
                                    select stud).ToList();
            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 2)
                {
                    s_students students = q.First(c => c.id.ToString() == dataGridView1.SelectedCells[0]
                      .OwningRow.Cells[0].Value.ToString());
                    EditStudentForm formEditStudent = new EditStudentForm(students);
                    formEditStudent.Owner = this;
                    formEditStudent.Show();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
