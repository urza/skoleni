using System;
using System.Collections.Generic;
using System.Linq;

namespace BankOfSheeps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Bank of Sheeps! *********");
            Console.WriteLine("********************************");
            Console.WriteLine();

            Console.WriteLine("Načítám data..");
            List<Client> data = Data.LoadFromXML();
            Console.WriteLine($"Načteno celkem {data.Count} klientů.");
            Console.WriteLine();

            var duplicity = data.GroupBy(x => x.Email).Where(x => x.Count() > 1);


            ///
            //PrintOldest(data);

            ///////
            //PrintYoungest(data);

            ///////
            //PrintBirthdaySoon(data);

            ///////
            //PrintMaxDepositClient(data);

            ///////
            //PrintTop10MaxDepositClients(data);

            ///////
            //PrintRichestClientsByCity(data);

        }

        private static void PrintRichestClientsByCity(List<Client> data)
        {
            Console.WriteLine("Nejbohatší klient v každém městě. Nejbohatší = aktuální AccountBalance:");
            foreach (var client in Statistics.RichestClientsByCity(data))
            {
                Console.WriteLine(client.City + "    " + client.Name + "   " + client.AccountBalance);
            }
            Console.WriteLine();
        }

        private static void PrintTop10MaxDepositClients(List<Client> data)
        {
            Console.WriteLine("10 klientů s nejvěším depozitem (jednorázový depozit, nikoliv suma všech):");
            foreach (var client in Statistics.TopDepositClients(data))
            {
                Console.WriteLine(client.Name + "    " + client.DepositValue);
            }
            Console.WriteLine();
        }

        private static void PrintMaxDepositClient(List<Client> data)
        {
            Console.WriteLine("klient s největším jednorázovým depozitem:");
            var client = Statistics.MaxDepositClient(data);
            Console.WriteLine(client.Name + "  " + client.DepositValue);
            Console.WriteLine();
        }

        private static void PrintBirthdaySoon(List<Client> data)
        {
            Console.WriteLine(" 5 klientů, kteří budou mít nejdřív narozeniny:");
            var bd = Statistics.WhoHasBirthdaysSoon(data);
            foreach (var client in bd)
            {
                Console.WriteLine(client.Date.ToString("dd. MM.") + "    " + client.Client.FullName());
            }
            Console.WriteLine();
        }

        private static void PrintYoungest(List<Client> data)
        {
            Console.WriteLine("Nejmladší klient");
            var client = Statistics.YoungestClient(data);
            Console.WriteLine($"{client.FullName()} - {client.DateOfBirth}");
            Console.WriteLine();
        }

        private static void PrintOldest(List<Client> data)
        {
            Console.WriteLine("Nejstarší klient");
            var client = Statistics.OldestClient(data);
            Console.WriteLine($"{client.FullName()} - {client.DateOfBirth}");
            Console.WriteLine();
        }
    }
}
