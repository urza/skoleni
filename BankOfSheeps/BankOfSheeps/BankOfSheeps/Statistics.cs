using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfSheeps
{
    public static class Statistics
    {
        public static IEnumerable<(string Name, double DepositValue)> ClientsByMaxDeposit (List<Client> data)
        {
            return data
                .OrderByDescending(client => client.Transactions.Max(x => x.Value))
                .Take(10)
                .Select(client => (Name: client.FullName(), MaxDeposit: client.Transactions.Max(x => x.Value)))
            ;
        }

        public static (string Name, double DepositValue) ClientWithMaxDeposit(List<Client> data)
        {
            return ClientsByMaxDeposit(data).First();
        }
    }
}
