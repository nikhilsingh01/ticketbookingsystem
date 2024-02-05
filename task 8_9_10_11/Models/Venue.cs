using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11.Models
{
    internal class Venue
    {
        public int venueId { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }

        // Default constructor
        public Venue()
        {
            // Default values or initialization logic if needed
        }

        // Overloaded constructor with parameters
        public Venue(int venueId, string venueName, string address)
        {
            this.venueId = venueId;
            VenueName = venueName;
            Address = address;
        }

    }
}
