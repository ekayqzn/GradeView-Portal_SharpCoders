using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class GetRecordQuery
    {
        databaseConnection db = new databaseConnection();
        GradebookComputation c = new GradebookComputation();
        //Get records per student and add to datatable
        //Project and Exam
        public decimal GetRecordRdo(string prefix, string tableName, int ID)
        {
            decimal percentile = 0;
            string commandText = $"SELECT {prefix}_{tableName}, {prefix}_{tableName}_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
            if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}")))
            {
                GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}");
            }
            if((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}_score")))
            {
                GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}_score");
            }
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@ID", ID);
                db.dta.SelectCommand = db.cmd;

                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                GradeBook.newRow[$"{prefix}_{tableName}"] = dataTable1.Rows[0][$"{prefix}_{tableName}"];
                GradeBook.newRow[$"{prefix}_{tableName}_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}_score"];

                percentile = c.PercentileRdo(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}"]));

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return percentile;
        }

        //Recit And Attendance
        public decimal GetRecordAttRecit(string prefix, string tableName, int ID, int count)
        {
            int summation = 0;
            decimal percentile = 0;
            string commandText = "";
            switch (count)
            {
                case 1:
                    commandText = $"SELECT {prefix}_{tableName}1 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 2:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 3:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2, {prefix}_{tableName}3 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 4:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2, {prefix}_{tableName}3, {prefix}_{tableName}4 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 5:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2, {prefix}_{tableName}3, {prefix}_{tableName}4, {prefix}_{tableName}5 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 6:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2, {prefix}_{tableName}3, {prefix}_{tableName}4, {prefix}_{tableName}5, {prefix}_{tableName}6 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 7:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2, {prefix}_{tableName}3, {prefix}_{tableName}4, {prefix}_{tableName}5, {prefix}_{tableName}6, {prefix}_{tableName}7 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        GradeBook.newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 8:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2, {prefix}_{tableName}3, {prefix}_{tableName}4, {prefix}_{tableName}5, {prefix}_{tableName}6, {prefix}_{tableName}7, {prefix}_{tableName}8 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}8")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}8");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        GradeBook.newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];
                        GradeBook.newRow[$"{prefix}_{tableName}8"] = dataTable1.Rows[0][$"{prefix}_{tableName}8"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 9:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}2, {prefix}_{tableName}3, {prefix}_{tableName}4, {prefix}_{tableName}5, {prefix}_{tableName}6, {prefix}_{tableName}7, {prefix}_{tableName}8, {prefix}_{tableName}9 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}8")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}8");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}9")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}9");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        GradeBook.newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];
                        GradeBook.newRow[$"{prefix}_{tableName}8"] = dataTable1.Rows[0][$"{prefix}_{tableName}8"];
                        GradeBook.newRow[$"{prefix}_{tableName}9"] = dataTable1.Rows[0][$"{prefix}_{tableName}9"];

                        summation = (Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8"]) + Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}9"])) / count;
                        percentile = c.Percentile(summation, (GetPercentage(prefix, tableName, ID)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
            }
            return percentile;
        }

        //Other
        public decimal GetRecordsOther(string prefix, string tableName, int ID, int count)
        {
            decimal summation = 0;
            decimal percentile = 0;
            string commandText = "";
            switch (count)
            {
                case 1:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        summation = c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 2:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 3:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score, {prefix}_{tableName}3, {prefix}_{tableName}3_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 4:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score, {prefix}_{tableName}3, {prefix}_{tableName}3_score, {prefix}_{tableName}4, {prefix}_{tableName}4_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 5:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score, {prefix}_{tableName}3, {prefix}_{tableName}3_score, {prefix}_{tableName}4, {prefix}_{tableName}4_score, {prefix}_{tableName}5, {prefix}_{tableName}5_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 6:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score, {prefix}_{tableName}3, {prefix}_{tableName}3_score, {prefix}_{tableName}4, {prefix}_{tableName}4_score, {prefix}_{tableName}5, {prefix}_{tableName}5_score, {prefix}_{tableName}6, {prefix}_{tableName}6_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        GradeBook.newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 7:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score, {prefix}_{tableName}3, {prefix}_{tableName}3_score, {prefix}_{tableName}4, {prefix}_{tableName}4_score, {prefix}_{tableName}5, {prefix}_{tableName}5_score, {prefix}_{tableName}6, {prefix}_{tableName}6_score, {prefix}_{tableName}7, {prefix}_{tableName}7_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        GradeBook.newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];
                        GradeBook.newRow[$"{prefix}_{tableName}7_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}7_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 8:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score, {prefix}_{tableName}3, {prefix}_{tableName}3_score, {prefix}_{tableName}4, {prefix}_{tableName}4_score, {prefix}_{tableName}5, {prefix}_{tableName}5_score, {prefix}_{tableName}6, {prefix}_{tableName}6_score, {prefix}_{tableName}7, {prefix}_{tableName}7_score, {prefix}_{tableName}8, {prefix}_{tableName}8_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}8")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}8");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}8_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        GradeBook.newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];
                        GradeBook.newRow[$"{prefix}_{tableName}7_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}7_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}8"] = dataTable1.Rows[0][$"{prefix}_{tableName}8"];
                        GradeBook.newRow[$"{prefix}_{tableName}8_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}8_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 9:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score, {prefix}_{tableName}2, {prefix}_{tableName}2_score, {prefix}_{tableName}3, {prefix}_{tableName}3_score, {prefix}_{tableName}4, {prefix}_{tableName}4_score, {prefix}_{tableName}5, {prefix}_{tableName}5_score, {prefix}_{tableName}6, {prefix}_{tableName}6_score, {prefix}_{tableName}7, {prefix}_{tableName}7_score, {prefix}_{tableName}8, {prefix}_{tableName}8_score, {prefix}_{tableName}9, {prefix}_{tableName}9_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}7_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}8")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}8");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}8_score");
                    }
                    if ((!GradeBook.dtDisplay.Columns.Contains($"{prefix}_{tableName}9")))
                    {
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}9");
                        GradeBook.dtDisplay.Columns.Add($"{prefix}_{tableName}9_score");
                    }

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.SelectCommand = db.cmd;
                        DataTable dataTable1 = new DataTable();
                        db.dta.Fill(dataTable1);

                        GradeBook.newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        GradeBook.newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        GradeBook.newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        GradeBook.newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        GradeBook.newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        GradeBook.newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        GradeBook.newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];
                        GradeBook.newRow[$"{prefix}_{tableName}7_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}7_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}8"] = dataTable1.Rows[0][$"{prefix}_{tableName}8"];
                        GradeBook.newRow[$"{prefix}_{tableName}8_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}8_score"];
                        GradeBook.newRow[$"{prefix}_{tableName}8"] = dataTable1.Rows[0][$"{prefix}_{tableName}9"];
                        GradeBook.newRow[$"{prefix}_{tableName}8_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}9_score"];

                        summation = (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8"]))) + (c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}9_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}9"])));
                        percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
            }
            return percentile;
        }

        //Retrieve Student Name
        public string GetStudentName(string studentID)
        {
            string result = "";
            string commandText = "SELECT CONCAT(student_info.last_name, ', ', student_info.first_name, ' ', student_info.middle_name) AS Name FROM student_info WHERE student_id = @studentID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.dta.SelectCommand = db.cmd;

                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                result = dataTable1.Rows[0]["Name"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return result.Trim();
        }

        //Get Count
        public int GetCount(string prefix, string tableName, int id)
        {
            int count = 0;
            string commandText = $"SELECT count FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @id";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@id", id);
                db.dta.SelectCommand = db.cmd;

                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                count = Convert.ToInt32(dataTable1.Rows[0]["count"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return count;
        }

        //Get Count
        public int GetPercentage(string prefix, string tableName, int id)
        {
            int percentage = 0;
            string commandText = $"SELECT {prefix}_{tableName}_percentage FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @id";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@id", id);
                db.dta.SelectCommand = db.cmd;

                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                percentage = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}_percentage"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return percentage;
        }

    }
}
