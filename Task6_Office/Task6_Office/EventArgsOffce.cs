using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Office
{
    public sealed class EventArgsOffce
    {
        public Person Person { get; }
        public int Hour { get; }

        public EventArgsOffce(Person pers, int time = 0)
        {
            Person = pers;
            Hour = time;
        }
    }
}
