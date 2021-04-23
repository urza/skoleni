using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleniConsoleApp1
{
    public class Client 
    {
        private string name;

      
        public Client(string name)
        {
            try
            {
                var items = name.Split(' ');
                FirstName = items[0];
                LastName = items[1];
            }
            catch (IndexOutOfRangeException ex)
            {
                LastName = " +++ ";
            }
            catch(Exception ex)
            {
                throw;
            }
            

            this.name = name;
        }

        
        public string FirstName {  get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }

        private double _accountBalance;
        public double AccountBalance 
        {
            get
            {
                return _accountBalance;
            }
            set
            {
                _accountBalance = Math.Max(0, value);
            }

        }


        public override string ToString()
        {
            return FullName();
        }

        /// <summary>
        /// Informace o klientovi - jméno, status a balance
        /// </summary>        
        public string PrintInfo()
        {
            //CultureInfo.CurrentCulture = new CultureInfo("cs-CZ");
            var dob = DateOfBirth.ToShortDateString(); //DateOfBirth.ToString("yyyy-MM-dd");
            return $"Jméno: {FullName()}, aktivní: {IsActive}, Balance:{AccountBalance}, Narozen:{dob}";
        }

        /// <summary>
        /// Vrátit jméno a příjmení jako tuple
        /// </summary>
        public (string First, string Last) GetName()
        {
            return (FirstName, LastName);
        }

        public string FullName() => $"{GetName().First} {GetName().Last}";

        public static List<Client> GetActiveOverBalance(double balance, List<Client> clients)
        {
            return clients.Where(client => client.IsActive && client.AccountBalance >= balance).ToList();
        }
    }
}
