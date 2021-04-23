using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfSheeps
{
	public class Client
	{
		public int Id { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public bool IsActive { get; set; }

		public double AccountBalance => Transactions.Sum(x => x.Value);

		public DateTime DateOfBirth { get; set; }

		public Address Address { get; set; }

		public List<Transaction> Transactions { get; set; }

		public string FullName() => FirstName + " " + LastName;

	}

	public class Address
	{
		public int Id { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
	}

	public class Transaction
	{
		public int Id { get; set; }
		public TransactionType Type { get; set; }

		public DateTime Date { get; set; }

		/// <summary>
		/// Positive for DEPOSITS, negative value for WITHDRAWALS
		/// </summary>
		public double Value { get; set; }

		public string Note { get; set; }

	}

	public enum TransactionType
	{
		DEPOSIT,
		WITHDRAW
	}


}
