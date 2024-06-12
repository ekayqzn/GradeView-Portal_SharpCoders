using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class UpdateScores
    {
        databaseConnection db = new databaseConnection();
        public void UpdateGradebook (string tableName, string columnName, int newValue, int classID, string studentID)
        {
            string commandText = $"UPDATE {tableName} SET {columnName} = {newValue} WHERE class_id = @classID AND student_id = @studentID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;

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
