using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.DataObjects
{
    public class ClientObject : ItemRecord
    {
        /// <summary>
        /// The name of the company which the client works at or represents, limited to 250 characters.
        /// </summary>
        public string CompanyName { 
            get { return company_name; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    company_name = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    company_name = value;
                }
            } 
        }
        private string company_name;
        
        /// <summary>
        /// The first name of the client, limited to 50 characters.
        /// </summary>
        public string FirstName
        {
            get { return first_name; }
            set
            {
                const int CHAR_LIMIT = 50;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    first_name = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    first_name = value;
                }
            }
        }
        private string first_name;

        /// <summary>
        /// The last name of the client, limited to 50 characters.
        /// </summary>
        public string LastName
        {
            get { return last_name; }
            set
            {
                const int CHAR_LIMIT = 50;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    last_name = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    last_name = value;
                }
            }
        }
        private string last_name;

        /// <summary>
        /// The email address of the client, limited to 128 characters.
        /// </summary>
        public string Email
        {
            get { return email; }
            set
            {
                const int CHAR_LIMIT = 128;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    email = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    email = value;
                }
            }
        }
        private string email;
        
        /// <summary>
        /// The phone number of the client, limited to 30 characters.
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set
            {
                const int CHAR_LIMIT = 30;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    phone = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    phone = value;
                }
            }
        }
        private string phone;

        /// <summary>
        /// The address of the client, limited to 250 characters.
        /// </summary>
        public string Address
        {
            get { return address; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    address = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    address = value;
                }
            }
        }
        private string address;



        public ClientObject() { }
        public ClientObject(long iD, string companyName, string firstName, string lastName, string email, string phone, string address)
        {
            ID = iD;
            CompanyName = companyName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }


        public override string ToString()
        {
            return string.Concat(id," - ",company_name," - ",first_name);
        }

    }
}
