using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_5.model.Event;

namespace task_5.model
{
    internal class Movie:Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }
        public DateTime Date { get; }
        public TimeSpan Time { get; }
        public int TotalSeats1 { get; }
        public int TotalSeats2 { get; }

        // Default Constructor
        public Movie() : base()
        {
            // Set default values or leave them uninitialized based on your requirements
            Genre = "Unknown";
            ActorName = "Unknown";
            ActressName = "Unknown";
        }

        // Overloaded Constructor with Customer Attributes
        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName,
                     int totalSeats, int availableSeats, decimal ticketPrice, eventType eventType,
                     string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, availableSeats, ticketPrice, eventType)
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }

        public Movie(string eventName, DateTime date, TimeSpan time, string venueName, int totalSeats1, int totalSeats2, decimal ticketPrice)
        {
            EventName = eventName;
            Date = date;
            Time = time;
            VenueName = venueName;
            TotalSeats1 = totalSeats1;
            TotalSeats2 = totalSeats2;
            TicketPrice = ticketPrice;
        }

        // Getter and Setter Methods for Movie subclass attributes
        public string GetGenre()
        {
            return Genre;
        }

        public void SetGenre(string genre)
        {
            Genre = genre;
        }

        public string GetActorName()
        {
            return ActorName;
        }

        public void SetActorName(string actorName)
        {
            ActorName = actorName;
        }

        public string GetActressName()
        {
            return ActressName;
        }

        public void SetActressName(string actressName)
        {
            ActressName = actressName;
        }

        
        public void DisplayEventDetails()
        {
            DisplayEventDetails(); 
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Actor: {ActorName}");
            Console.WriteLine($"Actress: {ActressName}");
        }
    }
}
