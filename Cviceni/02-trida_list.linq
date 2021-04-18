<Query Kind="Program" />

void Main()
{
	/// 1. Deklarujte seznam 5 klientů, přiřaďte jim nějaké hodnoty Name, IsActive a AccountBalance
	List<Client> clients = new List<Client>()
	{
		new Client(){ Name="Alice", IsActive=true, AccountBalance=500},
		new Client(){ Name="Bob", IsActive=true, AccountBalance=50},
		new Client(){ Name="Charlie", IsActive=false, AccountBalance=10_000},
		new Client(){ Name="Dave", IsActive=false, AccountBalance=6_000_000},
		new Client(){ Name="Eve", IsActive=true, AccountBalance=8_500},
	}
	
	
	/// 2. najděte a vypište aktivní klienty s balancí větší než 5000
	
	/// 3. refaktorujte 2. na metodu/funkci
	
	/// 4. upravte třídu Client, aby rozlišovala jméno a příjmení a přidejte metodu "FullName", která vypíše celé jméno
	
	/// 5. upravte property AccountBalance, aby nedovolila nastavit záporné hodnoty (minimum balance 0)
}

class Client
{
	public string Name {get;set;}
	
	public bool IsActive {get; set;}
	
	public double AccountBalance {get; set;}
}
