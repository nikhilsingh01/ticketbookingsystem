using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5.model
{
    internal class TicketBookingSystem
    {


        public List<Event> events = new List<Event>();

        public  Event CreateEvent()
        {
            Console.WriteLine("Enter Event Details:");

            Console.Write("Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Event Date (YYYY-MM-DD): ");
            DateTime eventDate;
            while (!DateTime.TryParse(Console.ReadLine(), out eventDate))
            {
                Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD): ");
            }

            Console.Write("Event Time (HH:mm:ss): ");
            TimeSpan eventTime;
            while (!TimeSpan.TryParse(Console.ReadLine(), out eventTime))
            {
                Console.WriteLine("Invalid time format. Please enter a valid time (HH:mm:ss): ");
            }

            Console.Write("Total Seats: ");
            int totalSeats;
            while (!int.TryParse(Console.ReadLine(), out totalSeats) || totalSeats <= 0)
            {
                Console.WriteLine("Invalid total seats. Please enter a valid positive integer: ");
            }

            Console.Write("Available Seats: ");
            int availableSeats;
            while (!int.TryParse(Console.ReadLine(), out availableSeats) || availableSeats <= totalSeats)
            {
                Console.WriteLine("Invalid total seats. Please enter a valid positive integer: ");
            }

            Console.Write("Ticket Price: ");
            decimal ticketPrice;
            while (!decimal.TryParse(Console.ReadLine(), out ticketPrice) || ticketPrice <= 0)
            {
                Console.WriteLine("Invalid ticket price. Please enter a valid positive decimal number: ");
            }

            Console.WriteLine("Select Event Type:");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Sports");
            Console.WriteLine("3. Concert");

            Event.eventType eventType;
            while (!Enum.TryParse(Console.ReadLine(), true, out eventType) || !Enum.IsDefined(typeof(Event.eventType), eventType))
            {
                Console.WriteLine("Invalid selection. Please enter a valid option (1, 2, or 3):");
            }

            Console.Write("Venue Name: ");
            string venueName = Console.ReadLine();

             Event myEvent = new Event(eventName, eventDate, eventTime, venueName, totalSeats,availableSeats, ticketPrice, eventType);


            if (myEvent != null)
            {
                events.Add(myEvent);
                // Successfully created the event, do something with it.
                Console.WriteLine($"Event created successfully:\n{myEvent}");
            }
            return myEvent;
    }

        public  void DisplayEventDetails(Event eventObj)
        {
            if (eventObj != null)
            {
                eventObj.DisplayEventDetails();
            }
            else
            {
                Console.WriteLine("Invalid event.");
            }
        }

        public decimal BookTickets(Event eventObj, int numTickets)
        {
            if (eventObj != null)
            {
                decimal totalCost = eventObj.BookTickets(numTickets);
                if (totalCost > 0)
                {
                    Console.WriteLine($"Total cost of booking: {totalCost:C}");
                }
                else
                {
                    Console.WriteLine("Not enough available seats. The event is sold out.");
                }
                return totalCost;
            }
            else
            {
                Console.WriteLine("Invalid event.");
                return 0;
            }
        }

        public  void CancelTickets(Event eventObj, int numTickets)
        {
            if (eventObj != null)
            {
                int canceledTickets = eventObj.CancelBooking(numTickets);
                if (canceledTickets > 0)
                {
                    Console.WriteLine($"{canceledTickets} ticket(s) canceled successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to cancel tickets. Invalid number of tickets or not enough booked tickets.");
                }
            }
            else
            {
                Console.WriteLine("Invalid event.");
            }
        }
    }
}

