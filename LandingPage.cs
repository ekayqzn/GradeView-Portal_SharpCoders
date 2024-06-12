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

        private void rbtnFaculty_Click(object sender, EventArgs e)
        {
           
        }

        private void rbtnStudent_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdminstrator_Click(object sender, EventArgs e)
        {
           
        }

        private void LinkLBLAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
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
