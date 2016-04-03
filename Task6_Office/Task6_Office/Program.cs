using System;
using System.Collections.Generic;
using System.Linq;


namespace Task6_Office
{
    public delegate void HelloDelegate(object sender, EventArgsOffce e);
    public delegate void ByeDelegate(object sender, EventArgsOffce e);


    class Program
    {
        static void Main(string[] args)
        {
            OfficeController office = new OfficeController();
            string[] namesEmployee = { "Стив", "Питер", "Джонсон", "Кайл", "Валентин" };
            office.FillOffice(namesEmployee);
            office.Leave();
            Console.ReadKey();
        }
    }
}
