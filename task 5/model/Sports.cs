using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_5.model.Event;

namespace task_5.model
{
    internal class Sports:Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }
        public DateTime Date { get; }
        public TimeSpan Time { get; }
        public int TotalSeats1 { get; }
        public int TotalSeats2 { get; }

        public Sports() : base()
        {
            // Set default values or leave them uninitialized based on your requirements
            SportName = "Unknown";
            TeamsName = "Unknown vs Unknown";
        }

        public Sports(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName,
                   int totalSeats, int availableSeats, decimal ticketPrice, eventType eventType,
                   string sportName, string teamsName)
        : base(eventName, eventDate, eventTime, venueName, totalSeats, availableSeats, ticketPrice, eventType)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        public Sports(string eventName, DateTime date, TimeSpan time, string venueName, int totalSeats1, int totalSeats2, decimal ticketPrice)
        {
            EventName = eventName;
            Date = date;
            Time = time;
            VenueName = venueName;
            TotalSeats1 = totalSeats1;
            TotalSeats2 = totalSeats2;
            TicketPrice = ticketPrice;
        }

        public void DisplaySportDetails()
        {
            base.DisplayEventDetails(); // Call the base class method to display common event details
            Console.WriteLine($"Sport: {SportName}");
            Console.WriteLine($"Teams: {TeamsName}");
        }

    }
}
