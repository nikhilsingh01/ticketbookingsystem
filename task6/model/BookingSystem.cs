using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task6.model
{
    internal abstract class BookingSystem
    {
        public List<Event> events = new List<Event>();
        public virtual Event CreateEvent()
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

           

            Console.Write("Venue Name: ");
            string venueName = Console.ReadLine();

            Console.WriteLine("Select Event Type:");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Sports");
            Console.WriteLine("3. Concert");

            Event.eventType eventType;
            while (!Enum.TryParse(Console.ReadLine(), true, out eventType) || !Enum.IsDefined(typeof(Event.eventType), eventType))
            {
                Console.WriteLine("Invalid selection. Please enter a valid option (1, 2, or 3):");
            }

            Console.Write("Venue ID: ");
            int venueId = int.Parse(Console.ReadLine());

            

            

            Event newEvent;

            switch (eventType)
            {
                case Event.eventType.Movie:
                    Console.Write("Genre: ");
                    string genre = Console.ReadLine();

                    Console.Write("Actor Name: ");
                    string actorName = Console.ReadLine();

                    Console.Write("Actress Name: ");
                    string actressName = Console.ReadLine();

                    newEvent = new Movie( eventName, eventDate, eventTime, actressName, totalSeats, ticketPrice, genre, actorName, actressName, eventType);
                    break;
                case Event.eventType.Sports:
                    Console.Write("Sport Name: ");
                    string sportName = Console.ReadLine();

                    Console.Write("Teams Name: ");
                    string teamsName = Console.ReadLine();

                    newEvent = new Sports( eventName, eventDate, eventTime, totalSeats, teamsName, ticketPrice, sportName, teamsName, eventType);
                    break;
                case Event.eventType.Concert:
                    Console.Write("Artist: ");
                    string artist = Console.ReadLine();

                    Console.Write("Type: ");
                    string type = Console.ReadLine();

                    newEvent = new Concert(eventName, eventDate, eventTime,  totalSeats, totalSeats, ticketPrice, artist, type, eventType);
                    break;
                default:
                    throw new ArgumentException("Invalid event type.");
            }


            if (newEvent != null)
            {
                // Successfully created the event, do something with it.
                
            }
            return newEvent;
        }

        public virtual void DisplayEventDetails(Event eventObj)
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

        public virtual decimal BookTickets(Event eventObj, int numTickets)
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

        public virtual void CancelTickets(Event eventObj, int numTickets)
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
