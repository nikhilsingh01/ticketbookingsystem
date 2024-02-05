using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task11.Models.Event;
using task11.Models;

namespace task11.Services
{
    internal interface IEventServiceProvider
    {
        public Event create_event();

        public void getEventDetails();

        public void getAvailableNoofTickets();

        public void calculate_booking_cost();

        public void bookTickets();

        public void cancelBooking();

        public void bookingDetail();
    }
}
