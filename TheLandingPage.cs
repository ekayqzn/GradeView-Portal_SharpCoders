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
    public partial class TheLandingPage : Form
    {
        public TheLandingPage()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
        
        }

        private void roundedButton3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            About_Us au = new About_Us();
            au.ShowDialog();
            this.Close();
        }

        private void TheLandingPage_Load(object sender, EventArgs e)
        {

        }

        private void rdbFaculty_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheFacultyLogIn f = new TheFacultyLogIn();
            f.ShowDialog();
            this.Close();
        }

        private void rdbStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheStudent_Login student = new TheStudent_Login();
            student.ShowDialog();
            this.Close();
        }

        private void rdbAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_LogIn adminLogIn = new Administrator_LogIn();
            adminLogIn.ShowDialog();
            this.Close();
        }

        private void picAboutUs_Click(object sender, EventArgs e)
        {
            this.Hide();
            About_Us au = new About_Us();
            au.ShowDialog();
            this.Close();
        }
    }
}
