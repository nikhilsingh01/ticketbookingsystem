namespace task2
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

                Console.WriteLine("Enter the number corresponding to your ticket category or Exit : ");
                string ticketCategoryChoice = Console.ReadLine();
                string ticketCategory;
                int baseTicketPrice;

                

                // Set ticket category and base ticket price based on user's choice
                 if (ticketCategoryChoice == "Silver")
                {
                    ticketCategory = "Silver";
                    baseTicketPrice = silverTicketPrice;
                }
                else if (ticketCategoryChoice == "Gold")
                {
                    ticketCategory = "Gold";
                    baseTicketPrice = goldTicketPrice;
                }
                else if (ticketCategoryChoice == "Diamond")
                {
                    ticketCategory = "Diamond";
                    baseTicketPrice = diamondTicketPrice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Exiting program.");
                    return;
                }





                Console.WriteLine($"Enter the number of {ticketCategory} tickets to be booked: ");
                int noOfBookingTicket = int.Parse(Console.ReadLine());


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
