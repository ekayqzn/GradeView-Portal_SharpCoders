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
    public partial class TheFacultyLogIn : Form
    {
        //Instantiate DatabaseConnection Class
        databaseConnection db = new databaseConnection();

        //User Input Value
        //Need to be accessed in other forms
        public static string userID;
        public string userPass;
        public TheFacultyLogIn()
        {
            InitializeComponent();
        }

        private void TheFacultyLogIn_Load(object sender, EventArgs e)
        {

        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            LogInTeacher l = new LogInTeacher();
            l.PerformLogIn(this, txtFID, txtFPass);
            userID = LogInOperation.userID.Trim();
        }

        private void FacultyLogIn_Load(object sender, EventArgs e)
        {
            txtFID.Focus();
            // Attach the KeyDown event handler to the TextBoxes
            txtFID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtFPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogInTeacher l = new LogInTeacher();
                l.PerformLogIn(this, txtFID, txtFPass);
                userID = LogInOperation.userID.Trim();
            }
        }

        private void btnUnshowPass_Click(object sender, EventArgs e)
        {
            // When hiding the password
            txtFPass.PasswordChar = '*'; // Hide password
            btnUnshowPass.Visible = false; // Hide UnshowPass button
            btnShowPass.Visible = true; // Show ShowPass button
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            // When showing the password
            txtFPass.PasswordChar = '\0'; // Show password
            btnShowPass.Visible = false; // Hide ShowPass button
            btnUnshowPass.Visible = true; // Show UnshowPass button
        }
    }
}
