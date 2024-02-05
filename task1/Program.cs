namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of available tickets: ");
            int availableTicket = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of tickets to be booked: ");
            int noOfBookingTicket = int.Parse(Console.ReadLine());


            if (noOfBookingTicket <= availableTicket)
            {



                Console.WriteLine($"Tickets Available:{availableTicket - noOfBookingTicket}");
            }
            else
            {

                Console.WriteLine($"Tickets not available");
            }

        }
    }
}
