using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace gradesBookApp
{
    public partial class Administrator_LogIn : Form
    {
        databaseConnection db = new databaseConnection();
        public Administrator_LogIn()
        {
            InitializeComponent();
        }

        private void Administrator_LogIn_Load(object sender, EventArgs e)
        {
            txtAdminID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtAdminPass.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void rbtnLogIn_Click(object sender, EventArgs e)
        {
            LogInAdmin l = new LogInAdmin();
            l.PerformLogIn(this, txtAdminID, txtAdminPass);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LogInAdmin l = new LogInAdmin();
                l.PerformLogIn(this, txtAdminID, txtAdminPass);
            }
        }
    }
}
