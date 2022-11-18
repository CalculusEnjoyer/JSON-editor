using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4Working
{
    internal class Filter
    {
        private Filter() { }

        public static IEnumerable<Laptop> FilterByProducer(String producer, List<Laptop> input)
        {
            return from l in input where l.Producer.Equals(producer) select l;
        }

        public static IEnumerable<Laptop> FilterByModel(String model, List<Laptop> input)
        {
            return from l in input where l.Model.Equals(model) select l;
        }

        public static IEnumerable<Laptop> FilterByYear(int year, List<Laptop> input)
        {
            return from l in input where l.YearOfRealise == year select l;
        }
    }
}
