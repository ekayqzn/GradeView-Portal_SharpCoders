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
    }
}
