using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.DataObjects
{
    public class EquipmentObject : ItemRecord
    {
        public string Name
        {
            get { return name; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    name = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    name = value;
                }
            }
        }
        private string name;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string description;

        public string Barcode
        {
            get { return barcode; }
            set
            {
                const int CHAR_LIMIT = 50;

                //Ensure that passed in string value is less than or equal to 50 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    barcode = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    barcode = value;
                }
            }
        }
        private string barcode;

        public string GroupBarcode
        {
            get { return group_barcode; }
            set
            {
                const int CHAR_LIMIT = 50;

                //Ensure that passed in string value is less than or equal to 50 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    group_barcode = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    group_barcode = value;
                }
            }
        }
        private string group_barcode;

        public string SerialNumber
        {
            get { return serial_number; }
            set
            {
                const int CHAR_LIMIT = 100;

                //Ensure that passed in string value is less than or equal to 100 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    serial_number = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    serial_number = value;
                }
            }
        }
        private string serial_number;

        public string Category
        {
            get { return category; }
            set
            {
                const int CHAR_LIMIT = 100;

                //Ensure that passed in string value is less than or equal to 100 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    category = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    category = value;
                }
            }
        }
        private string category;

        public string Type
        {
            get { return type; }
            set
            {
                const int CHAR_LIMIT = 100;

                //Ensure that passed in string value is less than or equal to 100 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    type = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    type = value;
                }
            }
        }
        private string type;

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    manufacturer = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    manufacturer = value;
                }
            }
        }
        private string manufacturer;

        public string Model
        {
            get { return model; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    model = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    model = value;
                }
            }
        }
        private string model;

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

        public DateTime CalibrationOneDate
        {
            get { return calibration_one_date; }
            set { calibration_one_date = value; }
        }
        private DateTime calibration_one_date;

        public DateTime CalibrationTwoDate
        {
            get { return calibration_two_date; }
            set { calibration_two_date = value; }
        }
        private DateTime calibration_two_date;

        public DateTime LastModified
        {
            get { return last_modified; }
            set { last_modified = value; }
        }
        private DateTime last_modified;

        public string State
        {
            get { return state; }
            set
            {
                const int CHAR_LIMIT = 16;

                //Ensure that passed in string value is less than or equal to 16 to fit with SQLite table
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

        public string ImagePath
        {
            get { return image_path; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    image_path = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    image_path = value;
                }
            }
        }
        private string image_path;

        public string CertificatePath
        {
            get { return certificate_path; }
            set
            {
                const int CHAR_LIMIT = 250;

                //Ensure that passed in string value is less than or equal to 250 to fit with SQLite table
                if (value.Length > CHAR_LIMIT)
                {
                    certificate_path = value.Substring(0, CHAR_LIMIT);
                }
                else
                {
                    certificate_path = value;
                }
            }
        }
        private string certificate_path;
    }
}
