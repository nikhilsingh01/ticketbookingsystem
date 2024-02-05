using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.model
{
    internal class Customer
    {
        private int customerid;
        private string customerName;
        private string email;
        private string phoneNumber;


        public Customer()
        {

        }


        public Customer(int customerid, string customerName, string email, string phoneNumber)
        {
            this.customerid = customerid;
            this.customerName = customerName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }


        public int customerID
        {
            get { return customerid; }
            set { customerid = value; }
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
    }
}
