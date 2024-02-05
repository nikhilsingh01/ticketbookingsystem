using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11.Exceptions
{
    internal class InvalidBookingIDException:ApplicationException
    {
           public InvalidBookingIDException() { }

           public InvalidBookingIDException(string message) : base(message) { }
    }
}
