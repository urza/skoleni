using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleniConsoleApp1
{
    static class Extenions
    {
        public static string SimpleSerializeClient(this Client client)
        {
            return $"{client.FirstName};{client.LastName};" +
                $"{client.IsActive};{client.AccountBalance};" +
                $"{client.DateOfBirth.ToString("yyyy-MM-dd")};";
        }
    }
}
