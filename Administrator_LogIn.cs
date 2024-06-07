using System;
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
        string userID, userPass;
        databaseConnection db = new databaseConnection();
        bool loggedIn;
        public Administrator_LogIn()
        {
            InitializeComponent();
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            userID = txtAdminID.Text;
            userPass = txtAdminPass.Text;

            //Check if the user is a Teacher
            try
            {
                db.Connect();

                db.cmd.Connection = db.conn;
                //Since MySql is case insensitive, using BINARY will ensure that it will be case-sensitive esp. in this type of query
                db.cmd.CommandText = "SELECT * FROM modern_gradesbook.administrator WHERE BINARY admin_id = @adminId AND BINARY admin_password = @adminPassword";

                //Clear existing parameter, so that when there's an error, User can still re-enter login details
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@adminId", userID);
                db.cmd.Parameters.AddWithValue("@adminPassword", userPass);

                db.dtr = db.cmd.ExecuteReader();
                loggedIn = db.dtr.Read();
                db.dtr.Close();

                if (loggedIn)
                {
                    //When both ID and Password exist in database
                    if (MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //show dashboard of specific teacher
                        this.Hide();
                        //Teacher_s_Dashboard dashboard = new Teacher_s_Dashboard();
                        //dashboard.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    //Inform user and encourage to re-enter
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdminID.Focus();
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
    }
}
