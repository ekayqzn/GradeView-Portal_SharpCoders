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
    public partial class Add_Program : Form
    {
        Validation v = new Validation();
        AddQuery a = new AddQuery();
        public Add_Program()
        {
            InitializeComponent();
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_Dashboard a = new Administrator_Dashboard();
            a.ShowDialog();
            this.Close();
        }

        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            string programName = txtProgramName.Text;
            int year = Convert.ToInt32(numYear.Value);
            int section = Convert.ToInt32(numSection.Value);
            bool isAdded = true;
            if (v.isString(programName))
            {
                isAdded = a.AddProgram(programName, year, section);
            }

            if (isAdded)
            {
                txtProgramName.Focus();
                txtProgramName.Text = "";
                numYear.Value = 1;
                numSection.Value = 1;
            }
            else
            {
                txtProgramName.Focus();
                txtProgramName.SelectAll();
            }
        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_Dashboard a = new Administrator_Dashboard();
            a.ShowDialog();
            this.Close();
        }

        private void Add_Program_Load(object sender, EventArgs e)
        {
            txtProgramName.Focus();
            txtProgramName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            numYear.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            numSection.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string programName = txtProgramName.Text;
                int year = Convert.ToInt32(numYear.Value);
                int section = Convert.ToInt32(numSection.Value);
                bool isAdded = true;
                if (v.isString(programName))
                {
                    isAdded = a.AddProgram(programName, year, section);
                }

                if (isAdded)
                {
                    txtProgramName.Focus();
                    txtProgramName.Text = "";
                    numYear.Value = 1;
                    numSection.Value = 1;
                }
                else
                {
                    txtProgramName.Focus();
                    txtProgramName.SelectAll();
                }
            }
        }
    }
}
