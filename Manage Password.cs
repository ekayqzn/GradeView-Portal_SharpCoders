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
            if(TheFacultyDashboard.type != "")
            {
                if (v.passwordValid("teacher", textBox.Text, LogInTeacher.userID))
                {
                    panelPassword.Visible = true;
                    panelButton.Visible = true;

                }
                else
                {
                    MessageBox.Show("Invalid Password");
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
            label.Text = "To continue, first verify it’s you";
            label.Location = new Point(50, 100);
            label.Font = new Font("Arial", 11, FontStyle.Bold);
            label.AutoSize = true;

            textBox = new System.Windows.Forms.TextBox();
            textBox.Size = new Size(530, 34);
            textBox.Location = new Point(50, 150);
            textBox.Name = "txtPassword";
            textBox.Font = new Font("Arial", 12, FontStyle.Regular);

            RoundedButton button = new RoundedButton();
            button.Location = new Point(350, 311);
            button.Text = "Validate";
            button.Click += new EventHandler(btnValidate_Click);

            RoundedButton button2 = new RoundedButton();
            button2.Location = new Point(180, 311);
            button2.Text = "Cancel";
            button2.Click += new EventHandler(btnCancel_Click);

            // Add controls to the form
            this.Controls.Add(label);
            this.Controls.Add(textBox);
            this.Controls.Add(button);
            this.Controls.Add(button2);
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            if(txtNewPass.Text.Equals(txtConfirmPass.Text))
            {
                if(String.IsNullOrWhiteSpace(txtNewPass.Text))
                {
                    MessageBox.Show("Please don't leave password blank or use blank space.");
                }
                else if(TheFacultyDashboard.type == "teacher")
                {
                    if(u.UpdatePassword("teacher", txtConfirmPass.Text, LogInTeacher.userID) != 0)
                    {
                        if (MessageBox.Show("Password updated!", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtConfirmPass.Text = "";
                            txtNewPass.Text = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords don't match");
                txtConfirmPass.Focus();
            }
        }
    }
}
