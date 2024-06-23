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

                if (!v.isValidID(txtTeacherNum.Text))
                {
                    txtTeacherNum.Focus();
                    txtTeacherNum.SelectAll();
                    return;
                }
                if (!v.isString(fName))
                {
                    txtFName.Focus();
                    txtFName.SelectAll();
                    return;
                }
                if (!v.isString(lName))
                {
                    txtLName.Focus();
                    txtLName.SelectAll();
                    return;
                }
                if (!v.isStringMName(mName))
                {
                    txtMName.Focus();
                    txtMName.SelectAll();
                    return;
                }

                isAdded = a.AddTeacher(teacherNum, fName, mName, lName);

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

            if (!v.isValidID(txtTeacherNum.Text))
            {
                txtTeacherNum.Focus();
                txtTeacherNum.SelectAll();
                return;
            }
            if(!v.isString(fName))
            {
                txtFName.Focus();
                txtFName.SelectAll();
                return;
            }
            if(!v.isString(lName))
            {
                txtLName.Focus();
                txtLName.SelectAll();
                return;
            }
            if (!v.isStringMName(mName))
            {
                txtMName.Focus();
                txtMName.SelectAll();
                return;
            }

            isAdded = a.AddTeacher(teacherNum, fName, mName, lName);

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

        private void txtTeacherNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like backspace
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Check if the length is already 5 or more
            if (txtTeacherNum.Text.Length >= 5)
            {
                e.Handled = true; // Ignore the input if the length is 5 or more
            }
        }
    }
}
