using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.model
{
    internal class Concert:Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        // Constructor for Concert class
        public Concert(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName,
                       int totalSeats, int availableSeats, decimal ticketPrice,
                       string artist, string type,eventType EventType)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, availableSeats, ticketPrice,EventType)
        {
            Artist = artist;
            Type = type;
        }

        // Override the abstract method from the base class
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Event Type: Concert");
            Console.WriteLine($"Event Name: {EventName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Time: {EventTime}");
            Console.WriteLine($"Venue: {VenueName}");
            Console.WriteLine($"Total Seats: {TotalSeats}");
            Console.WriteLine($"Available Seats: {AvailableSeats}");
            Console.WriteLine($"Ticket Price: {TicketPrice:C}");
            Console.WriteLine($"Artist: {Artist}");
            Console.WriteLine($"Type: {Type}");
        }
    }

}
