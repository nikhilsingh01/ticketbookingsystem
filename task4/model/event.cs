using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4.model
{
    internal class Event
    {
        
        
            public string EventName { get; set; }
            public DateTime EventDate { get; set; }
            public TimeSpan EventTime { get; set; }
            public string VenueName { get; set; }
            public int TotalSeats { get; set; }
            public int AvailableSeats { get; set; }
            public decimal TicketPrice { get; set; }
            public eventType EventType { get; set; }

            public enum eventType
            {
                Movie,
                Sports,
                Concert
            }

            private int bookedTickets;

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

        public void DisplayEventDetails()
        {
            Console.WriteLine("Event Details:");
            Console.WriteLine($"Event Name: {EventName}");
            Console.WriteLine($"Event Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Event Time: {EventTime}");
            Console.WriteLine($"Venue Name: {VenueName}");
            Console.WriteLine($"Total Seats: {TotalSeats}");
            Console.WriteLine($"Available Seats: {AvailableSeats}");
            Console.WriteLine($"Ticket Price: {TicketPrice:C}");
            Console.WriteLine($"Event Type: {EventType}");
        }

    }
    }


