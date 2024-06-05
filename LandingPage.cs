using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{


    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {
            this.TopMost = true; // Optional: Ensures the form stays on top
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblSchoolName_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {

        }

        private void rbtnFaculty_Click(object sender, EventArgs e)
        {
            this.Hide();
            Faculty_LogIn faculty = new Faculty_LogIn();
            faculty.ShowDialog();
            this.Close();
        }

        private void rbtnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Login student = new Student_Login();
            student.ShowDialog();
            this.Close();
        }

        private void btnAdminstrator_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Student addStudent = new Add_Student();
            addStudent.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void llblHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void LinkLBLAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            About_Us au = new About_Us();
            au.ShowDialog();
            this.Close();
        }
    }


}
