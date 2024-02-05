using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6.model
{
    internal class Movie : Event
    {
        private string? actressName1;
        private string? actressName2;
        private eventType eventType1;

        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName,
                 int totalSeats, int availableSeats, decimal ticketPrice,
                 string genre, string actorName, string actressName,eventType eventType)
        : base(eventName, eventDate, eventTime, venueName, totalSeats, availableSeats, ticketPrice,eventType)
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }

        
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Event Type: Movie");
            Console.WriteLine($"Event Name: {EventName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Time: {EventTime}");
            Console.WriteLine($"Venue: {VenueName}");
            Console.WriteLine($"Total Seats: {TotalSeats}");
            Console.WriteLine($"Available Seats: {AvailableSeats}");
            Console.WriteLine($"Ticket Price: {TicketPrice:C}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Actor: {ActorName}");
            Console.WriteLine($"Actress: {ActressName}");
        }
    }
}
