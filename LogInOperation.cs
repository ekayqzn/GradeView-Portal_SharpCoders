using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public abstract class LogInOperation
    {
        databaseConnection db = new databaseConnection();
        public static string userID;
        public string userPass;
        public string command;
        public void PerformLogIn(Form currentForm, TextBox txtID, TextBox txtPass)
        {
            userID = txtID.Text;
            userPass = txtPass.Text;
            // Check if fields are empty
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(userPass))
            {
                try
                {
                    db.Connect();

                    db.cmd.Connection = db.conn;
                    // Since MySQL is case insensitive, using BINARY will ensure that it will be case-sensitive especially in this type of query
                    db.cmd.CommandText = GetCommand();

                    // Clear existing parameters
                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@Id", userID);
                    db.cmd.Parameters.AddWithValue("@Password", userPass);

                    db.dtr = db.cmd.ExecuteReader();
                    bool loggedIn = db.dtr.Read();
                    db.dtr.Close();

                    if (loggedIn)
                    {
                        // When both ID and Password exist in database
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ShowDashboard(currentForm);
                    }
                    else
                    {
                        // Inform user and encourage to re-enter
                        MessageBox.Show("Try Again! Invalid ID or password input.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else // One or both fields are empty
            {
                // Inform user about empty fields
                MessageBox.Show("Try Again! No fields should be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set focus to the empty field
                if (string.IsNullOrEmpty(userID))
                    txtID.Focus();
                else
                    txtPass.Focus();
            }
        }

        public abstract string GetCommand();
        public abstract void ShowDashboard(Form currentForm);
    }
}
