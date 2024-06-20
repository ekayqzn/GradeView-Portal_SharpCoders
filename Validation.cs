using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class Validation
    {
        databaseConnection db = new databaseConnection();

        
        public bool passwordValid (string tableName, string password, string userID)
        {
            bool result = false;
            string command;
            command = $"SELECT password FROM {tableName}_info WHERE {tableName}_id = @ID AND password = @password";
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = command;

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@ID", userID);
                db.cmd.Parameters.AddWithValue("@password", password);

                db.dta.SelectCommand = db.cmd;
                DataTable dt = new DataTable();
                db.dta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occur:" + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return result;
        }
        public bool isValidID(string textvalue)
        {
            bool isValid = false;
            if(String.IsNullOrEmpty(textvalue))
            {
                MessageBox.Show("Try Again! No fields should be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //not empty
                //is a string
                if (int.TryParse(textvalue, out int ignore) == (false))
                {
                    MessageBox.Show("Inputs must only be numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    isValid = true;
                }
            }

            return isValid;
        }
        public int isNumber(string txtValue)
        {
            if (txtValue == "")
            {

                //is empty
                MessageBox.Show("Try Again! No fields should be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                //not empty
                //is a string
                if (int.TryParse(txtValue, out int ignore) == (false))
                {
                    MessageBox.Show("Inputs must only be numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return 0;

                }
                //valid input
                else
                {
                    int.TryParse(txtValue, out int countValue) ;
                    return countValue;
                }
            }

               
        }

        public bool isNumberforDB(string txtValue)
        {
            bool isValid = true;
            double doubleValue = 0;

            if (txtValue != "-1")
            {
                if (txtValue == "")
                {
                    // Empty field
                    MessageBox.Show("Try Again! No fields should be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
                else
                {
                    // Not empty, check if it's an integer or double
                    if (!int.TryParse(txtValue, out int intValue) && !double.TryParse(txtValue, out doubleValue))
                    {
                        // Not a valid integer or double
                        MessageBox.Show("Inputs must only be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }
                    else if (doubleValue % 1 != Math.Floor(doubleValue)) //round down to nearest integer so that 10.00 will be consider as double. if it is != 0, it will be considered as integer
                    {
                        // It's a double, but with decimal places
                        MessageBox.Show("Decimal inputs are not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        public bool isString(string txtValue)
        {
            bool isValid = true;
            if(String.IsNullOrEmpty(txtValue))
            {
                // Empty field
                MessageBox.Show("Try Again! No fields should be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid= false;
            }
            else
            {
                if(int.TryParse(txtValue, out int ignore))
                {
                    // Integer
                    MessageBox.Show("Integer values are not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
                else if(double.TryParse(txtValue, out double dIgnore))
                {
                    // Integer
                    MessageBox.Show("Integer values are not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
            }

            return isValid;
        }

        public bool isStringMName(string txtValue)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(txtValue))
            {
                // Empty field. Possible doesnt have middle name
                isValid = true;
            }
            else
            {
                if (int.TryParse(txtValue, out int ignore))
                {
                    // Integer
                    MessageBox.Show("Integer values are not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
                else if (double.TryParse(txtValue, out double dIgnore))
                {
                    // Integer
                    MessageBox.Show("Integer values are not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
            }

            return isValid;
        }

    }
}
