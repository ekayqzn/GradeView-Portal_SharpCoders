using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gradesBookApp
{
    public class databaseConnection
    {
        private string strserver = Properties.Settings.Default.server;
        private string strport = Properties.Settings.Default.port;
        private string strusername = Properties.Settings.Default.username;
        private string strpassword = Properties.Settings.Default.password;
        private string strdatabase = Properties.Settings.Default.database;

        public MySqlConnection conn = new MySqlConnection();
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter dta = new MySqlDataAdapter();
        public MySqlDataReader dtr;

        public void Connect()
        {
            string connString = "server = " + strserver + "; port=" + strport + "; username=" + strusername + "; password=" + strpassword + "; database = " + strdatabase + "; charset=utf8";

            conn = new MySqlConnection(connString);
            conn.Open();
        }

        public void Disconnect()
        {
            conn.Dispose();
            conn.Close();
        }

        public void addClassId (string command, int parameter)
        {
            try
            {
                Connect();
                cmd.Connection = conn;
                cmd.CommandText = command;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@value", parameter);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Disconnect();
            }
            

        }
    }
}
