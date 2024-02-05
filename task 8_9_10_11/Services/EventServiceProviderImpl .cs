using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task11.Models.Event;
using task11.Models;
using task11.Repositorty;
using task11.Exceptions;

namespace task11.Services
{
    internal class EventServiceProviderImpl: IEventServiceProvider

    {

        IBookingSystemRepository bookingrepo = new BookingSystemRepository();
        public Event create_event()
        {
            Console.WriteLine("Enter event details:");

            Console.Write("Event ID: ");
            int eventId = int.Parse(Console.ReadLine());

            Console.Write("Event Name: ");
             string eventName = Console.ReadLine();

            Console.Write("Event Date (DD/MM/YYYY): ");
            DateTime eventDate;
            while (!DateTime.TryParse(Console.ReadLine(), out eventDate))
            {
                Console.WriteLine("Invalid date format. Please enter a valid date (MM/DD/YYYY):");
            }

            Console.Write("Event Time (HH:mm): ");
            TimeSpan eventTime;
            while (!TimeSpan.TryParse(Console.ReadLine(), out eventTime))
            {
                Console.WriteLine("Invalid time format. Please enter a valid time (HH:mm):");
            }

            Console.Write("Total Seats: ");
            int totalSeats;
            while (!int.TryParse(Console.ReadLine(), out totalSeats) || totalSeats <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for total seats:");
            }

            Console.Write("Ticket Price: ");
            decimal ticketPrice;
            while (!decimal.TryParse(Console.ReadLine(), out ticketPrice) || ticketPrice <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive decimal value for ticket price:");
            }

            Console.WriteLine("Select Event Type:");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Sports");
            Console.WriteLine("3. Concert");

            eventType eventType;
            while (!Enum.TryParse(Console.ReadLine(), true, out eventType) || !Enum.IsDefined(typeof(eventType), eventType))
            {
                Console.WriteLine("Invalid selection. Please enter a valid option (1, 2, or 3):");
            }

            Console.Write("Venue ID: ");
            int venueId = int.Parse(Console.ReadLine());

            Console.Write("Venue Name: ");
            string venueName = Console.ReadLine();

            Venue venue = new Venue(venueId, venueName, "Sample Address"); 

            Event newEvent;

            switch (eventType)
            {
                case eventType.Movies:
                    Console.Write("Genre: ");
                    string genre = Console.ReadLine();

                    Console.Write("Actor Name: ");
                    string actorName = Console.ReadLine();

                    Console.Write("Actress Name: ");
                    string actressName = Console.ReadLine();

                    newEvent = new Movie(eventId,eventName, eventDate, eventTime, venue.venueId, totalSeats, totalSeats, ticketPrice, genre, actorName, actressName, eventType);
                    break;
                case eventType.Sports:
                    Console.Write("Sport Name: ");
                    string sportName = Console.ReadLine();

                    Console.Write("Teams Name: ");
                    string teamsName = Console.ReadLine();

                    newEvent = new Sports(eventId, eventName, eventDate, eventTime, venue.venueId, totalSeats, totalSeats, ticketPrice, sportName, teamsName, eventType);
                    break;
                case eventType.Concert:
                    Console.Write("Artist: ");
                    string artist = Console.ReadLine();

                    Console.Write("Type: ");
                    string type = Console.ReadLine();

                    newEvent = new Concert(eventId, eventName, eventDate, eventTime, venue.venueId, totalSeats, totalSeats, ticketPrice, artist, type, eventType);
                    break;
                default:
                    throw new ArgumentException("Invalid event type.");
            }

            Console.WriteLine($"{newEvent.VenueId}");
            bookingrepo.create_event(newEvent);
            Console.WriteLine("Event created successfully!");
            return newEvent;
        }

        public void getAvailableNoofTickets()
        {
            Dictionary<int, int> availableSeats = bookingrepo.getAvailableNoOfTickets();

            // Display the available seats for each event
            Console.WriteLine("Available Seats for Events:");

            foreach (var kvp in availableSeats)
            {
                Console.WriteLine($"Event ID: {kvp.Key}, Available Seats: {kvp.Value}");
            }
        }

        public void getEventDetails()
        {
            List<Event> eventsFromDatabase = bookingrepo.getEventDetails();
            foreach (Event eventDetail in eventsFromDatabase)
            {
                // Display or process each eventDetail as needed
                Console.WriteLine($"Event Name: {eventDetail.EventName}, Event Date: {eventDetail.EventDate},Event Type: {eventDetail.EventType},Available Seats: {eventDetail.AvailableSeats},Ticket Price:{eventDetail.TicketPrice}");
            }
        }

        public void calculate_booking_cost()
        {
            return;
        }

        public void bookTickets()
        {
            Console.WriteLine("Enter the details to book tickets:");

            Console.Write("Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Number of Tickets: ");
            int numTickets;
            while (!int.TryParse(Console.ReadLine(), out numTickets) || numTickets <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of tickets:");
            }

            // Assuming you have a single customer for the booking
            Console.WriteLine("Enter details for the Customer:");
            Console.Write("Customer ID: ");
            int customerID=int.Parse(Console.ReadLine());

            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            // Create a new customer object
            Customer newCustomer = new Customer(customerID,customerName, email, phoneNumber);

            // Assuming you have an instance of TicketBookingSystem


            // Call the book_tickets method
            bookingrepo.bookTicket(eventName, numTickets, newCustomer);
        }

        public void cancelBooking()
        {
            

            try
            {
                Console.WriteLine("Enter Booking ID to cancel:");
                if (int.TryParse(Console.ReadLine(), out int bookingId))
                {
                    bool isCanceled = bookingrepo.cancelBooking(bookingId);

                    if (isCanceled)
                    {
                        Console.WriteLine($"Booking with ID {bookingId} has been canceled successfully.");
                    }
                    
                }
                
            }
            catch (InvalidBookingIDException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }

        public void bookingDetail()
        {
            


            try
            {
                Console.WriteLine("Enter Booking ID to get details:");
                if (int.TryParse(Console.ReadLine(), out int bookingId))
                {
                    Booking bookingDetails = bookingrepo.bookingDetail(bookingId);

                    if (bookingDetails != null)
                    {
                        Console.WriteLine("Booking Details:");
                        Console.WriteLine($"Booking ID: {bookingDetails.BookingId}");
                        Console.WriteLine($"Event Name: {bookingDetails.Event.EventName}");
                        Console.WriteLine($"Number of Tickets: {bookingDetails.NumTickets}");
                        Console.WriteLine($"Total Cost: {bookingDetails.TotalCost:C}");
                        Console.WriteLine($"Booking Date: {bookingDetails.BookingDate}");

                        Console.WriteLine("Customers:");
                        foreach (var customer in bookingDetails.Customers)
                        {
                            Console.WriteLine($"Customer ID: {customer.customerID}");
                            Console.WriteLine($"Customer Name: {customer.CustomerName}");
                            Console.WriteLine($"Email: {customer.Email}");
                            Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                            Console.WriteLine();
                        }
                    }
                    
                }
                
            }
            catch (InvalidBookingIDException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
