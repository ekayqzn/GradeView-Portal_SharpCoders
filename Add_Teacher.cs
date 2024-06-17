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
    public partial class Add_Teacher : Form
    {
        Validation v = new Validation();
        AddQuery a = new AddQuery();
        public Add_Teacher()
        {
            InitializeComponent();
        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_Dashboard a = new Administrator_Dashboard();
            a.ShowDialog();
            this.Close();
        }

        private void Add_Teacher_Load(object sender, EventArgs e)
        {
            txtTeacherNum.Focus();
            txtTeacherNum.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtMName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtLName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtFName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string teacherNum = "TBTU-" + txtTeacherNum.Text.Trim();
                string fName = txtFName.Text.Trim();
                string lName = txtLName.Text.Trim();
                string mName = txtMName.Text.Trim();
                bool isAdded = false;

                if (string.IsNullOrEmpty(teacherNum) || string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
                {
                    MessageBox.Show("Please complete all required fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if ((v.isValidID(txtTeacherNum.Text)) && (v.isString(fName)) && (v.isString(lName)) && (v.isStringMName(mName)))
                    {
                        isAdded = a.AddTeacher(teacherNum, fName, lName, mName);
                    }
                }


                if (isAdded)
                {
                    txtTeacherNum.Focus();
                    txtTeacherNum.Text = "";
                    txtLName.Text = "";
                    txtMName.Text = "";
                    txtFName.Text = "";
                }
                else
                {
                    txtTeacherNum.Focus();
                    txtTeacherNum.SelectAll();
                }

            }
        }

        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            string teacherNum = "TBTU-" + txtTeacherNum.Text.Trim();
            string fName = txtFName.Text.Trim(); 
            string lName = txtLName.Text.Trim();
            string mName = txtMName.Text.Trim();
            bool isAdded = false;

            if(string.IsNullOrEmpty(teacherNum) || string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
            {
                MessageBox.Show("Please complete all required fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if ((v.isValidID(txtTeacherNum.Text)) && (v.isString(fName)) && (v.isString(lName)) && (v.isStringMName(mName)))
                {
                    isAdded = a.AddTeacher(teacherNum, fName, lName, mName);
                }
            }
            

            if (isAdded)
            {
                txtTeacherNum.Focus();
                txtTeacherNum.Text = "";
                txtLName.Text = "";
                txtMName.Text = "";
                txtFName.Text = "";
            }
            else
            {
                txtTeacherNum.Focus();
                txtTeacherNum.SelectAll();
            }
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_Dashboard a = new Administrator_Dashboard();
            a.ShowDialog();
            this.Close();
        }
    }
}
