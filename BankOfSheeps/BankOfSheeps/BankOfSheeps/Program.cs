using System;
using System.Collections.Generic;

namespace BankOfSheeps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank of Sheeps!");

            Console.WriteLine("Načítám data..");
            List<Client> data = Data.GeneratePersons();
            Data.GenerateToXML();
            Console.WriteLine($"Hotovo. Celkem {data.Count} osob.");

            Console.WriteLine(Statistics.WhoHasMaxGlucose(data).Name);

            foreach (var person in Statistics.PersonsByMaxDeposit(data))
            {
                Console.WriteLine(person.Name + "    " + person.Glucose);
            }
        }
    }
}
