using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class LogInStudent : LogInOperation
    {
        databaseConnection db = new databaseConnection();
        public override string GetCommand()
        {
            return "SELECT * FROM modern_gradesbook.student_info WHERE BINARY student_id = @Id AND BINARY password = @Password";
        }

        public override void ShowDashboard(Form currentForm)
        {
            currentForm.Hide();
            TheStudentDashboard s = new TheStudentDashboard();
            s.ShowDialog();
            currentForm.Close();
        }

    }
}
