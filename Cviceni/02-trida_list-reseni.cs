using System;
using System.Collections.Generic;
using System.Linq;

class Client
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

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
            _accountBalance = value;
        }
    }

    public string FullName()
    {
        return FirstName + " " + LastName;
    }

    public string FullName() => $"{FirstName} {LastName}"; //C# 8
    
}

/// 1. Deklarujte seznam 5 klientů, přiřaďte jim nějaké hodnoty Name, IsActive a AccountBalance

List<Client> clients = new List<Client>()
    {
        new Client(){ Name="Alice", IsActive=true, AccountBalance=500},
        new Client(){ Name="Bob", IsActive=true, AccountBalance=50},
        new Client(){ Name="Charlie", IsActive=false, AccountBalance=10_000},
        new Client(){ Name="Dave", IsActive=false, AccountBalance=6_000_000},
        new Client(){ Name="Eve", IsActive=true, AccountBalance=8_500},
    };

/// 2. najděte a vypište aktivní klienty s balancí větší než 5000

var eligibleClients = GetEligicleClients(clients);

/// 3. refaktorujte 2. na metodu/funkci
 
public void GetEligicleClients(List<Client> clients)
{
    return clients.Where(x => x.IsActive && x.AccountBalance > 5000);
}

/// 4. upravte třídu Client, aby rozlišovala jméno a příjmení a přidejte metodu "FullName", která vypíše celé jméno
 
/// 5. upravte property AccountBalance, aby nedovolila nastavit záporné hodnoty (minimum balance 0)
/// tzn. příkaz: client.AccountBalance = -5;
/// nastaví 0



