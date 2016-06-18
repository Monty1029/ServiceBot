using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceBot
{
    public class Database
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=test.db;Version=3;New=False;Compress=True;");
        }

        private void ExecuteQuery(string queryText)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = queryText;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
    }
}