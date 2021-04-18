using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfSheeps
{
    public static class Statistics
    {
        public static IEnumerable<(string Name, double Glucose)> PersonsByMaxDeposit (List<Client> data)
        {
            return data
                .OrderByDescending(person => person.Transactions.Max(x => x.Value))
                .Take(10)
                .Select(person => (Name: person.FullName(), MaxDeposit: person.Transactions.Max(x => x.Value)))
            ;
        }

        public static (string Name, double Glucose) WhoHasMaxGlucose(List<Client> data)
        {
            return PersonsByMaxDeposit(data).First();
        }
    }
}
