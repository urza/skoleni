using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;
using System.Text;

namespace BankOfSheeps
{
	public static class Extensions
	{
		public static double NextGaussian(this Random r, double mu = 0, double sigma = 1)
		{
			var u1 = r.NextDouble();
			var u2 = r.NextDouble();

			var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
								Math.Sin(2.0 * Math.PI * u2);

			var rand_normal = mu + sigma * rand_std_normal;

			return rand_normal;
		}
	}
	public class Data
    {
        public static void GenerateToXML()
        {
            var data = GeneratePersons();
            Xml.Serialization.Serialize<List<Client>>(data, "dataset.xml");
        }
        public static List<Client> GeneratePersons()
        {
			List<Client> data = new List<Client>();
			var maleFirstNames = new[] { "Pavel", "Petr", "Adam", "Jakub", "Tomáš", "Viktor", "Martin", "Jan" };
			var maleLastNames = new[] { "Novák", "Krátký", "Klíč", "Novotný", "Vyskočil", "Kolomazník", "Janů" };
			var femaleFirstNames = new[] { "Pavla", "Petra", "Jana", "Jitka", "Tereza", "Anna", "Martina" };
			var femaleLastNames = new[] { "Nováková", "Stará", "Fialová", "Novotná", "Vyskočilová", "Kolomazníková", "Janů" };
			var streets = new[] { "Prušánecká", "Bzenecká", "Lipová", "Dubová", "Jasanová", "Pod Kaštany", "Olšová", "Dlouhá", "Kaštanová", "Třešňová", "Višňová", "Jedlého", "Horníkova", "Slavíkova", "Modřínová" };
			var cities = new[] { "Praha", "Brno", "Olomouc", "Ostrava", "Drážďany" };
			var years = new[] { 2000, 1998, 1995, 1991, 1980, 1981, 1982, 1983, 1984, 1985, 1972, 1976, 1991, 1990, 1995, 1999, 1961, 1958 };
			var months = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
			var days = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 17, 20, 21, 22, 26, 27 };
			var rnd = new Random();
			for (int i = 0; i < 33; i++)
			{
				var person = new Client()
				{
					Address = new Address() { City = cities.OrderBy(x => rnd.Next()).First(), Street = streets.OrderBy(x => rnd.Next()).First() },
					DateOfBirth = new DateTime(years.OrderBy(x => rnd.Next()).First(), months.OrderBy(x => rnd.Next()).First(), days.OrderBy(x => rnd.Next()).First()),
					FirstName = maleFirstNames.OrderBy(x => rnd.Next()).First(),
					LastName = maleLastNames.OrderBy(x => rnd.Next()).First(),
					IsActive = rnd.NextDouble() > 0.2,
					Transactions = new List<Transaction>()

				};
				person.Email = person.FirstName.RemoveDiacritics() + "." + person.LastName.RemoveDiacritics() + "." + person.DateOfBirth.Year + "@example.com";
				var person2 = new Client()
				{
					Address = new Address() { City = cities.OrderBy(x => rnd.Next()).First(), Street = streets.OrderBy(x => rnd.Next()).First() },
					DateOfBirth = new DateTime(years.OrderBy(x => rnd.Next()).First(), months.OrderBy(x => rnd.Next()).First(), days.OrderBy(x => rnd.Next()).First()),
					FirstName = femaleFirstNames.OrderBy(x => rnd.Next()).First(),
					LastName = femaleLastNames.OrderBy(x => rnd.Next()).First(),
					IsActive = rnd.NextDouble() > 0.2,
					Transactions = new List<Transaction>()
				};
				person2.Email = person2.FirstName.RemoveDiacritics() + "." + person2.LastName.RemoveDiacritics() + "." + person2.DateOfBirth.Year + "@example.com";


				data.Add(person);
				data.Add(person2);
			}

			//transactions
			foreach (var client in data)
			{
				for (int j = 0; j < 10; j++)
				{

					var date = new DateTime(rnd.Next(2018, 2021), rnd.Next(1, 10), rnd.Next(1, 28));
					double value = Math.Abs((int)(rnd.NextGaussian(20_000, 50_000))); //generujeme jen DEPOSITS
					Transaction t = new Transaction() { Date = date, Value = value, Type = TransactionType.DEPOSIT };
					client.Transactions.Add(t);
				}
			}


			return data;
        }

        public static List<Client> LoadFromXML(string file = "dataset.xml")
        {
            return Xml.Serialization.DeSerialize<List<Client>>(file);
        }
    }
}
