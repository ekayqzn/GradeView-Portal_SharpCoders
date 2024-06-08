using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class LogInOperation
    {
        databaseConnection db = new databaseConnection();
        public static string userID;
        public string userPass;
        public void PerformLogIn(Form currentForm, TextBox txtID, TextBox txtPass, string tableName)
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
                    db.cmd.CommandText = $"SELECT * FROM modern_gradesbook.{tableName}_info WHERE BINARY {tableName}_id = @Id AND BINARY {tableName}_password = @Password";

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

                        // Redirect to the dashboard based on user type
                        switch (tableName)
                        {
                            case "teacher":
                                ShowTeacherDashboard(currentForm);
                                break;
                            case "student":
                                ShowStudentDashboard(currentForm);
                                break;
                            default:
                                MessageBox.Show("Invalid user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                    {
                        // Inform user and encourage to re-enter
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Both fields are required.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set focus to the empty field
                if (string.IsNullOrEmpty(userID))
                    txtID.Focus();
                else
                    txtPass.Focus();
            }
        }
        private void ShowTeacherDashboard(Form currentForm)
        {
            currentForm.Hide();
            Teacher_s_Dashboard dashboard = new Teacher_s_Dashboard();
            dashboard.ShowDialog();
            currentForm.Close();
        }

        private void ShowStudentDashboard(Form currentForm)
        {
            currentForm.Hide();
            // Assuming you have a form named StudentDashboardForm for students
            Student_s_Dashboard dashboard = new Student_s_Dashboard();
            dashboard.ShowDialog();
            currentForm.Close();
        }

        private void ShowAdminDashboard(Form currentForm)
        {
            currentForm.Hide();
            // Assuming you have a form named StudentDashboardForm for students
            Administrator_Dashboard dashboard = new Administrator_Dashboard();
            dashboard.ShowDialog();
            currentForm.Close();
        }
    }
}
