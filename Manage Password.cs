using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gradesBookApp
{
    public partial class Manage_Password : Form
    {
        databaseConnection db = new databaseConnection();
        Validation v = new Validation();
        Update_Query u = new Update_Query();
        System.Windows.Forms.TextBox textBox;
        public Manage_Password()
        {
            InitializeComponent();
        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValidate_Click (object sender, EventArgs e)
        {
            if(TheFacultyDashboard.type == "teacher")
            {
                if (v.passwordValid("teacher", textBox.Text, LogInTeacher.userID))
                {
                    panelPassword.Visible = true;
                    panelButton.Visible = true;

                }
                else
                {
                    MessageBox.Show("Try Again! Invalid Password input.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if(TheFacultyDashboard.type == "student")
            {
                if (v.passwordValid("student", textBox.Text, LogInStudent.userID))
                {
                    panelPassword.Visible = true;
                    panelButton.Visible = true;

                }
                else
                {
                    MessageBox.Show("Try Again! Invalid Password input.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnCancel_Click (object sender, EventArgs e)
        {
            this.Close();
        }
        private void Manage_Password_Load(object sender, EventArgs e)
        {
            panelPassword.Visible = false;
            panelButton.Visible = false;

            Label label = new Label();
            label.Text = "To continue, first verify it’s you.";
            label.Location = new Point(50, 120);
            label.Font = new Font("Arial", 11, FontStyle.Italic);
            label.AutoSize = true;
            label.ForeColor = Color.FromArgb(0, 4, 93);

            Label label1 = new Label();
            label1.Text = "Enter current password: ";
            label1.Location = new Point(50, 150);
            label1.Font = new Font("Arial", 11, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 4, 93);
            label1.AutoSize = true;

            textBox = new System.Windows.Forms.TextBox();
            textBox.Size = new Size(530, 34);
            textBox.Location = new Point(50, 180);
            textBox.Name = "txtPassword";
            textBox.Font = new Font("Arial", 12, FontStyle.Regular);
            textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);

            RoundedButton button = new RoundedButton();
            button.Location = new Point(420, 311);
            button.Text = "Validate";
            button.Click += new EventHandler(btnValidate_Click);
            button.Cursor = Cursors.Hand;

            RoundedButton button2 = new RoundedButton();
            button2.Location = new Point(240, 311);
            button2.Text = "Cancel";
            button2.Click += new EventHandler(btnCancel_Click);
            button2.BackColor = Color.DarkRed;
            button2.Cursor = Cursors.Hand;

            // Add controls to the form
            this.Controls.Add(label);
            this.Controls.Add(label1);
            this.Controls.Add(textBox);
            this.Controls.Add(button);
            this.Controls.Add(button2);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TheFacultyDashboard.type == "teacher")
                {
                    if (v.passwordValid("teacher", textBox.Text, LogInTeacher.userID))
                    {
                        panelPassword.Visible = true;
                        panelButton.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Try Again! Invalid Password input.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (TheFacultyDashboard.type == "student")
                {
                    if (v.passwordValid("student", textBox.Text, LogInStudent.userID))
                    {
                        panelPassword.Visible = true;
                        panelButton.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Try Again! Invalid Password input.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            if(txtNewPass.Text.Equals(txtConfirmPass.Text))
            {
                if (txtConfirmPass.Text.Length < 8)
                {
                    MessageBox.Show("Password must be at least 8 characters long.", "Invalid Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPass.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtNewPass.Text))
                {
                  
                    MessageBox.Show("Try Again! Do not leave the password fields blank or with spaces.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPass.Focus();
                }
                else if(v.passwordValid(TheFacultyDashboard.type, txtNewPass.Text, LogInOperation.userID))
                {
                    MessageBox.Show("Please provide a new password. Do not reuse the old one.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(TheFacultyDashboard.type == "teacher")
                {
                    if(u.UpdatePassword("teacher", txtConfirmPass.Text, LogInTeacher.userID) != 0)
                    {
                        if (MessageBox.Show("Password successfully updated!", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtConfirmPass.Text = "";
                            txtNewPass.Text = "";
                            this.Close();
                        }
                    }
                }
                else if (TheFacultyDashboard.type == "student")
                {
                    if (u.UpdatePassword("student", txtConfirmPass.Text, LogInStudent.userID) != 0)
                    {
                        if (MessageBox.Show("Password successfully updated!", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtConfirmPass.Text = "";
                            txtNewPass.Text = "";
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Try Again! Password input did not match.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPass.Focus();
            }
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNewPass.Text.Equals(txtConfirmPass.Text))
                {
                    if (txtConfirmPass.Text.Length < 8)
                    {
                        MessageBox.Show("Password must be at least 8 characters long.", "Invalid Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNewPass.Focus();
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(txtNewPass.Text))
                    {

                        MessageBox.Show("Try Again! Do not leave the password fields blank or with spaces.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNewPass.Focus();
                    }
                    else if (v.passwordValid(TheFacultyDashboard.type, txtNewPass.Text, LogInOperation.userID))
                    {
                        MessageBox.Show("Please provide a new password. Do not reuse the old one.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (TheFacultyDashboard.type == "teacher")
                    {
                        if (u.UpdatePassword("teacher", txtConfirmPass.Text, LogInTeacher.userID) != 0)
                        {
                            if (MessageBox.Show("Password successfully updated!", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                txtConfirmPass.Text = "";
                                txtNewPass.Text = "";
                                this.Close();
                            }
                        }
                    }
                    else if (TheFacultyDashboard.type == "student")
                    {
                        if (u.UpdatePassword("student", txtConfirmPass.Text, LogInStudent.userID) != 0)
                        {
                            if (MessageBox.Show("Password successfully updated!", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                txtConfirmPass.Text = "";
                                txtNewPass.Text = "";
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Try Again! Password input did not match.", "Invalid Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConfirmPass.Focus();
                }
            }
        }
    }
}

