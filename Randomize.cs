using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class Randomize
    {
        databaseConnection db = new databaseConnection();
        
        public string GenerateRandomCode(int length = 8)
        {
            string result = "";
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz123456789";
            Random random = new Random();

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;

                bool codeExists = true;
                while (codeExists)
                {
                    // Generate random code
                    result = "";
                    for (int i = 0; i < length; i++)
                    {
                        result += chars[random.Next(chars.Length)];
                    }

                    // Check if code already exists in database
                    db.cmd.CommandText = "SELECT COUNT(*) FROM modern_gradesbook.course WHERE course_code = @code";
                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@code", result);

                    int count = Convert.ToInt32(db.cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        // If no record exists with this code, we can use it
                        codeExists = false;
                    }
                    // If count > 0, the code exists, so we'll loop and generate another code
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred: " + e.Message + "\n" + e.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return result;
        }

    }
}
