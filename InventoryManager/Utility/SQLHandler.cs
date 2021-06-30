using InventoryManager.DataObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;


namespace InventoryManager.Utility
{
    static public class SQLHandler
    {
        const string DB_FILENAME = "InventoryDB.sqlite";

        const string CLIENT_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS ClientTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              Company_Name VARCHAR(250) NOT NULL,
                              First_Name VARCHAR(50) NOT NULL,
                              Last_Name VARCHAR(50) NOT NULL,
                              Email VARCHAR(128),
                              Phone VARCHAR(30),
                              Address VARCHAR(250)
                              );";

        const string JOBCLIENT_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS JobClientTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              JobID INTEGER NOT NULL,
                              ClientID INTEGER NOT NULL 
                              );";

        const string JOB_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS JobTable(
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              Job_Name VARCHAR(250) NOT NULL,
                              Job_Number VARCHAR(100) NOT NULL,
                              Description TEXT,
                              Location VARCHAR(250),
                              Start_Date DATE,
                              End_Date DATE
                              );";

        const string EQUIPMENTJOB_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS EquipmentJobTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              JobID INTEGER NOT NULL,
                              EquipmentID INTEGER NOT NULL 
                              );";

        const string EMPLOYEE_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS EmployeeTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              First_Name VARCHAR(50) NOT NULL,
                              Last_Name VARCHAR(50) NOT NULL,
                              Email VARCHAR(128),
                              Phone VARCHAR(30),
                              Address VARCHAR(250)
                              );";

        const string EQUIPMENTEMPLOYEE_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS EquipmentJobTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              EmployeeID INTEGER NOT NULL,
                              EquipmentID INTEGER NOT NULL 
                              );";

        const string EQUIPMENT_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS EquipmentTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              Name VARCHAR(250) NOT NULL,
                              Description TEXT,
                              Barcode VARCHAR(50),
                              Group_Barcode VARCHAR(50),
                              Serial_Number VARCHAR(100),
                              Category VARCHAR(100),
                              Type VARCHAR(100),
                              Manufacturer VARCHAR(250),
                              Model VARCHAR(250),
                              Location VARCHAR(250),
                              Calibration_One_Date DATE,
                              Calibration_Two_Date DATE,
                              Last_Modified DATE,
                              State VARCHAR(16),
                              Image_Path VARCHAR(250),
                              Certificate_Path VARCHAR(250)
                              );";

        const string EQUIPMENT_LOG_TABLE_CREATE_LINE = @"CREATE TABLE IF NOT EXISTS EquipmentLogTable (
                              ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                              EquipmentID INTEGER NOT NULL,
                              EmployeeID INTEGER NOT NULL,
                              Details VARCHAR(250),
                              State VARCHAR(25),
                              ReturnDate DATE );";


        //CRUD OPERATIONS

        /// <summary>
        /// Creates a new SQLite Database at the specified filepath with the predetermined schema.
        /// </summary>
        /// <param name="filePath">The file location where the SQLite Database will be created.</param>
        public static void CreateNewDB(string filePath)
        {
            //Ensure that table does not already exist.
            if(!File.Exists(string.Concat(filePath,DB_FILENAME)))
            {
                //Initial Creation of the SQLite file.
                SQLiteConnection.CreateFile(string.Concat(filePath, DB_FILENAME));

                //Connect to the SQLite database
                SQLiteConnection db_connection = new SQLiteConnection(string.Concat("Data Source=",filePath,DB_FILENAME,";"));
                db_connection.Open();

                //Execute non-query commands to create the structure of the database and varying tables.
                //TODO: Give option to read in schema externally to allow user to specify the structure themselves if desired. (Will need formatting check)

                //Creation of Client Table
                ExecuteNonQuery(CLIENT_TABLE_CREATE_LINE, db_connection);

                //Creation of Job-Client Table for keeping track of what jobs belong to clients
                ExecuteNonQuery(JOBCLIENT_TABLE_CREATE_LINE, db_connection);

                //Creation of Job Table
                ExecuteNonQuery(JOB_TABLE_CREATE_LINE, db_connection);

                //Creation of Equipment Table for keeping track of equipment
                ExecuteNonQuery(EQUIPMENT_TABLE_CREATE_LINE, db_connection);

                //Creation of Equipment-Job Table for keeping track of what equipment belongs to a job
                ExecuteNonQuery(EQUIPMENTJOB_TABLE_CREATE_LINE, db_connection);

                //Creation of Employee Table
                ExecuteNonQuery(EMPLOYEE_TABLE_CREATE_LINE, db_connection);

                //Creation of Equipment-Employee Table for keeping track of what equipment is checked out by an employee
                ExecuteNonQuery(EQUIPMENTEMPLOYEE_TABLE_CREATE_LINE, db_connection);

                //Creation of Equipment Log Table for recording of any equipment damages on return
                ExecuteNonQuery(EQUIPMENT_LOG_TABLE_CREATE_LINE, db_connection);

                //Closing of SQLite DB connection
                db_connection.Close();

            }
        }

        public static long InsertIntoDB(string filePath, string sqlStatement)
        {
            //Ensure that sqlite file exists.
            if (File.Exists(string.Concat(filePath, DB_FILENAME)))
            {
                //Connect to the SQLite database
                SQLiteConnection db_connection = new SQLiteConnection(string.Concat("Data Source=", filePath, DB_FILENAME, ";"));
                db_connection.Open();


                ExecuteScalar(sqlStatement, db_connection);

                //Get id of inserted record
                long rowID = db_connection.LastInsertRowId;

                //Closing of SQLite DB connection
                db_connection.Close();

                //Return ID of inserted item
                return rowID;
            }

            //Return negative value if the file does not exist
            return -1;
        }

        public static void UpdateIntoDB(string filePath, string sqlStatement)
        {
            //Ensure that sqlite file exists.
            if (File.Exists(string.Concat(filePath, DB_FILENAME)))
            {
                //Connect to the SQLite database
                SQLiteConnection db_connection = new SQLiteConnection(string.Concat("Data Source=", filePath, DB_FILENAME, ";"));
                db_connection.Open();

                ExecuteScalar(sqlStatement, db_connection);

                //Closing of SQLite DB connection
                db_connection.Close();
            }

        }

        public static List<Dictionary<string, TypeValuePair>> SelectFromDB(string filePath,string sqlStatement)
        {
            //Ensure that sqlite file exists.
            if (File.Exists(string.Concat(filePath, DB_FILENAME)))
            {
                //Connect to the SQLite database
                SQLiteConnection db_connection = new SQLiteConnection(string.Concat("Data Source=", filePath, DB_FILENAME, ";"));
                db_connection.Open();

                //Execute non-query commands to create the structure of the database and varying tables.
                //TODO: Give option to read in schema externally to allow user to specify the structure themselves if desired. (Will need formatting check)

                //Creation of Client Table
                List<Dictionary<string,TypeValuePair>> data = ExecuteReader(sqlStatement, db_connection);

                //Closing of SQLite DB connection
                db_connection.Close();

                return data;
            }

            return null;
        }




        //SQL Execution Commands

        /// <summary>
        /// Executes a non-query operation on the connected SQLite database. Intended use is for creation of tables.
        /// </summary>
        /// <param name="sql">SQL instructions to execute on the SQLite Database.</param>
        /// <param name="connection">The SQLite connection object; ensure the connection is open.</param>
        private static void ExecuteNonQuery(string sql, SQLiteConnection connection)
        {
            //Creation of SQLite command object and initialisation
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            //Execute the command
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a scalar operation on the connected SQLite database. Intended use is for insertion of data into tables.
        /// </summary>
        /// <param name="sql">SQL instructions to execute on the SQLite Database.</param>
        /// <param name="connection">The SQLite connection object; ensure the connection is open.</param>
        private static object ExecuteScalar(string sql, SQLiteConnection connection)
        {
            //Creation of SQLite command object and initialisation
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            //Execute the command
            return command.ExecuteScalar();
        }

        /// <summary>
        /// Executes a scalar operation on the connected SQLite database. Intended use is for reading of data from tables.
        /// </summary>
        /// <param name="sql">SQL instructions to execute on the SQLite Database.</param>
        /// <param name="connection">The SQLite connection object; ensure the connection is open.</param>
        /// <returns>Returns a string and TypeValuePair dictionary to retrieve all values and cast appropriately.</returns>
        private static List<Dictionary<string,TypeValuePair>> ExecuteReader(string sql, SQLiteConnection connection)
        {
            //Creation of SQLite command object and initialisation
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            //Execute the command
            SQLiteDataReader reader = command.ExecuteReader();

            //Instantiate dictionary to hold field name and a TypeValuePair to correctly cast value out.

            List<Dictionary<string, TypeValuePair>> records = new List<Dictionary<string, TypeValuePair>>();

            while (reader.Read())
            {
                Dictionary<string, TypeValuePair> values = new Dictionary<string, TypeValuePair>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    values.Add(reader.GetName(i),new TypeValuePair(reader.GetFieldType(i),reader.GetValue(i)));
                }
                records.Add(values);
            }

            return records; 
        }
    }


    /// <summary>
    /// A simple struct containing the type of an object and the object iself.
    /// </summary>
    public struct TypeValuePair
    {
        public TypeValuePair(Type type,object obj)
        {
            ObjType = type;
            Obj = obj;
        }

        public Type ObjType { get; set; }
        public Object Obj { get; set; }
    }
}
