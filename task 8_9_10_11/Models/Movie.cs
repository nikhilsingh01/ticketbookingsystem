using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task11.Models.Event;

namespace task11.Models
{
    internal class Movie:Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie(int eventId,string eventName, DateTime eventDate, TimeSpan eventTime, int venueid,
                 int totalSeats, int availableSeats, decimal ticketPrice,
                 string genre, string actorName, string actressName, eventType eventType)
        : base(eventId,eventName, eventDate, eventTime, venueid, totalSeats, availableSeats, ticketPrice, eventType)
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }
    }
}
