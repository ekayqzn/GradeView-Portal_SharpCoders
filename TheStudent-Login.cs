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
            l.PerformLogIn(this, txtStudentID, txtStudentPass);
            userID = LogInOperation.userID.Trim();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogInStudent l = new LogInStudent();
                l.PerformLogIn(this, txtStudentID, txtStudentPass);
                userID = LogInOperation.userID.Trim();
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            // When showing the password
            txtStudentPass.PasswordChar = '\0'; // Show password
            btnShowPass.Visible = false; // Hide ShowPass button
            btnUnshowPass.Visible = true; // Show UnshowPass button
        }

        private void btnUnshowPass_Click(object sender, EventArgs e)
        {
            // When hiding the password
            txtStudentPass.PasswordChar = '*'; // Hide password
            btnUnshowPass.Visible = false; // Hide UnshowPass button
            btnShowPass.Visible = true; // Show ShowPass button
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
            txtStudentID.Focus();
            // Attach the KeyDown event handler to the TextBoxes
            txtStudentID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtStudentPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);

            btnUnshowPass.Visible = false;
            btnShowPass.Visible = true;
            btnUnshowPass.Parent = txtStudentPass;
            btnUnshowPass.Location = new Point(txtStudentPass.ClientSize.Width - ((btnUnshowPass.Image.Width) + 15), -2);
            btnShowPass.Parent = txtStudentPass;
            btnShowPass.Location = new Point(txtStudentPass.ClientSize.Width - ((btnShowPass.Image.Width) + 15), -2);
        }

    }
}