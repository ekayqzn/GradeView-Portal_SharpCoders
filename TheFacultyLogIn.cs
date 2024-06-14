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
            txtTeacherID.Focus();
            // Attach the KeyDown event handler to the TextBoxes
            txtTeacherID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtTeacherPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);

            btnUnshowPass.Visible = false;
            btnShowPass.Visible = true;
            btnUnshowPass.Parent = txtTeacherPass;
            btnUnshowPass.Location = new Point(txtTeacherPass.ClientSize.Width - ((btnUnshowPass.Image.Width)+15), -2);
            btnShowPass.Parent = txtTeacherPass;
            btnShowPass.Location = new Point(txtTeacherPass.ClientSize.Width - ((btnShowPass.Image.Width)+15), -2);
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheLandingPage l = new TheLandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            LogInTeacher l = new LogInTeacher();
            l.PerformLogIn(this, txtTeacherID, txtTeacherPass);
            userID = LogInOperation.userID.Trim();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogInTeacher l = new LogInTeacher();
                l.PerformLogIn(this, txtTeacherID, txtTeacherPass);
                userID = LogInOperation.userID.Trim();
            }
        }

        private void btnUnshowPass_Click(object sender, EventArgs e)
        {
            // When hiding the password
            txtTeacherPass.PasswordChar = '*'; // Hide password
            btnUnshowPass.Visible = false; // Hide UnshowPass button
            btnShowPass.Visible = true; // Show ShowPass button

        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            // When showing the password
            txtTeacherPass.PasswordChar = '\0'; // Show password
            btnShowPass.Visible = false; // Hide ShowPass button
            btnUnshowPass.Visible = true; // Show UnshowPass button
        }
    }
}
