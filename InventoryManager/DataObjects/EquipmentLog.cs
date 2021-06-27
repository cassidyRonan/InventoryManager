using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.DataObjects
{
    public class EquipmentLog : ItemRecord
    {
        public long EquipmentID
        {
            get { return equipment_id; }
            set
            {
                equipment_id = value;
            }
        }
        protected long equipment_id;

        public long EmployeeID
        {
            get { return employee_id; }
            set
            {
                employee_id = value;
            }
        }
        protected long employee_id;

        public string Details
        {
            get { return details; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    details = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    details = value;
                }
            }
        }
        private string details;

        public string State
        {
            get { return state; }
            set
            {
                const int CHAR_LIMIT = 25;

                //Ensure that passed in string value is less than or equal to 25 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    state = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    state = value;
                }
            }
        }
        private string state;

        public DateTime ReturnDate
        {
            get { return return_date; }
            set { return_date = value; }
        }
        private DateTime return_date;
    }
}
