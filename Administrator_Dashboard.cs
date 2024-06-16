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
    public partial class Administrator_Dashboard : Form
    {
        public Administrator_Dashboard()
        {
            InitializeComponent();
        }

        private void rbtnAddStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Student addStudent = new Add_Student();
            addStudent.ShowDialog();
            this.Close();
        }

        private void LinkLBLlogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log out?", "Log out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Administrator_LogIn a = new Administrator_LogIn();
                a.ShowDialog();
                this.Close();
            }
        }

        private void picLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log out?", "Log out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Administrator_LogIn a = new Administrator_LogIn();
                a.ShowDialog();
                this.Close();
            }
        }

        private void rbtnAddProgram_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Program a = new Add_Program();
            a.ShowDialog();
            this.Close();
        }

        private void rbtnAddTeacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Teacher a = new Add_Teacher();
            a.ShowDialog();
            this.Close();
        }
    }
}
