using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11.Models
{
    internal class Event
    {

        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public int VenueId { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public eventType EventType { get; set; }
        
        public IEnumerable<Booking> Bookings { get; internal set; }

        public enum eventType
        {
            Movies,
            Sports,
            Concert
        }

        private int bookedTickets;

        public Event(int eventId,string eventName, DateTime eventDate, TimeSpan eventTime, int venueid, int totalSeats, int availableSeats, decimal ticketPrice, eventType eventType)
        {
            EventId = eventId;
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            VenueId = venueid;
            TotalSeats = totalSeats;
            AvailableSeats = availableSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }
        public Event() { }

    }
}
