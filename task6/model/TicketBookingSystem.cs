using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6.model
{
    internal class TicketBookingSystem : BookingSystem
    {
        private List<Event> events = new List<Event>();

        public override Event CreateEvent()
        {
            Console.WriteLine("Creating a new event...");

            // Your existing implementation for creating an event
            Event newEvent = base.CreateEvent();

            if (newEvent != null)
            {
                events.Add(newEvent);
                Console.WriteLine("Event created successfully!");
            }

            return newEvent;
        }

        public override void DisplayEventDetails( )
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No events available. Create an event first.");
            }
            else
            {
                Console.WriteLine("Displaying event details for all events:");
                foreach (var eventObj in events)
                {
                    base.DisplayEventDetails(eventObj);
                }
            }
        }

        public override decimal BookTickets()
        {
            Console.Write("Enter the Event Name to book tickets: ");
            string eventName = Console.ReadLine();

            Event selectedEvent = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));

            if (selectedEvent != null)
            {
                Console.Write("Enter the number of tickets to book: ");
                int numTickets;
                while (!int.TryParse(Console.ReadLine(), out numTickets) || numTickets <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of tickets.");
                }

                decimal totalCost = base.BookTickets(selectedEvent, numTickets);

                if (totalCost > 0)
                {
                    Console.WriteLine($"Tickets booked successfully. Total cost: {totalCost:C}");
                }

                return totalCost;
            }
            else
            {
                Console.WriteLine("Event not found. Please enter a valid Event Name.");
                return 0;
            }
        }

        // Implementing abstract method to retrieve available seats
        public override int GetAvailableSeats(Event eventObj)
        {
            if (eventObj != null)
            {
                return eventObj.AvailableSeats;
            }
            else
            {
                Console.WriteLine("Invalid event.");
                return 0;
            }
        }
    }
}
}
