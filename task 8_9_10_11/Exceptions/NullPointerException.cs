using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11.Exceptions
{
    internal class NullPointerException :ApplicationException
    {
            public NullPointerException() { }
             
            public NullPointerException(string message) : base(message) { }
    }
}
