<Query Kind="Program" />

void Main()
{
	List<Person> data = new List<Person>();
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
		var person = new Person() 
		{
			Address = new Address(){ City = cities.OrderBy(x => rnd.Next()).First(), Street = streets.OrderBy(x => rnd.Next()).First()},
			DateOfBirth = new DateTime(years.OrderBy(x => rnd.Next()).First(),months.OrderBy(x => rnd.Next()).First(),days.OrderBy(x => rnd.Next()).First()),
			Name = maleFirstNames.OrderBy(x => rnd.Next()).First() + " " + maleLastNames.OrderBy(x => rnd.Next()).First(),
			GlucoseRecords = new List<GlucoseMeasurement>(),
			Notes = new List<NoteRecord>()
			
		};
		var person2 = new Person()
		{
			Address = new Address() { City = cities.OrderBy(x => rnd.Next()).First(), Street = streets.OrderBy(x => rnd.Next()).First() },
			DateOfBirth = new DateTime(years.OrderBy(x => rnd.Next()).First(), months.OrderBy(x => rnd.Next()).First(), days.OrderBy(x => rnd.Next()).First()),
			Name = femaleFirstNames.OrderBy(x => rnd.Next()).First() + " " + femaleLastNames.OrderBy(x => rnd.Next()).First(),
			GlucoseRecords = new List<GlucoseMeasurement>(),
			Notes = new List<NoteRecord>()
		};
		
		for (int j = 0; j < 20; j++)
		{

			var date = new DateTime(rnd.Next(2018, 2019), rnd.Next(1, 10), rnd.Next(1, 28));
			for(int k= 0; k < rnd.Next(1,12); k++)
			{
				GlucoseMeasurement m = new GlucoseMeasurement()
				{
					Value = rnd.NextDouble() * 10,
					Time = date.AddHours(rnd.Next(6,22))
				};
				person.GlucoseRecords.Add(m);
				person2.GlucoseRecords.Add(m);
			}
		}

		data.Add(person);
		data.Add(person2);

	}

	//data.Dump();
	//data.OrderByDescending(person => person.GlucoseRecords.Max(x => x.Value))
	//.Select(person => new { Name = person.Name, MaxGlucose = person.GlucoseRecords.Max(x => x.Value) } )
	//.Dump();
	
}

public class Person
{
	public string Name { get; set; }
	public DateTime DateOfBirth { get; set; }
	public Address Address { get; set; }

	/// <summary>
	/// Records of glucose measurements with date and time
	/// </summary>
	public List<GlucoseMeasurement> GlucoseRecords { get; set; }
	
	public List<NoteRecord> Notes { get; set; }

}

public class Address
{
	public string Street { get; set; }
	public string City { get; set; }
}

/// <summary>
/// Note with Date
/// </summary>
public class NoteRecord
{
	/// <summary>
	/// Optional note about the day
	/// </summary>
	public string Note { get; set; }

	/// <summary>
	/// Date of the day
	/// </summary>
	public DateTime Date { get; set; }

}

public class GlucoseMeasurement
{
	/// <summary>
	/// Glucose value in in mg/dL
	/// </summary>
	public double Value { get; set; }

	/// <summary>
	/// Time of day when the measurement was taken
	/// </summary>
	public DateTime Time { get; set; }
}