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

        private void picAboutUs_Click(object sender, EventArgs e)
        {
            this.Hide();
            About_Us au = new About_Us();
            au.ShowDialog();
            this.Close();
        }

        private void rbtnFaculty_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheFacultyLogIn f = new TheFacultyLogIn();
            f.ShowDialog();
            this.Close();
        }

        private void rbtnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheStudent_Login student = new TheStudent_Login();
            student.ShowDialog();
            this.Close();
        }

        private void picAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_LogIn adminLogIn = new Administrator_LogIn();
            adminLogIn.ShowDialog();
            this.Close();
        }

        private void linkTermsPrivacy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TheTermsOfUseAndPrivacyStatement l = new TheTermsOfUseAndPrivacyStatement();
            l.ShowDialog();
            this.Close();
        }
    }
}
