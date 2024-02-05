using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.model
{
    internal class Booking
    {
        private static int nextBookingId = 1;

        public int BookingId { get; private set; }
        public Customer[] Customers { get; set; }
        public Event Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        // Default constructor
        public Booking()
        {
            BookingId = nextBookingId++;
            BookingDate = DateTime.Now;
        }

        // Overloaded constructor with parameters
        public Booking(Customer[] customers, Event eventObj, int numTickets, decimal totalCost)
            : this()
        {
            if (customers.Length != numTickets)
            {
                throw new ArgumentException("Number of customers must match the number of tickets.");
            }

            Customers = customers;
            Event = eventObj;
            NumTickets = numTickets;
            TotalCost = totalCost;
        }

        // Method to display booking details
        public void DisplayBookingDetails()
        {
            Console.WriteLine($"Booking ID: {BookingId}");
            Console.WriteLine("Customers:");
            foreach (Customer customer in Customers)
            {
                Console.WriteLine($"  - {customer.CustomerName}");
            }
            Console.WriteLine($"Event: {Event.EventName}");
            Console.WriteLine($"Number of Tickets: {NumTickets}");
            Console.WriteLine($"Total Cost: {TotalCost:C}");
            Console.WriteLine($"Booking Date: {BookingDate}");
        }
    }
}
