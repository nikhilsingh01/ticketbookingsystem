using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task7.model;

namespace task7.model
{
    internal class BookingSystem
    {
        private List<Event> events = new List<Event>();

        // Method to create a new event and return the event object
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
                case Event.eventType.Movies:
                    Console.Write("Genre: ");
                    string genre = Console.ReadLine();

                    Console.Write("Actor Name: ");
                    string actorName = Console.ReadLine();

                    Console.Write("Actress Name: ");
                    string actressName = Console.ReadLine();

                    newEvent = new Movie(eventName, eventDate, eventTime, actressName, totalSeats, ticketPrice, genre, actorName, actressName, eventType);
                    break;
                case Event.eventType.Sports:
                    Console.Write("Sport Name: ");
                    string sportName = Console.ReadLine();

                    Console.Write("Teams Name: ");
                    string teamsName = Console.ReadLine();

                     newEvent = new Sports(eventName, eventDate, eventTime, totalSeats, teamsName, ticketPrice, sportName, teamsName, eventType);
                    break;
                case Event.eventType.Concert:
                    Console.Write("Artist: ");
                    string artist = Console.ReadLine();

                    Console.Write("Type: ");
                    string type = Console.ReadLine();

                    newEvent = new Concert(eventName, eventDate, eventTime, totalSeats, totalSeats, ticketPrice, artist, type, eventType);
                    break;
                default:
                    throw new ArgumentException("Invalid event type.");
            }


            
            return newEvent;
        }

        // Method to calculate and set the total cost of the booking
        public decimal CalculateBookingCost(Event selectedEvent, int numTickets)
        {
            return selectedEvent.TicketPrice * numTickets;
        }

        // Method to book tickets for an event
        public void BookTickets(Event selectedEvent, int numTickets, Customer[] arrayOfCustomer)
        {
            if (selectedEvent.AvailableSeats >= numTickets)
            {
                // Create a new booking
                Booking newBooking = new Booking(arrayOfCustomer, selectedEvent, numTickets, CalculateBookingCost(selectedEvent, numTickets));
                selectedEvent.BookTickets(numTickets);
                Console.WriteLine("Booking successful!");
                Console.WriteLine($"Total Cost: {newBooking.TotalCost:C}");
            }
            else
            {
                Console.WriteLine("Not enough available seats for the booking.");
            }
        }

        // Method to cancel a booking and update available seats
        public void CancelBooking(int bookingId)
        {
            Booking bookingToCancel = GetBookingById(bookingId);

            if (bookingToCancel != null)
            {
                Event associatedEvent = bookingToCancel.Event;
                associatedEvent.CancelBooking(bookingToCancel.NumTickets);
                Console.WriteLine($"Booking {bookingId} canceled successfully.");
            }
            else
            {
                Console.WriteLine($"Booking with ID {bookingId} not found.");
            }
        }

        // Method to get the total available tickets
        public int GetAvailableNoOfTickets(Event selectedEvent)
        {
            return selectedEvent.AvailableSeats;
        }

        // Method to get event details
        public void GetEventDetails(Event selectedEvent)
        {
            selectedEvent.DisplayEventDetails();
        }

        // Method to get a booking by its ID
        public Booking GetBookingById(int bookingId)
        {
            foreach (Event ev in events)
            {
                foreach (Booking booking in ev.Bookings)
                {
                    if (booking.BookingId == bookingId)
                    {
                        return booking;
                    }
                }
            }
            return null;
        }

        
        
    }
}
