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
    public partial class TheTermsOfUseAndPrivacyStatement : Form
    {
        public TheTermsOfUseAndPrivacyStatement()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TheTermsOfUseAndPrivacyStatement_Load(object sender, EventArgs e)
        {

        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }
    }
}
