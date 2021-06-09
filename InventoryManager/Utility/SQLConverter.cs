using InventoryManager.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace InventoryManager.Utility
{
    public static class SQLConverter
    {

        /// <summary>
        /// Takes the object's data and converts it to a string for inserting the object into a SQLite table.
        /// </summary>
        /// <param name="tableName">The name of the SQLite table which the record will be inserted into.</param>
        /// <returns>Returns a SQL statement used for inserting the object into a SQLite database or the sepcified table.</returns>

        public static string InsertStatement(string tableName, ClientObject client)
        {
            return string.Concat("INSERT INTO ", tableName, " (Company_Name, First_Name, Last_Name, Email, Phone, Address)", " VALUES ", "(\'", client.CompanyName, "\',\'", client.FirstName, "\',\'", client.LastName, "\',\'", client.Email, "\',\'", client.Phone, "\',\'", client.Address, "\');");
        }



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
    }
}
