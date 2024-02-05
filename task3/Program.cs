namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Ticket prices for different categories
                int silverTicketPrice = 50;
                int goldTicketPrice = 100;
                int diamondTicketPrice = 150;

                // Input: Select ticket category
                Console.WriteLine("Ticket Categories:");
                Console.WriteLine("Silver");
                Console.WriteLine("Gold");
                Console.WriteLine("Diamond");

                Console.WriteLine("Enter the number corresponding to your ticket category or type 'Exit' to exit: ");
                string ticketCategoryChoice = Console.ReadLine();
                string ticketCategory;
                int baseTicketPrice;

                if (ticketCategoryChoice.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting program. Thank you!");
                    break;
                }

                // Set ticket category and base ticket price based on user's choice
                else if (ticketCategoryChoice.Equals("Silver", StringComparison.OrdinalIgnoreCase))
                {
                    ticketCategory = "Silver";
                    baseTicketPrice = silverTicketPrice;
                }
                else if (ticketCategoryChoice.Equals("Gold", StringComparison.OrdinalIgnoreCase))
                {
                    ticketCategory = "Gold";
                    baseTicketPrice = goldTicketPrice;
                }
                else if (ticketCategoryChoice.Equals("Diamond", StringComparison.OrdinalIgnoreCase))
                {
                    ticketCategory = "Diamond";
                    baseTicketPrice = diamondTicketPrice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                Console.WriteLine($"Enter the number of {ticketCategory} tickets to be booked: ");
                int noOfBookingTicket;

                // Validate user input for the number of tickets
                while (!int.TryParse(Console.ReadLine(), out noOfBookingTicket) || noOfBookingTicket < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of tickets.");
                    Console.WriteLine($"Enter the number of {ticketCategory} tickets to be booked: ");
                }

                int totalCost = baseTicketPrice * noOfBookingTicket;

                Console.WriteLine($"Booking details:");
                Console.WriteLine($"Ticket Category: {ticketCategory}");
                Console.WriteLine($"Base Ticket Price: {baseTicketPrice}");
                Console.WriteLine($"Number of Tickets: {noOfBookingTicket}");
                Console.WriteLine($"Total Cost: {totalCost}");
            }
        }
    }
}
