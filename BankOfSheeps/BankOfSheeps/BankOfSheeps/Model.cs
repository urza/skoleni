using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfSheeps
{
	public class Client
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public bool IsActive { get; set; }

		public double AccountBalance { get; set; }

		public DateTime DateOfBirth { get; set; }

		public Address Address { get; set; }

		public List<Transaction> Transactions { get; set; }
        public string Email { get;  set; }

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
		public TransactionType Type { get; set; }

		public DateTime Date { get; set; }

		public double Value { get; set; }

		public string Note { get; set; }

	}

	public enum TransactionType
	{
		DEPOSIT,
		WITHDRAW
	}


}
