<Query Kind="Program" />

void Main()
{
	List<Client> data = new List<Client>();
	var maleFirstNames = new[] {"Pavel", "Petr","Adam","Jakub","Tomáš","Viktor","Martin","Jan"};
	var maleLastNames = new[] { "Novák", "Krátký", "Klíč", "Novotný", "Vyskočil", "Kolomazník", "Janů" };
	var femaleFirstNames = new[] { "Pavla", "Petra", "Jana", "Jitka", "Tereza", "Anna", "Martina" };
	var femaleLastNames = new[] { "Nováková", "Stará", "Fialová", "Novotná", "Vyskočilová", "Kolomazníková", "Janů" };
	var streets = new[] { "Prušánecká", "Bzenecká", "Lipová", "Dubová", "Jasanová", "Pod Kaštany", "Olšová", "Dlouhá", "Kaštanová", "Třešňová", "Višňová", "Jedlého", "Horníkova", "Slavíkova", "Modřínová" };
	var cities = new[] { "Praha", "Brno", "Olomouc", "Ostrava", "Drážďany" };
	var years = new[] { 1980, 1981, 1982, 1983, 1984, 1985, 1972, 1976, 1991, 1990, 1995, 1999, 1961, 1958 };
	var months = new[] {1,2,3,4,5,6,7,8,9,10,11,12};
	var days = new[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,20,21,22,26,27};
	var rnd = new Random();
	for (int i = 0; i < 13; i++)
	{
		var person = new Client() 
		{
			Address = new Address(){ City = cities.OrderBy(x => rnd.Next()).First(), Street = streets.OrderBy(x => rnd.Next()).First()},
			DateOfBirth = new DateTime(years.OrderBy(x => rnd.Next()).First(),months.OrderBy(x => rnd.Next()).First(),days.OrderBy(x => rnd.Next()).First()),
			FirstName = maleFirstNames.OrderBy(x => rnd.Next()).First(),
			LastName = maleLastNames.OrderBy(x => rnd.Next()).First(),
			Transactions = new List<Transaction>()
			
		};
		var person2 = new Client()
		{
			Address = new Address() { City = cities.OrderBy(x => rnd.Next()).First(), Street = streets.OrderBy(x => rnd.Next()).First() },
			DateOfBirth = new DateTime(years.OrderBy(x => rnd.Next()).First(), months.OrderBy(x => rnd.Next()).First(), days.OrderBy(x => rnd.Next()).First()),
			FirstName = femaleFirstNames.OrderBy(x => rnd.Next()).First(),
			LastName = femaleLastNames.OrderBy(x => rnd.Next()).First(),
			Transactions = new List<Transaction>()
		};

		data.Add(person);
		data.Add(person2);
	}
	
	//transactions
	foreach(var client in data)
	{
		for (int j = 0; j < 10; j++)
		{

			var date = new DateTime(rnd.Next(2018, 2021), rnd.Next(1, 10), rnd.Next(1, 28));
			double value = (rnd.NextDouble() * 100_000); //generujeme jen DEPOSITS
			Transaction t = new Transaction(){ Date = date, Value = value, Type = TransactionType.DEPOSIT };
			client.Transactions.Add(t);
		}
	}

	data.Dump();
	//data.OrderByDescending(person => person.GlucoseRecords.Max(x => x.Value))
	//.Select(person => new { Name = person.Name, MaxGlucose = person.GlucoseRecords.Max(x => x.Value) } )
	//.Dump();
	
}

public class Client
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public bool IsActive { get; set; }

	public double AccountBalance {get;set;}

	public DateTime DateOfBirth { get; set; }
	
	public Address Address { get; set; }
	
	public List<Transaction> Transactions {get; set;}

	public string FullName()
	{
		return FirstName + " " + LastName;
	}
}

public class Address
{
	public string Street { get; set; }
	public string City { get; set; }
}


public class Transaction
{
	public TransactionType Type {get; set;}
	
	public DateTime Date { get; set; }
	
	public double Value {get; set;}
	
	public string Note { get; set; }
	
}

public enum TransactionType
{
	DEPOSIT,
	WITHDRAW
}

