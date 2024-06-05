﻿using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace gradesBookApp
{
    public partial class Faculty_LogIn : Form
    {
        //Instantiate DatabaseConnection Class
        databaseConnection db = new databaseConnection();

        //User Input Value
        //Need to be accessed in other forms
        public static string userID { get; set; }
        public string userPass;

        //Log In Successfully
        bool loggedIn = false;
        public Faculty_LogIn()
        {
            InitializeComponent();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            userID = txtTeacherID.Text;
            userPass = txtTeacherPass.Text;

            //Check if the user is a Teacher
            try
            {
                db.Connect();

                db.cmd.Connection = db.conn;
                //Since MySql is case insensitive, using BINARY will ensure that it will be case-sensitive esp. in this type of query
                db.cmd.CommandText = "SELECT * FROM modern_gradesbook.teacher_info WHERE BINARY teacher_id = @teacherId AND BINARY teacher_password = @teacherPassword";

                //Clear existing parameter, so that when there's an error, User can still re-enter login details
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@teacherId", userID);
                db.cmd.Parameters.AddWithValue("@teacherPassword", userPass);

                db.dtr = db.cmd.ExecuteReader();
                loggedIn = db.dtr.Read();
                db.dtr.Close();

                if (loggedIn)
                {
                    //When both ID and Password exist in database
                    if(MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //show dashboard of specific teacher
                        this.Hide();
                        Teacher_s_Dashboard dashboard = new Teacher_s_Dashboard();
                        dashboard.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    //Inform user and encourage to re-enter
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTeacherID.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }

        }

        private void LinkLBLHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LandingPage l = new LandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LandingPage l = new LandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void Faculty_LogIn_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
