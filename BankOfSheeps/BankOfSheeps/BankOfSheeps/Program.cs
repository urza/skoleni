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
            List<Client> data = Data.LoadFromXML();
         
            Console.WriteLine($"Načteno celkem {data.Count} osob.");

            Console.WriteLine(Statistics.ClientWithMaxDeposit(data).Name);

            foreach (var client in Statistics.ClientsByMaxDeposit(data))
            {
                Console.WriteLine(client.Name + "    " + client.DepositValue);
            }
        }
    }
}
