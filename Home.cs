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
    public partial class Home : Form
    {
        
        public Home()
        {
            InitializeComponent();
        }

        private void rbtnFaculty_Click(object sender, EventArgs e)
        {
            this.Hide();
            Faculty_LogIn faculty = new Faculty_LogIn();
            faculty.ShowDialog();
            this.Close(); 
        }
    }
}
