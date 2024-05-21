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


    }
}
