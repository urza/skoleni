using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfSheeps
{
    public static class Statistics
    {
        /// <summary>
        /// Nejstarší klient
        /// </summary>
        public static Client OldestClient(List<Client> data)
        {
            return data.OrderBy(client => client.DateOfBirth).First();
        }

        /// <summary>
        /// Nejmladší klient
        /// </summary>
        public static Client YoungestClient(List<Client> data)
        {
            return data.OrderByDescending(client => client.DateOfBirth).First();
        }

        /// <summary>
        /// 5 klientů, kteří budou mít nejdřív narozeniny
        /// </summary>
        public static List<(DateTime Date, Client Client)> WhoHasBirthdaysSoon(List<Client> data)
        {
            var today = DateTime.Today.AddMonths(7);

            var dataordered = data.OrderBy(x => x.DateOfBirth.Month).ThenBy(x => x.DateOfBirth.Day);
            var outlist = dataordered.Where(x => x.DateOfBirth.Month >= today.Month && x.DateOfBirth.Day > today.Day).ToList();
            if (outlist.Count() < 5)
            {
                var count = 5 - outlist.Count();
                outlist.AddRange(dataordered.Take(count));
            }
            List<(DateTime Date, Client Client)> readytooutlist = new List<(DateTime Date, Client Client)>();

            foreach (var cl in outlist)
            {
                readytooutlist.Add((cl.DateOfBirth, cl));
            }
            return readytooutlist;

            ///
            //var today = DateTime.Today;

            //var orderedData = data.Where(cl => cl.DateOfBirth.DayOfYear > DateTime.Today.DayOfYear).OrderBy(cl => cl.DateOfBirth.DayOfYear - DateTime.Today.DayOfYear).Take(5);
            //return orderedData.Select(o => (o.DateOfBirth, o)).ToList();

            //return data
            //.Select(client => new { Client = client, DateThisYear = new DateTime(today.Year, client.DateOfBirth.Month, client.DateOfBirth.Day) })
            //.Where(cd => cd.DateThisYear >= today)
            //.OrderBy(cd => cd.DateThisYear - today)
            //.Take(5)
            //.Select(x => (x.Client.DateOfBirth, x.Client))
            //.ToList();



        }

        /// <summary>
        /// klient s největším jednorázovým depozitem
        /// </summary>
        /// <returns>jméno a hodnotu největšího depozitu</returns>
        public static (string Name, double DepositValue) MaxDepositClient(List<Client> data)
        {
            return data
                .OrderByDescending(c => c.Transactions.Select(x => x.Value).Max())
                .Select(c => (Name: c.FullName(), DepositValue: c.Transactions.Select(x => x.Value).Max()))
                .First();
            
        }

        /// <summary>
        /// 10 klientů s nejvěším depozitem (jednorázový depozit, nikoliv suma všech)
        /// </summary>
        /// <returns>jméno a hodnotu největšího depozitu</returns>
        public static IEnumerable<(string Name, double DepositValue)> TopDepositClients(List<Client> data)
        {
            return data
                .OrderByDescending(c => c.Transactions.Select(x => x.Value).Max())
                .Select(c => (Name: c.FullName(), DepositValue: c.Transactions.Select(x => x.Value).Max()))
                .Take(10);
        }


        /// <summary>
        /// Nejbohatší klient v každém městě. Nejbohatší = aktuální AccountBalance
        /// </summary>
        /// <returns>Nejbohatšího klienta v každém městě</returns>
        public static IEnumerable<(string City, string Name, double AccountBalance)> RichestClientsByCity(List<Client> data)
        {
            return data.GroupBy(client => client.Address.City)
                .Select(g => 
                (City: g.Key, 
                Name: g.OrderByDescending(x => x.AccountBalance).First().FullName(), 
                AccountBalance: g.Max(x => x.AccountBalance)));
        }

        public static Transaction MaxDeposit(List<Client> data)
        {
            var allTransactions = data.SelectMany(client => client.Transactions);
            return allTransactions.OrderByDescending(x => x.Value).First();
        }


    }
}
