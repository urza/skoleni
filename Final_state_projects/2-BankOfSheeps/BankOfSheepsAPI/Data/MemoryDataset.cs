using BankOfSheeps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSheepsAPI.Data
{
    public class MemoryDataset
    {

        private static Dictionary<string, Client> _clients;

        public static Dictionary<string, Client> GetClients()
        {
            if (_clients == null)
            {
                _clients = new Dictionary<string, Client>();
                foreach(var client in BankOfSheeps.Data.LoadFromXML())
                {
                    _clients[client.Email] = client;
                }
            }

            return _clients;
        }

    }
}
