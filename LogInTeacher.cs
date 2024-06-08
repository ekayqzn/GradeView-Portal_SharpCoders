using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class LogInTeacher : LogInOperation
    {
        public override string GetCommand()
        {
            return $"SELECT * FROM modern_gradesbook.teacher_info WHERE BINARY teacher_id = @Id AND BINARY teacher_password = @Password";
        }

        public override void ShowDashboard(Form currentForm)
        {
            currentForm.Hide();
            Teacher_s_Dashboard dashboard = new Teacher_s_Dashboard();
            dashboard.ShowDialog();
            currentForm.Close();
        }
    }
}
