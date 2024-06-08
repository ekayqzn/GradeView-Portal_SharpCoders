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
    public partial class Administrator_LogIn : Form
    {
        databaseConnection db = new databaseConnection();
        public Administrator_LogIn()
        {
            InitializeComponent();
        }

        private void Administrator_LogIn_Load(object sender, EventArgs e)
        {
            txtAdminID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtAdminPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            LogInOperation l = new LogInOperation();
            l.PerformLogIn(this, txtAdminID, txtAdminPass, "admin");
            //userID = txtAdminID.Text;
            //userPass = txtAdminPass.Text;

            ////Check if the user is a Teacher
            //try
            //{
            //    db.Connect();

            //    db.cmd.Connection = db.conn;
            //    //Since MySql is case insensitive, using BINARY will ensure that it will be case-sensitive esp. in this type of query
            //    db.cmd.CommandText = "SELECT * FROM modern_gradesbook.administrator WHERE BINARY admin_id = @adminId AND BINARY admin_password = @adminPassword";

            //    //Clear existing parameter, so that when there's an error, User can still re-enter login details
            //    db.cmd.Parameters.Clear();
            //    db.cmd.Parameters.AddWithValue("@adminId", userID);
            //    db.cmd.Parameters.AddWithValue("@adminPassword", userPass);

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
            //            Administrator_Dashboard dashboard = new Administrator_Dashboard();
            //            dashboard.ShowDialog();
            //            this.Close();
            //        }
            //    }
            //    else
            //    {
            //        //Inform user and encourage to re-enter
            //        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtAdminID.Focus();
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
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LogInOperation l = new LogInOperation();
                l.PerformLogIn(this, txtAdminID, txtAdminPass, "admin");
            }
        }
    }
}
