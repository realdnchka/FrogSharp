using System;
using System.Collections.Generic;

namespace test_example1.Helpers
{
    public class CustomerOM
    {
        private int id;
        private string name;
        private string contactName;
        private string address;
        private string city;
        private int postalCode;
        private string country;

        public CustomerOM(int id, string name, string contactName, string address, string city, int postalCode,
            string country)
        {
            this.id = id;
            this.name = name;
            this.contactName = contactName;
            this.address = address;
            this.city = city;
            this.postalCode = postalCode;
            this.country = country;
        }

        public List<string> GetAllData()
        {
            return new List<string>() {id.ToString(), name, contactName, address, city, postalCode.ToString()};
        }

        public string AllDataForSqlRequest()
        {
            return String.Join(", ", GetAllData());
        }
    }
}