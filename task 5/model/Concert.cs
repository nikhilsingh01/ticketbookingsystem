using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_5.model.Event;

namespace task_5.model
{
    internal class Concert:Event
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; }
        public DateTime Date { get; }
        public TimeSpan Time { get; }
        public int TotalSeats1 { get; }
        public int TotalSeats2 { get; }

        // Default Constructor
        public Concert() : base()
        {
            // Set default values or leave them uninitialized based on your requirements
            Artist = "Unknown";
            ConcertType = "Unknown";
        }

        // Overloaded Constructor with Customer Attributes
        public Concert(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName,
                       int totalSeats, int availableSeats, decimal ticketPrice, eventType eventType,
                       string artist, string concertType)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, availableSeats, ticketPrice, eventType)
        {
            Artist = artist;
            ConcertType = concertType;
        }

        public Concert(string eventName, DateTime date, TimeSpan time, string venueName, int totalSeats1, int totalSeats2, decimal ticketPrice)
        {
            EventName = eventName;
            Date = date;
            Time = time;
            VenueName = venueName;
            TotalSeats1 = totalSeats1;
            TotalSeats2 = totalSeats2;
            TicketPrice = ticketPrice;
        }

        // Getter and Setter Methods for Concert subclass attributes
        public string GetArtist()
        {
            return Artist;
        }

        public void SetArtist(string artist)
        {
            Artist = artist;
        }

        public string GetConcertType()
        {
            return ConcertType;
        }

        public void SetConcertType(string concertType)
        {
            ConcertType = concertType;
        }

        
        public void DisplayConcertDetails()
        {
            base.DisplayEventDetails(); // Call the base class method to display common event details
            Console.WriteLine($"Artist: {Artist}");
            Console.WriteLine($"Concert Type: {ConcertType}");
        }
    }
}
