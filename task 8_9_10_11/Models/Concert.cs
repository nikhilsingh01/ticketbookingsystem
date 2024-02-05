using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task11.Models.Event;

namespace task11.Models
{
    internal class Concert:Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        // Constructor for Concert class
        public Concert(int Eventid,string eventName, DateTime eventDate, TimeSpan eventTime, int venueid,
                       int totalSeats, int availableSeats, decimal ticketPrice,
                       string artist, string type, eventType EventType)
            : base(Eventid, eventName, eventDate, eventTime, venueid, totalSeats, availableSeats, ticketPrice, EventType)
        {
            Artist = artist;
            Type = type;
        }

    }
}
