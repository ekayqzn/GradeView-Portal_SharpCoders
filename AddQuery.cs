using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class AddQuery
    {
        databaseConnection db = new databaseConnection();
        public bool Add_Program(string programName, int year, int section)
        {
            bool isAdded = true;
            bool isDuplicate = false;

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE LOWER(program_name) = LOWER(@programName)";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programName", programName.ToLower());
                
                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                if(dataTable1.Rows.Count > 0 )
                {
                    isDuplicate = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occur: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            if (!isDuplicate)
            {
                for (int i = 1; i <= year; i++)
                {
                    for (int j = 1; j <= section; j++)
                    {
                        try
                        {
                            db.Connect();
                            db.cmd.Connection = db.conn;
                            db.cmd.CommandText = "INSERT INTO modern_gradesbook.program (program_name, year_level, section) VALUES (@programName, @year, @section)";

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@programName", programName);
                            db.cmd.Parameters.AddWithValue("@year", i);
                            db.cmd.Parameters.AddWithValue("@section", j);

                            db.cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occur: " + ex.Message + "\n" + ex.StackTrace);
                        }
                        finally
                        {
                            db.Disconnect();
                        }
                    }
                }
                MessageBox.Show("Program Successfully Added");
            }
            else
            {
                MessageBox.Show("Duplicate Program!");
                isAdded = false;
            }

            return isAdded;
            
        }
    }
}
