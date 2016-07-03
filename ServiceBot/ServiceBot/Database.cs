using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServiceBot
{
    public class Database
    {
        //Holds connection with database
        SQLiteConnection m_dbConnection;

        static void Main(string[] args)
        {
            Database d = new Database();
        }

        public Database()
        {
            createNewDatabase();
            connectToDatabase();
            createTable();
            fillTable();
        }
        
        void createNewDatabase()
        {
            SQLiteConnection.CreateFile("testdb.sqlite");
        }

        //Create a connection with database file
        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
        }

        //Create new table
        void createTable()
        {
            string sql = "CREATE TABLE QUERY";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //Inserts some values into table
        void fillTable()
        {
            string sql = "INSERT INTO TABLE QUERY";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "ANOTHER INSERT INTO TABLE QUERY";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "ANOTHER INSERT INTO TABLE QUERY";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
    }
}