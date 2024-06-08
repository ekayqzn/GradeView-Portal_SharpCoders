using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class LogInStudent : LogInOperation
    {
        public override string GetCommand()
        {
            return "SELECT * FROM modern_gradesbook.student_info WHERE BINARY student_id = @Id AND BINARY password = @Password";
        }

        public override void ShowDashboard(Form currentForm)
        {
            currentForm.Hide();
            Student_s_Dashboard s = new Student_s_Dashboard();
            s.ShowDialog();
            currentForm.Close();
        }
    }
}
