using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfSheeps
{
	
	public class Data
    {
       public static List<Client> LoadFromXML(string file = "dataset.xml")
        {
            return Xml.Serialization.DeSerialize<List<Client>>(file);
        }
    }
}
