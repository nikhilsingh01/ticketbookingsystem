using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4.model
{
    internal class Venue
    {
     
            
            private string venueName;
            private string address;

           
            public Venue()
            {
                
            }

            
            public Venue(string venueName, string address)
            {
                this.venueName = venueName;
                this.address = address;
            }

            // Getter and Setter methods
            public string VenueName
            {
                get { return venueName; }
                set { venueName = value; }
            }

            public string Address
            {
                get { return address; }
                set { address = value; }
            }

            
            public void DisplayVenueDetails()
            {
                Console.WriteLine("Venue Details:");
                Console.WriteLine($"Venue Name: {venueName}");
                Console.WriteLine($"Address: {address}");
            }
        }
    }


