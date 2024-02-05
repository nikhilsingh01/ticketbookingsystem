using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.models
{
    internal class Customer
    {
        private int customerID;
        private string customerName;
        private string email;
        private string phoneNumber;


        public Customer()
        {

        }


        public Customer(string customerName, string email, string phoneNumber)
        {
            this.customerName = customerName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }


        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }


        public void DisplayCustomerDetails()
        {
            Console.WriteLine("Customer Details:");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
        }
    }
}
