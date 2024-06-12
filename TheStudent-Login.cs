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
    public partial class TheStudent_Login : Form
    {
        // Instantiate DatabaseConnection Class
        databaseConnection db = new databaseConnection();

        // User Input Value
        // Need to be accessed in other forms
        public static string userID { get; set; }
        public string userPass;

        public TheStudent_Login()
        {
            InitializeComponent();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            LogInStudent l = new LogInStudent();
            l.PerformLogIn(this, txtSID, txtSPass);
            userID = LogInOperation.userID.Trim();
        }

        private void Student_Login_Load(object sender, EventArgs e)
        {
            txtSID.Focus();
            // Attach the KeyDown event handler to the TextBoxes
            txtSID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtSPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogInStudent l = new LogInStudent();
                l.PerformLogIn(this, txtSID, txtSPass);
                userID = LogInOperation.userID.Trim();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            // When showing the password
            txtSPass.PasswordChar = '\0'; // Show password
            btnShowPass.Visible = false; // Hide ShowPass button
            btnUnshowPass.Visible = true; // Show UnshowPass button
        }

        private void btnUnshowPass_Click(object sender, EventArgs e)
        {
            // When hiding the password
            txtSPass.PasswordChar = '*'; // Hide password
            btnUnshowPass.Visible = false; // Hide UnshowPass button
            btnShowPass.Visible = true; // Show ShowPass button
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void TheStudent_Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
           TheTermsOfUseAndPrivacyStatement l = new TheTermsOfUseAndPrivacyStatement();
            l.ShowDialog();
            this.Close();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}