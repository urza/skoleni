using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SkoleniConsoleApp1
{
    public interface IDataSet
    {
        public List<Client> LoadData();
        public void SaveData();        

    }

    public class SimpleDataset : IDataSet
    {
        private List<Client> _clients;

        public SimpleDataset()
        {
            _clients = new List<Client>();
        }
        public SimpleDataset(List<Client> clients)
        {
            _clients = clients;
        }

        public List<Client> LoadData()
        {
            string file = "data.txt";

            var lines = File.ReadLines(file);

            List<Client> clients = new List<Client>();

            foreach (var line in lines)
            {
                string[] clientData = line.Split(';');

                var c = new Client($"{clientData[0]} {clientData[1]}");

                try
                {
                    c.IsActive = bool.Parse(clientData[2]);
                }
                catch (Exception)
                {
                    c.IsActive = true;
                }

                double result;
                bool parsed = double.TryParse(clientData[3],out result);
                if (parsed)
                    c.AccountBalance = result;
                else
                    throw new Exception("Nepodařilo se rozparsovat AccountBalance");
                
                
                c.DateOfBirth = DateTime.Parse(clientData[4]);

                clients.Add(c);
            }

            return clients;

        }

        public void SaveData()
        {
            string file = "data.txt";

            // Petr; Novák; false; 200; 1999-04-21
            // Petr; Novák; false; 200; 1999-04-21
            foreach (var client in _clients)
            {
                string serializedClient = client.SimpleSerializeClient();
                File.AppendAllText(file, serializedClient + Environment.NewLine);
            }
        }
    }

    public class JsonDataset : IDataSet
    {
        private List<Client> _clients;

        public JsonDataset(List<Client> clients)
        {
            _clients = clients;
        }
        public List<Client> LoadData()
        {
            var jsonString = File.ReadAllText("data.json");
            return JsonSerializer.Deserialize<List<Client>>(jsonString);
        }

        public void SaveData()
        {
            var jsonString = JsonSerializer.Serialize(_clients);
            File.WriteAllText("data.json", jsonString);
        }
    }
}

