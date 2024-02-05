using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task8.models.Event;
using task8.models;

namespace task8.Services
{
    internal class EventServiceProviderImpl : IEventServiceProvider
    {
        public Event create_event()
        {
            Console.WriteLine("Enter event details:");

            Console.Write("Event ID: ");
            int eventId = int.Parse(Console.ReadLine());

            Console.Write("Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Event Date (MM/DD/YYYY): ");
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

                    newEvent = new Movie(eventId, eventName, eventDate, eventTime, venue.venueId, totalSeats, totalSeats, ticketPrice, genre, actorName, actressName, eventType);
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
            Console.WriteLine("Event created successfully!");
            return newEvent;
        }
    }
}
