using task7.model;

namespace task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer customer1 = new Customer(1,"John Doe", "john@example.com", "+123456789");
            //Customer customer2 = new Customer(2,"Jane Doe", "jane@example.com", "+987654321");

            //// Create an event
            //Event movieEvent = new Movie("Action Movie", DateTime.Now, new TimeSpan(18, 30, 0), "Cinema Hall 1", 150, 150, 15.75m, "Action", "John Doe", "Jane Doe",Event.eventType.Movies);

            //// Create a booking
            //Booking booking = new Booking(new Customer[] { customer1, customer2 }, movieEvent, 2, 31.50m);

            //// Display booking details
            //booking.DisplayBookingDetails();

            BookingSystem ticketBookingSystem = new BookingSystem();

            Concert sampleConcert = new Concert("Music Festival", new DateTime(2024, 7, 10), new TimeSpan(19, 0, 0),
                "Concert Hall", 1000, 800, 75.99m, "Awesome Band", "Rock", Event.eventType.Concert);

            Customer[] sampleCustomers = new Customer[]
            {
                new Customer(1, "John Doe", "john.doe@example.com", "123-456-7890"),
                new Customer(2, "Jane Smith", "jane.smith@example.com", "987-654-3210"),
                new Customer(3, "Alice Johnson", "alice.johnson@example.com", "555-123-4567"),
                // Add more sample customers as needed
            };

            while (true)
            {
                Console.WriteLine("Ticket Booking System Menu:");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Display Event Details");
                Console.WriteLine("3. Book Tickets");
                Console.WriteLine("4. Cancel Tickets");
                Console.WriteLine("5. Get Booking Details by ID");
                Console.WriteLine("6. Get Available Number of Tickets");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice (1-7): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ticketBookingSystem.CreateEvent();
                        break;
                    case "2":
                        ticketBookingSystem.GetEventDetails(sampleConcert);
                        break;
                    case "3":
                        Console.Write("Enter the number of tickets to book: ");
                        int numTickets;
                        if (int.TryParse(Console.ReadLine(), out numTickets))
                        {
                            ticketBookingSystem.BookTickets(sampleConcert, numTickets, sampleCustomers);
                        }
                        break;
                    case "4":
                        Console.Write("Enter the Booking ID to cancel: ");
                        int bookingID;
                        if (int.TryParse(Console.ReadLine(), out bookingID))
                        {
                            ticketBookingSystem.CancelBooking(bookingID);
                        }
                        break;
                    case "5":
                        Console.Write("Enter the Booking ID to get details: ");
                        int bookingId;
                        if (int.TryParse(Console.ReadLine(), out bookingId))
                        {
                            ticketBookingSystem.GetBookingById(bookingId);
                        }
                        break;
                    case "6":
                        Console.WriteLine("Number of Available Tickets: ");
                        ticketBookingSystem.GetAvailableNoOfTickets(sampleConcert);
                        break;
                    case "7":
                        Console.WriteLine("Exiting program. Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-7).");
                        break;
                }
            }
            
        }
    }
}
