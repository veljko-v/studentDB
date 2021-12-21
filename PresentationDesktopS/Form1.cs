using BusinessLayerS;
using DataLayerS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationDesktopS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshList();
        }
        readonly StudentBusiness studentBusiness = new StudentBusiness();


        private void RefreshList()
        {
            listBox1.Items.Clear();
            foreach (Student student in studentBusiness.GetStudents())
            {
                listBox1.Items.Add($"{student.Id}. {student.StudentName}-{student.IndexNumber}-{student.PointsESPB}-{student.StudyYear}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                StudentName = tb_StudentName.Text,
                IndexNumber = tb_IndexNumber.Text,
                PointsESPB = Convert.ToInt32(tb_PointsESPB.Text),
                StudyYear = Convert.ToInt32(tb_StudyYear.Text),
                AverageMark = Convert.ToDecimal(tb_AverageMark.Text),
                IsBudget= checkBox1.Checked
            };

            studentBusiness.InsertStudent(student);

            RefreshList();

            tb_StudentName.Text = "";
            tb_IndexNumber.Text = "";
            tb_PointsESPB.Text = "";
            tb_StudyYear.Text = "";
            tb_AverageMark.Text = "";
            checkBox1.Checked = false;
            tb_StudentName.Focus();
        }
    }
}
