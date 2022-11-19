using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Working
{
    internal class LaptopHandler
    {
        private LaptopHandler() { }

        private static string _filePath = "D:/Default.json";
        public static string FilePath { get => _filePath; set => _filePath = value; }

        private static List<Laptop> laptops = new List<Laptop>();
        public static List<Laptop> Laptops { get => laptops; set => laptops = value; }
        private static List<Laptop> filteredLaptops = new List<Laptop>();
        public static List<Laptop> FilteredLaptops { get => filteredLaptops; set => filteredLaptops = value; }

        public static void AddLaptop(Laptop laptop)
        {
            foreach (var checkingLaptop in laptops)
            {
                if (checkingLaptop.ID == laptop.ID)
                {
                    throw new Exception("Can not add laptop with and ID that is already taken.");
                }
            }
            laptops.Add(laptop);
        }

        public static void RemoveById(int ID)
        {
            for (int i = 0; i < laptops.Count; i++)
            {
                if (laptops.ElementAt(i).ID == ID)
                {
                    laptops.RemoveAt(i);
                }
            }
        }
    }
}
