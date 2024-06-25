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

        private GradeBook g;
        public GetRecordQuery(GradeBook gradeBook)
        {
            g = gradeBook;
        }

        public GetRecordQuery()
        {

        }
        public string GetName(string tableName, string columnName, string userID)
        {
            string command = $"SELECT {columnName} FROM {tableName}_info WHERE {tableName}_id = @userID";

            string name = "";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = command;

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@userID", userID);

                db.dta.SelectCommand = db.cmd;
                DataTable dt = new DataTable();
                db.dta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    name = dt.Rows[0][$"{columnName}"].ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }
            return name;
        }

        //Get records per student and add to datatable

        //Project and Exam
        public decimal GetRecordRdo(string prefix, string tableName, int ID, DataRow newRow)
        {
            int score = 0;
            int totalScore = 0;
            decimal percentile = 0;
            string commandText = $"SELECT {prefix}_{tableName}, {prefix}_{tableName}_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

            if (!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}_score"))
            {
                g.dtDisplay.Columns.Add($"{prefix}_{tableName}_score");
            }
            if (!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}"))
            {
                g.dtDisplay.Columns.Add($"{prefix}_{tableName}");
            }

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@ID", ID);
                db.dta.SelectCommand = db.cmd;

                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                if (dataTable1.Rows.Count > 0)
                {
                    newRow[$"{prefix}_{tableName}_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}_score"];
                    newRow[$"{prefix}_{tableName}"] = dataTable1.Rows[0][$"{prefix}_{tableName}"];

                    score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}_score"]);
                    totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}"]);

                    if (score != -1 && totalScore != -1)
                    {
                        percentile = c.PercentileRdo(score, totalScore);
                    }
                }
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


        //Other
        public decimal GetRecordsOther(string prefix, string tableName, int ID, int count, DataRow newRow)
        {
            int score = 0;
            int totalScore = 0;
            decimal standardized = 0;
            decimal percentile = 0;
            decimal summation = 0;
            string commandText = "";
            switch (count)
            {
                case 1:
                    commandText = $"SELECT {prefix}_{tableName}1, {prefix}_{tableName}1_score FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation = c.ScoreStandardization(Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]), Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]));
                            percentile = c.Percentile(GetPercentage(prefix, tableName, ID), summation);
                        }
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;
                            
                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }

                        summation = summation / count;
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        summation = summation / count;
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        summation = summation / count;
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        summation = summation / count;
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];
                        newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        summation = summation / count;
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}7_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];
                        newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        newRow[$"{prefix}_{tableName}7_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}7_score"];
                        newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        summation = summation / count;
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}7_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}8")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}8_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}8");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];
                        newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        newRow[$"{prefix}_{tableName}7_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}7_score"];
                        newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];
                        newRow[$"{prefix}_{tableName}8_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}8_score"];
                        newRow[$"{prefix}_{tableName}8"] = dataTable1.Rows[0][$"{prefix}_{tableName}8"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        summation = summation / count;
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
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}1")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}1");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}2")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}2");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}3")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}3");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}4")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}4");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}5")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}5");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}6")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}6");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}7")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}7_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}7");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}8")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}8_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}8");
                    }
                    if ((!g.dtDisplay.Columns.Contains($"{prefix}_{tableName}9")))
                    {
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}9_score");
                        g.dtDisplay.Columns.Add($"{prefix}_{tableName}9");
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

                        newRow[$"{prefix}_{tableName}1_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}1_score"];
                        newRow[$"{prefix}_{tableName}1"] = dataTable1.Rows[0][$"{prefix}_{tableName}1"];
                        newRow[$"{prefix}_{tableName}2_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}2_score"];
                        newRow[$"{prefix}_{tableName}2"] = dataTable1.Rows[0][$"{prefix}_{tableName}2"];
                        newRow[$"{prefix}_{tableName}3_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}3_score"];
                        newRow[$"{prefix}_{tableName}3"] = dataTable1.Rows[0][$"{prefix}_{tableName}3"];
                        newRow[$"{prefix}_{tableName}4_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}4_score"];
                        newRow[$"{prefix}_{tableName}4"] = dataTable1.Rows[0][$"{prefix}_{tableName}4"];
                        newRow[$"{prefix}_{tableName}5_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}5_score"];
                        newRow[$"{prefix}_{tableName}5"] = dataTable1.Rows[0][$"{prefix}_{tableName}5"];
                        newRow[$"{prefix}_{tableName}6_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}6_score"];
                        newRow[$"{prefix}_{tableName}6"] = dataTable1.Rows[0][$"{prefix}_{tableName}6"];
                        newRow[$"{prefix}_{tableName}7_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}7_score"];
                        newRow[$"{prefix}_{tableName}7"] = dataTable1.Rows[0][$"{prefix}_{tableName}7"];
                        newRow[$"{prefix}_{tableName}8_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}8_score"];
                        newRow[$"{prefix}_{tableName}8"] = dataTable1.Rows[0][$"{prefix}_{tableName}8"];
                        newRow[$"{prefix}_{tableName}9_score"] = dataTable1.Rows[0][$"{prefix}_{tableName}9_score"];
                        newRow[$"{prefix}_{tableName}9"] = dataTable1.Rows[0][$"{prefix}_{tableName}9"];

                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}1"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}2"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}3"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}4"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}5"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}6"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}7"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}8"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        score = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}9_score"]);
                        totalScore = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}9"]);
                        if (score != -1 || totalScore != -1)
                        {
                            standardized = c.ScoreStandardization(score, totalScore);
                            summation += standardized;

                        }
                        summation = summation / count;
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
            //DEBUGGING TOOL
            //MessageBox.Show(percentile.ToString());
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
