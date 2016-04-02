using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Office
{
    public class Person
    {
        public string Name;

        public Person(string name)
        {
            Name = name;
        }

        public void Hello(object sender, EventArgsOffce e)
        {
            string hello = null;

            if (e.Hour >= 0)
            {
                if (e.Hour <= 12)
                    hello = "Доброе утро, ";
                if (e.Hour >= 12 && e.Hour <= 17)
                    hello = "Добрый день, ";
                if (e.Hour > 17)
                    hello = "Добрый вечер, ";
            }
            Console.WriteLine(hello + e.Person.Name + "! - сказал {0}", Name);
        }

        public void Bye(object sender, EventArgsOffce e)
        {
            Console.WriteLine("До свидания, " + e.Person.Name + " - сказал {0}", Name);
        }
    }
}
