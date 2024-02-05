using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4.model
{
    internal class Booking
    {
        private Event eventInstance;

        // Constructor
        public Booking(Event eventInstance)
        {
            this.eventInstance = eventInstance;
        }

        // Method to calculate and set the total cost of the booking
        public void CalculateBookingCost(int numTickets)
        {
            decimal totalCost = numTickets * eventInstance.TicketPrice;
            Console.WriteLine($"Total cost for booking {numTickets} tickets: {totalCost:C}");
        }

        // Method to book a specified number of tickets for an event
        public void BookTickets(int numTickets)
        {
            if (eventInstance.BookTickets(numTickets))
            {
                Console.WriteLine($"{numTickets} tickets booked successfully for {eventInstance.EventName}.");
            }
            else
            {
                Console.WriteLine($"Failed to book {numTickets} tickets for {eventInstance.EventName}.");
            }
        }

        // Method to cancel the booking and update the available seats
        public void CancelBooking(int numTickets)
        {
            if (eventInstance.CancelBooking(numTickets))
            {
                Console.WriteLine($"{numTickets} tickets canceled successfully for {eventInstance.EventName}.");
            }
            else
            {
                Console.WriteLine($"Failed to cancel {numTickets} tickets for {eventInstance.EventName}.");
            }
        }

        // Method to get the total available tickets
        public int GetAvailableNoOfTickets()
        {
            return eventInstance.AvailableSeats;
        }

        // Method to get event details from the Event class
        public void GetEventDetails()
        {
            eventInstance.DisplayEventDetails();
        }
    }
}
