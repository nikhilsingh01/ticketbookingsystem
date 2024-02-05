using task6.model;

namespace task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();

            Concert sampleConcert = new Concert("Music Festival", new DateTime(2024, 7, 10), new TimeSpan(19, 0, 0),
                "Concert Hall", 1000, 800, 75.99m, "Awesome Band", "Rock", Event.eventType.Concert);

            while (true)
            {
                Console.WriteLine("Ticket Booking System Menu:");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Display Event Details");
                Console.WriteLine("3. Book Tickets");
                Console.WriteLine("4. Get Available Seats");
                Console.WriteLine("5. Cancel Tickets");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ticketBookingSystem.CreateEvent();
                        break;
                    case "2":
                        ticketBookingSystem.DisplayEventDetails();
                        break;
                    case "3":
                        ticketBookingSystem.BookTickets();
                        break;
                   
                    case "4":
                        Console.Write("Enter the number of tickets to cancel: ");
                        int numTicketsToCancel;
                        if (int.TryParse(Console.ReadLine(), out numTicketsToCancel))
                        {
                            ticketBookingSystem.CancelTickets(sampleConcert, numTicketsToCancel);
                        }
                        ;
                        break;
                    case "5":
                        Console.WriteLine("Exiting program. Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-6).");
                        break;
                }
            }

        }
    }
}
