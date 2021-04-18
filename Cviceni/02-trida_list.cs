using System;
using System.Collections.Generic;
using System.Linq;

class Client
{
    public string Name { get; set; }

    public bool IsActive { get; set; }

    public double AccountBalance { get; set; }
}

/// 1. Deklarujte seznam 5 klientů, přiřaďte jim nějaké hodnoty Name, IsActive a AccountBalance

List<Client> clients = ..

/// 2. najděte a vypište aktivní klienty s balancí větší než 5000

/// 3. refaktorujte 2. na metodu/funkci

/// 4. upravte třídu Client, aby rozlišovala jméno a příjmení a přidejte metodu "FullName", která vypíše celé jméno

/// 5. upravte property AccountBalance, aby nedovolila nastavit záporné hodnoty (minimum balance 0)


