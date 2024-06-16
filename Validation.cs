using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class Validation
    {
        public int isNumber(string txtValue)
        {
            if (txtValue == "")
            {

                //is empty
                MessageBox.Show("Empty field is not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                //not empty
                //is a string
                if (int.TryParse(txtValue, out int ignore) == (false))
                {
                    MessageBox.Show("String value is not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    MessageBox.Show("Empty field is not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
                else
                {
                    // Not empty, check if it's an integer or double
                    if (!int.TryParse(txtValue, out int intValue) && !double.TryParse(txtValue, out doubleValue))
                    {
                        // Not a valid integer or double
                        MessageBox.Show("String value is not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }
                    else if (doubleValue % 1 != Math.Floor(doubleValue)) //round down to nearest integer so that 10.00 will be consider as double. if it is != 0, it will be considered as integer
                    {
                        // It's a double, but with decimal places
                        MessageBox.Show("Decimals are not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Empty field is not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid= false;
            }
            else
            {
                if(int.TryParse(txtValue, out int ignore))
                {
                    // Integer
                    MessageBox.Show("Integer value is not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
                else if(double.TryParse(txtValue, out double dIgnore))
                {
                    // Integer
                    MessageBox.Show("Integer value is not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
            }

            return isValid;
        }

    }
}
