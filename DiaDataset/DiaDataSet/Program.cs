using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiaDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Načítám data..");
            List<Person> data = Data.LoadFromXML();
            Console.WriteLine($"Hotovo. Celkem {data.Count} osob.");

        }
    }
}
