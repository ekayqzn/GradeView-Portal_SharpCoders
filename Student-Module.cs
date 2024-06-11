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
    public partial class Student_Module : Form
    {
        public Student_Module()
        {
            InitializeComponent();
        }

        private void LinkLBLback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Student_s_Dashboard SDB = new Student_s_Dashboard();
            SDB.ShowDialog();
            this.Close();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_s_Dashboard SDB = new Student_s_Dashboard();
            SDB.ShowDialog();
            this.Close();
        }
    }
}
