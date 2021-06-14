using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.DataObjects
{
    public class JobObject : ItemRecord
    {
        public string JobName
        {
            get { return job_name; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    job_name = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    job_name = value;
                }
            }
        }
        private string job_name;


        public string JobNumber
        {
            get { return job_number; }
            set
            {
                const int CHAR_LIMIT = 100;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    job_number = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    job_number = value;
                }
            }
        }
        private string job_number;


        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string description;

        public string Location
        {
            get { return location; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    location = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    location = value;
                }
            }
        }
        private string location;

        public DateTime StartDate
        {
            get { return start_date; }
            set { start_date = value; }
        }
        private DateTime start_date;

        public DateTime EndDate
        {
            get { return end_date; }
            set { end_date = value; }
        }
        private DateTime end_date;
    }
}
