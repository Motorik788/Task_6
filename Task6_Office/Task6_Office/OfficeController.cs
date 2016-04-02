using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task6_Office
{
    public sealed class OfficeController
    {
        public event HelloDelegate HelloEvent;
        public event ByeDelegate ByeEvent;

        public sealed class PersonTimeOut
        {
            public Person Pers { get; set; }
            public int Timer { get; set; }
        }

        public List<PersonTimeOut> persons = new List<PersonTimeOut>();

        void AddPerson(Person pers, int time)
        {
            persons.Add(new PersonTimeOut() { Pers = pers, Timer = new Random().Next() });
            if (HelloEvent != null)
                HelloEvent(this, new EventArgsOffce(pers, time));
            HelloEvent += pers.Hello;
            ByeEvent += pers.Bye;
        }

        public void FillOffice(params string[] namesEmployee)
        {
            for (int i = 0; i < namesEmployee.Length; i++)
            {
                var pers = new Person(namesEmployee[i]);
                Console.WriteLine("На работу пришел {0}:", pers.Name);
                AddPerson(pers, DateTime.Now.Hour);
                Console.WriteLine();
                Thread.Sleep(new Random().Next(500, 1500));
            }
        }

        public void Leave()
        {
            var personsOrdered = from pers in persons
                                 orderby pers.Timer descending
                                 select new { Pers = pers.Pers };
            foreach (var item in personsOrdered)
            {
                Thread.Sleep(new Random().Next(500, 1500));
                Console.WriteLine("Ушел {0}:", item.Pers.Name);
                ByeEvent -= item.Pers.Bye;
                if (ByeEvent != null)
                    ByeEvent(this, new EventArgsOffce(item.Pers));
                Console.WriteLine();
            }
            persons.Clear();
        }
    }
}
