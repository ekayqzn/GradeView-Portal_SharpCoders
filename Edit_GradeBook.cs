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
    public partial class Edit_GradeBook : Form
    {
        public Edit_GradeBook()
        {
            InitializeComponent();
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            GradeBook GB = new GradeBook(); 
            GB.ShowDialog();
            this.Close();
        }
    }
}
