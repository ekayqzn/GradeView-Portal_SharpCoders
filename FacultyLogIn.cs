﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace gradesBookApp
{
    public partial class FacultyLogIn : Form
    {
        //Instantiate DatabaseConnection Class
        databaseConnection db = new databaseConnection();

        //User Input Value
        //Need to be accessed in other forms
        public static string userID;
        public string userPass;

        public FacultyLogIn()
        {
            InitializeComponent();
        }

        private void LinkLBLHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LandingPage l = new LandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            LogInOperation l = new LogInOperation();
            l.PerformLogIn(this, txtTeacherID, txtTeacherPass, "teacher");
            userID = LogInOperation.userID.Trim();
        }

        private void FacultyLogIn_Load(object sender, EventArgs e)
        {
            txtTeacherID.Focus();
            // Attach the KeyDown event handler to the TextBoxes
            txtTeacherID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtTeacherPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void picAboutUs_Click(object sender, EventArgs e)
        {
            About_Us au = new About_Us();
            this.Hide();
            au.ShowDialog();
            this.Close();
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage l = new LandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void lblAboutUs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About_Us au = new About_Us();
            this.Hide();
            au.ShowDialog();
            this.Close();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LogInOperation l = new LogInOperation();
                l.PerformLogIn(this, txtTeacherID, txtTeacherPass, "teacher");
                userID = LogInOperation.userID.Trim();
            }
        }
    }
}
