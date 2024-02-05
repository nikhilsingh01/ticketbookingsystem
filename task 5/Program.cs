using task_5.model;

namespace task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketBookingSystem system
                = new TicketBookingSystem();

            Event myEvent = new Event
            {
                AvailableSeats = 100,
                TicketPrice = 10,
                EventName = "Sample Event",
                EventDate = DateTime.Now.Date,
                EventTime = new TimeSpan(18, 30, 0),
                VenueName = "Sample Venue",
                TotalSeats = 100
            };
            myEvent.AvailableSeats = 80;
            myEvent.TicketPrice = 20.50m;
            myEvent.EventType = Event.eventType.Concert;


            
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Display Event Details");
                Console.WriteLine("3. Book Tickets");
                Console.WriteLine("4. Cancel Tickets");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                       system.CreateEvent();
                        break;
                    case "2":
                        system.DisplayEventDetails(myEvent);
                        break;
                    case "3":
                        Console.WriteLine("Enter the number of ticket to book");
                        int num_ticket = int.Parse(Console.ReadLine());
                        system.BookTickets(myEvent,num_ticket);
                        break;
                    case "4":
                        Console.WriteLine("Enter the number of ticket to cancel");
                        int num_tickett = int.Parse(Console.ReadLine());
                        system.CancelTickets(myEvent,num_tickett);
                        break;
                    case "5":
                        Console.WriteLine("Exiting program. Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                        break;
                }
            }


        }
    }
}
