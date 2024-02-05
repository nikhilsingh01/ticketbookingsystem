using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11.Exceptions
{
    internal class EventNotFoundException : ApplicationException
    {
        public EventNotFoundException() { }

        public EventNotFoundException(string message) : base(message) { }
    }
}
