using task11.Exceptions;
using task11.Services;

namespace task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEventServiceProvider ticketBookingSystem =new EventServiceProviderImpl();

            try
            {
                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Create Event");
                    Console.WriteLine("2. Get Event Details");
                    Console.WriteLine("3. Get Available Number of Tickets");
                    Console.WriteLine("4. Calculate Booking Cost");
                    Console.WriteLine("5. Book Tickets");
                    Console.WriteLine("6. Cancel Booking");
                    Console.WriteLine("7. Booking Details");
                    Console.WriteLine("8. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ticketBookingSystem.create_event();
                            break;
                        case "2":
                            ticketBookingSystem.getEventDetails();
                            break;
                        case "3":
                            ticketBookingSystem.getAvailableNoofTickets();
                            break;
                        case "4":
                            ticketBookingSystem.calculate_booking_cost();
                            break;
                        case "5":
                            ticketBookingSystem.bookTickets();
                            break;
                        case "6":
                            ticketBookingSystem.cancelBooking();
                            break;
                        case "7":
                            ticketBookingSystem.bookingDetail();
                            break;
                        case "8":
                            Console.WriteLine("Exiting the program.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please choose a valid option.");
                            break;
                    }
                }

            }
            catch (NullPointerException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
