using InventoryManager.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Utility
{
    public enum SQLTable { Client, Employee, Equipment, Job }

    /// <summary>
    /// Data Access Layer for Inventory such as ItemRecords, contains CRUD operations for each core section such as Clients, Jobs, Equipment and Employees.
    /// </summary>
    public static class InventoryDAL
    {
        public static void AddItem(ClientObject client)
        {

        }

        public static ClientObject GetClient(long id)
        {
            return SQLConverter.Convert<ClientObject>(SQLHandler.SelectFromDB(@"C:\Users\ronan\Documents\Test\", string.Concat("SELECT * FROM ClientTable WHERE ID =",id,";"))[0]) as ClientObject;
        }

        public static List<ClientObject> GetClients()
        {
            return SQLConverter.ConvertList<ClientObject>(SQLHandler.SelectFromDB(@"C:\Users\ronan\Documents\Test\", "SELECT * FROM ClientTable;"));
        }

        public static List<ClientObject> GetClients(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            return SQLConverter.ConvertList<ClientObject>(SQLHandler.SelectFromDB(@"C:\Users\ronan\Documents\Test\", string.Concat("SELECT * FROM ClientTable WHERE lower(Company_Name) LIKE '",searchTerm, "' OR lower(First_Name) LIKE '", searchTerm, "' OR lower(Last_Name) LIKE '", searchTerm, "' OR lower(Email) LIKE '", searchTerm, "' OR lower(Phone) LIKE '", searchTerm, "' OR lower(Address) LIKE '", searchTerm, "';")));
        }

        public static void UpdateItem(ClientObject client)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteItem(long id,SQLTable table)
        {

        }

    }
}
