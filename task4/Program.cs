using task4.model;
using static task4.model.Event;


namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
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



            Booking booking = new Booking(myEvent);

            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Calculate booking cost");
                Console.WriteLine("2. Book tickets");
                Console.WriteLine("3. Cancel booking");
                Console.WriteLine("4. Get available seats");
                Console.WriteLine("5. Get event details");
                Console.WriteLine("6. Exit");

                // Read user choice
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the number of tickets: ");
                        int numTicketsForCost;
                        if (int.TryParse(Console.ReadLine(), out numTicketsForCost))
                        {
                            booking.CalculateBookingCost(numTicketsForCost);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter the number of tickets to book: ");
                        int numTicketsToBook;
                        if (int.TryParse(Console.ReadLine(), out numTicketsToBook))
                        {
                            booking.BookTickets(numTicketsToBook);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;

                    case 3:
                        Console.Write("Enter the number of tickets to cancel: ");
                        int numTicketsToCancel;
                        if (int.TryParse(Console.ReadLine(), out numTicketsToCancel))
                        {
                            booking.CancelBooking(numTicketsToCancel);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;

                    case 4:
                        Console.WriteLine($"Available Seats: {booking.GetAvailableNoOfTickets()}");
                        break;

                    case 5:
                        booking.GetEventDetails();
                        break;

                    case 6:
                        Console.WriteLine("Exiting program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }
    }
}
