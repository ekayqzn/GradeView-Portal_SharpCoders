using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class LogInAdmin : LogInOperation
    {
        public override string GetCommand()
        {
            return "SELECT * FROM modern_gradesbook.administrator WHERE BINARY admin_id = @Id AND BINARY admin_password = @Password";
        }

        public override void ShowDashboard(Form currentForm)
        {
            currentForm.Hide();
            Administrator_Dashboard dashboard = new Administrator_Dashboard();
            dashboard.ShowDialog();
            currentForm.Close();
        }
    }
}
