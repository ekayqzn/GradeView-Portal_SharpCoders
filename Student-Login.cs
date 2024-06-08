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

        //Log In Successfully
        bool loggedIn = false;
        public Student_Login()
        {
            InitializeComponent();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {

            //userID = txtStudentID.Text;
            //userPass = txtStudentPass.Text;

            ////Check if the user is a Student
            //try
            //{
            //    db.Connect();

            //    db.cmd.Connection = db.conn;
            //    //Since MySql is case insensitive, using BINARY will ensure that it will be case-sensitive esp. in this type of query
            //    db.cmd.CommandText = "SELECT * FROM modern_gradesbook.student_info WHERE BINARY student_id = @studentID AND BINARY password = @studentPassword";

            //    //Clear existing parameter, so that when there's an error, User can still re-enter login details
            //    db.cmd.Parameters.Clear();
            //    db.cmd.Parameters.AddWithValue("@studentID", userID);
            //    db.cmd.Parameters.AddWithValue("@studentPassword", userPass);

            //    db.dtr = db.cmd.ExecuteReader();
            //    loggedIn = db.dtr.Read();
            //    db.dtr.Close();

            //    if (loggedIn)
            //    {
            //        //When both ID and Password exist in database
            //        if (MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            //        {
            //            //show dashboard of specific teacher
            //            this.Hide();
            //            Student_s_Dashboard dashboard = new Student_s_Dashboard();
            //            dashboard.ShowDialog();
            //            this.Close();
            //        }
            //    }
            //    else
            //    {
            //        //Inform user and encourage to re-enter
            //        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtStudentID.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    db.Disconnect();
            //}

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
    }
}
