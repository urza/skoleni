using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiaDataSet
{
    public class Data
    {
        public static List<Person> LoadFromXML(string file = "dataset.xml")
        {
            return Xml.Serialization.DeSerialize<List<Person>>(file);
        }
    }
}
