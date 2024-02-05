using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task11.Models.Event;
using task11.Models;

namespace task11.Repositorty
{
    internal interface IBookingSystemRepository
    {
        public bool create_event(Event newEvent);

        public List<Event> getEventDetails();

        public Dictionary<int, int> getAvailableNoOfTickets();

        public int calculate_booking_cost(int numTickets);

        public bool bookTicket(string eventName,int numTiket,Customer newCustomer);

        public bool cancelBooking(int bookingID);

        public Booking bookingDetail(int bookingID);


    }
}
