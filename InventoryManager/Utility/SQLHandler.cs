using InventoryManager.DataObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;


namespace InventoryManager.Utility
{
    static public class SQLHandler
    {
        const string CLIENT_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS ClientTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              Company_Name VARCHAR(250) NOT NULL,
                              First_Name VARCHAR(50) NOT NULL,
                              Last_Name VARCHAR(50) NOT NULL,
                              Email VARCHAR(128),
                              Phone VARCHAR(30),
                              Address VARCHAR(250)
                              );";

        public static void Save()
        {
        }

        public static void Load()
        {

        }

        /// <summary>
        /// Creates a new SQLite Database at the specified filepath with the predetermined schema.
        /// </summary>
        /// <param name="filePath">The file location where the SQLite Database will be created.</param>
        public static void CreateNewDB(string filePath)
        {
            //Initial Creation of the SQLite file.
            SQLiteConnection.CreateFile(string.Concat(filePath,"InventoryDB.sqlite"));

            //Connect to the SQLite database
            SQLiteConnection db_connection = new SQLiteConnection(string.Concat("Data Source=",filePath,"InventoryDB.sqlite;"));
            db_connection.Open();

            //Execute non-query commands to create the structure of the database and varying tables.
            //TODO: Give option to read in schema externally to allow user to specify the structure themselves if desired. (Will need formatting check)

            //Creation of Client Table
            ExecuteNonQuery(CLIENT_TABLE_CREATE_LINE, db_connection);

            //Creation of Job Table
            //ExecuteNonQuery("", db_connection);


            //Closing of SQLite DB connection
            db_connection.Close();
        }


        /// <summary>
        /// Executes a non-query operation on the connected SQLite database. Intended use is for creation of tables.
        /// </summary>
        /// <param name="sql">SQL instructions to execute on the SQLite Database.</param>
        /// <param name="connection">The SQLite connection object; ensure the connection is open.</param>
        private static void ExecuteNonQuery(string sql, SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
