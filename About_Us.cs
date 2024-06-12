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
    public partial class About_Us : Form
    {
        public About_Us()
        {
            InitializeComponent();
        }

        private void LinkLBLHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void picAboutUs_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void About_Us_Load(object sender, EventArgs e)
        {

        }
    }
}
