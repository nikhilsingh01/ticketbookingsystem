using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.model
{
    internal abstract class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public eventType EventType { get; set; }
        public eventType EventType1 { get; }
        public IEnumerable<Booking> Bookings { get; internal set; }

        public enum eventType
        {
            Movies,
            Sports,
            Concert
        }

        private int bookedTickets;

        protected Event(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, int availableSeats, decimal ticketPrice, eventType eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            VenueName = venueName;
            TotalSeats = totalSeats;
            AvailableSeats = availableSeats;
            TicketPrice = ticketPrice;
            EventType1 = eventType;
        }

        public decimal CalculateTotalRevenue(int numberOfTicketsSold)
        {
            if (numberOfTicketsSold > 0 && numberOfTicketsSold <= AvailableSeats)
            {

                decimal totalRevenue = numberOfTicketsSold * TicketPrice;
                Console.WriteLine($"{totalRevenue}");
                return totalRevenue;
            }
            else
            {
                Console.WriteLine("Invalid number of tickets sold.");
                return 0;
            }
        }

        public int GetBookedNoOfTickets()
        {
            Console.WriteLine($"{bookedTickets}");
            return bookedTickets;
        }

        public bool BookTickets(int numTickets)
        {
            if (numTickets > 0 && numTickets <= AvailableSeats)
            {
                bookedTickets += numTickets;
                AvailableSeats -= numTickets;
                Console.WriteLine($"{numTickets} ticket(s) booked successfully.");
                Console.WriteLine($"Remaining Seats::{AvailableSeats}");
                return true;
            }
            else
            {
                Console.WriteLine($"Invalid number of tickets.");
                return false;
            }
        }

        public bool CancelBooking(int numTicketsToCancel)
        {
            if (numTicketsToCancel > 0 && numTicketsToCancel <= bookedTickets)
            {
                Console.WriteLine($"{numTicketsToCancel} ticket(s) canceled for {bookedTickets}.");
                bookedTickets -= numTicketsToCancel;
                AvailableSeats += numTicketsToCancel;
                Console.WriteLine($"{numTicketsToCancel} ticket(s) canceled for {bookedTickets}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Invalid number of tickets to cancel for {EventName}.");
                return false;
            }
        }
       
        public abstract void DisplayEventDetails();
     

    }
}
