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
    }
}
