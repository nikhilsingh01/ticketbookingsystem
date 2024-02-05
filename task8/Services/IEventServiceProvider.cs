using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task8.models;

namespace task8.Services
{
    internal interface IEventServiceProvider
    {
        public Event create_event();
    }
}
