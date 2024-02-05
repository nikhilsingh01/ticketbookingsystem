using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.model
{
    internal class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        // Default constructor
        public Venue()
        {
            // Default values or initialization logic if needed
        }

        // Overloaded constructor with parameters
        public Venue(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }

        // Method to display venue details
        public void DisplayVenueDetails()
        {
            Console.WriteLine($"Venue Name: {VenueName}");
            Console.WriteLine($"Address: {Address}");
        }

    }
}
