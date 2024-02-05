using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11.Models
{
    internal class Sports:Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        // Constructor for Sports class
        public Sports(int eventId,string eventName, DateTime eventDate, TimeSpan eventTime, int venueid,
                      int totalSeats, int availableSeats, decimal ticketPrice,
                      string sportName, string teamsName, eventType EventType)
            : base(eventId, eventName, eventDate, eventTime, venueid, totalSeats, availableSeats, ticketPrice, EventType)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }
    }
}
