using System;

namespace Taskflow.Core.Menssages
{
    public class Event
    {
        public DateTime TimeStamp { get; private set; }
        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
