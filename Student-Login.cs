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
    public partial class Student_Login : Form
    {
        //Instantiate DatabaseConnection Class
        databaseConnection db = new databaseConnection();

        //User Input Value
        //Need to be accessed in other forms
        public static string userID { get; set; }
        public string userPass;

        public Student_Login()
        {
            InitializeComponent();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            LogInStudent l = new LogInStudent();
            l.PerformLogIn(this, txtStudentID, txtStudentPass);
            userID = LogInOperation.userID.Trim();
        }

        private void LinkLBLHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LandingPage l = new LandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            About_Us au = new About_Us();
            au.ShowDialog();
            this.Close();
        }

        private void Student_Login_Load(object sender, EventArgs e)
        {
            txtStudentID.Focus();
            // Attach the KeyDown event handler to the TextBoxes
            txtStudentID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtStudentPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtStudentPass.PasswordChar == '\0')
            {
                btnClose.BringToFront();
                txtStudentPass.PasswordChar = '*';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtStudentPass.PasswordChar == '*')
            {
                btnOpen.BringToFront();
                txtStudentPass.PasswordChar = '\0';
            }
        }
    }
}
