using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDataSet
{
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
}
