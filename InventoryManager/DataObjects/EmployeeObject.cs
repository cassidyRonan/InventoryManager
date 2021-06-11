using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.DataObjects
{
    public class EmployeeObject : ItemRecord
    {


        public EmployeeObject() { }
        public EmployeeObject(long iD) 
        {
            id = iD;
        }
    }
}
