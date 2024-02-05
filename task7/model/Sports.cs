using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.model
{
    internal class Sports:Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        // Constructor for Sports class
        public Sports(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName,
                      int totalSeats, int availableSeats, decimal ticketPrice,
                      string sportName, string teamsName, eventType EventType)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, availableSeats, ticketPrice, EventType)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        // Override the abstract method from the base class
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Event Type: Sports");
            Console.WriteLine($"Event Name: {EventName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Time: {EventTime}");
            Console.WriteLine($"Venue: {VenueName}");
            Console.WriteLine($"Total Seats: {TotalSeats}");
            Console.WriteLine($"Available Seats: {AvailableSeats}");
            Console.WriteLine($"Ticket Price: {TicketPrice:C}");
            Console.WriteLine($"Sport: {SportName}");
            Console.WriteLine($"Teams: {TeamsName}");
        }
    }
}
