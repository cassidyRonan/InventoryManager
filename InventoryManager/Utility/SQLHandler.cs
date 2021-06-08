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
        public static void Save()
        {
        }

        public static void Load()
        {

        }

        public static void CreateNewDB(string filePath)
        {
            SQLiteConnection.CreateFile(string.Concat(filePath,"InventoryDB.sqlite"));

            SQLiteConnection db_connection = new SQLiteConnection(string.Concat("Data Source=",filePath,"InventoryDB.sqlite;"));
            db_connection.Open();

            ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS [ClientTable] (
                              [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              );", db_connection);

            ExecuteNonQuery("", db_connection);

            db_connection.Close();
        }

        private static void ExecuteNonQuery(string sql, SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
