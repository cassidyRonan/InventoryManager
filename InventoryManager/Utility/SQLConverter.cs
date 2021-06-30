using InventoryManager.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace InventoryManager.Utility
{
    public static class SQLConverter
    {
        #region Insert Statements

        /// <summary>
        /// Takes the object's data and converts it to a string for inserting the object into a SQLite table.
        /// </summary>
        /// <param name="tableName">The name of the SQLite table which the record will be inserted into.</param>
        /// <returns>Returns a SQL statement used for inserting the object into a SQLite database or the sepcified table.</returns>

        public static string InsertStatement(string tableName, ClientObject client)
        {
            return string.Concat("INSERT INTO ", tableName, " (Company_Name, First_Name, Last_Name, Email, Phone, Address)", " VALUES ", "(\'", client.CompanyName, "\',\'", client.FirstName, "\',\'", client.LastName, "\',\'", client.Email, "\',\'", client.Phone, "\',\'", client.Address, "\');");
        }

        public static string InsertStatement(string tableName, EmployeeObject employee)
        {
            return string.Concat("INSERT INTO ", tableName, " (First_Name, Last_Name, Email, Phone, Address)", " VALUES ", "(\'", employee.FirstName, "\',\'", employee.LastName, "\',\'", employee.Email, "\',\'", employee.Phone, "\',\'", employee.Address, "\');");
        }

        public static string InsertStatement(string tableName, EquipmentLog log)
        {
            return string.Concat("INSERT INTO ", tableName, " (EquipmentID, EmployeeID, Details, State, ReturnDate)", " VALUES ", "(\'", log.EquipmentID, "\',\'", log.EmployeeID, "\',\'", log.Details, "\',\'", log.State, "\',\'", log.ReturnDate.ToSQL(), "\');");
        }

        public static string InsertStatement(string tableName, EquipmentObject equipment)
        {
            return string.Concat("INSERT INTO ", tableName, " (Name, Description, Barcode, Group_Barcode, Serial_Number, Category, Type, Manufacturer, Model, Location, Calibration_One_Date, Calibration_Two_Date, Last_Modified, State, Image_Path, Certificate_Path)", " VALUES ", "(\'", equipment.Name, "\',\'", equipment.Description, "\',\'", equipment.Barcode, "\',\'", equipment.GroupBarcode, "\',\'", equipment.SerialNumber, "\',\'", equipment.Category, "\',\'", equipment.Type, "\',\'", equipment.Manufacturer, "\',\'", equipment.Model, "\',\'", equipment.Location, "\',\'", equipment.CalibrationOneDate.ToSQL(), "\',\'", equipment.CalibrationTwoDate.ToSQL(), "\',\'", equipment.LastModified, "\',\'", equipment.State, "\',\'", @equipment.ImagePath, "\',\'", @equipment.CertificatePath, "\');");
        }

        public static string InsertStatement(string tableName, JobObject client)
        {
            return string.Concat("INSERT INTO ", tableName, " (Job_Name, Job_Number, Description, Location, Start_Date, End_Date)", " VALUES ", "(\'", client.JobName, "\',\'", client.JobNumber, "\',\'", client.Description, "\',\'", client.Location, "\',\'", client.StartDate.ToSQL(), "\',\'", client.EndDate.ToSQL(), "\');");
        }

        public static string InsertStatement(string tableName, List<string> values)
        {
            StringBuilder stringBuild = new StringBuilder("INSERT INTO ");
            stringBuild.Append(tableName);
            stringBuild.Append(" VALUES ");
            stringBuild.Append("(\'");
            for (int i = 0; i < values.Count - 1; i++)
            {
                stringBuild.Append(values[i]);
                stringBuild.Append("\',\'");
            }
            stringBuild.Append(values[values.Count - 1]);
            stringBuild.Append("\');");
            return stringBuild.ToString(); 
            
                //string.Concat("INSERT INTO ", tableName, " VALUES ", "(\'", idOne, "\',\'", idTwo, "\');");
        }

        #endregion


        #region Read Statements

        public static void ReadStatement(string tableName, long id)
        {

        }

        #endregion




        private enum RecordCastType { Client };

        public static List<T> ConvertList<T>(List<Dictionary<string,TypeValuePair>> list) where T : ItemRecord
        {
            //Create list of specified object where object is a child of ItemRecord
            List<T> convertedList = new List<T>();

            //Convert each dictionary into an object of type T
            foreach (var dict in list)
            {
                convertedList.Add(Convert<ClientObject>(dict) as T);
            }

            return convertedList;
        }

        public static object Convert<T>(Dictionary<string, TypeValuePair> dictionary)
        {
            switch (CastAs(typeof(T)))
            {
                case RecordCastType.Client:
                    return new ClientObject((long)dictionary["ID"].Obj,
                                            (string)dictionary["Company_Name"].Obj,
                                            (string)dictionary["First_Name"].Obj,
                                            (string)dictionary["Last_Name"].Obj,
                                            (string)dictionary["Email"].Obj,
                                            (string)dictionary["Phone"].Obj,
                                            (string)dictionary["Address"].Obj);

                default:
                    return null;
            }
        }

        private static RecordCastType CastAs(Type T)
        {
            RecordCastType castType;

            if(T == typeof(ClientObject))
            {
                castType = RecordCastType.Client;
            }
            else
            {
                throw new InvalidOperationException("The passed in type is not a child of ItemRecord.");
            }

            return castType;
        }

        private static string ToSQL(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }


  
}
