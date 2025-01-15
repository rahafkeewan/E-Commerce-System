using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public void UpdateDetails(string name, string address, string contact)
        {
            Name = name;
            Address = address;
            Contact = contact;
            Console.WriteLine("Customer information updated successfully.");
        }
    }

}
