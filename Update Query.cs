using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class Update_Query
    {
        databaseConnection db = new databaseConnection();
        public int UpdatePassword(string tableName, string password, string userID)
        {
            int rowsAffected = 0;
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = $"UPDATE {tableName}_info SET password = @password WHERE {tableName}_id = @userID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@userID", userID);
                db.cmd.Parameters.AddWithValue("@password", password);

                rowsAffected = db.cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);

            }
            finally
            {
                db.Disconnect();
            }

            return rowsAffected;
        }

        public string GetTableName(string labelText)
        {
            string tableName = "";
            if (labelText.Contains("m_activity"))
            {
                tableName = "m_activity";
            }
            else if (labelText.Contains("m_assignment"))
            {
                tableName = "m_assignment";
            }
            else if (labelText.Contains("m_attendance"))
            {
                tableName = "m_attendance";
            }
            else if (labelText.Contains("m_recitation"))
            {
                tableName = "m_recitation";
            }
            else if (labelText.Contains("m_longquiz"))
            {
                tableName = "m_longquiz";
            }
            else if (labelText.Contains("m_quiz"))
            {
                tableName = "m_quiz";
            }
            else if (labelText.Contains("m_project"))
            {
                tableName = "m_project";
            }
            else if (labelText.Contains("m_exam"))
            {
                tableName = "m_exam";
            }
            if (labelText.Contains("f_activity"))
            {
                tableName = "f_activity";
            }
            else if (labelText.Contains("f_assignment"))
            {
                tableName = "f_assignment";
            }
            else if (labelText.Contains("f_attendance"))
            {
                tableName = "f_attendance";
            }
            else if (labelText.Contains("f_recitation"))
            {
                tableName = "f_recitation";
            }
            else if (labelText.Contains("f_longquiz"))
            {
                tableName = "f_longquiz";
            }
            else if (labelText.Contains("f_quiz"))
            {
                tableName = "f_quiz";
            }
            else if (labelText.Contains("f_project"))
            {
                tableName = "f_project";
            }
            else if (labelText.Contains("f_exam"))
            {
                tableName = "f_exam";
            }

            return tableName;
        }
        public void UpdateGradebook(string tableName, string columnName, int newValue)
        {
            string commandText = $"UPDATE {tableName} SET {columnName} = @newValue WHERE class_id = @classID AND student_id = @studentID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", TheFacultyDashboard.classID);
                db.cmd.Parameters.AddWithValue("@studentID", Edit_GradeBook.editStudentID);
                db.cmd.Parameters.AddWithValue("@newValue", newValue);
                db.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }
        }
    }
}
