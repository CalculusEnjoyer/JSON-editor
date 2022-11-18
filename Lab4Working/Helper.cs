using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Working
{
    internal class Helper
    {
        private Helper(){ }

        public static Laptop CreateLaptopFromStringValues(string ID, string Producer, string Model, 
            string CpuProducer, string NumberOfCores, string Diagonal, string YearOfRealise)
        {
            int id;
            int numberOfCores;
            double diagonal;
            int yearOfRealise;
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Producer) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(CpuProducer)
                || string.IsNullOrEmpty(NumberOfCores) || string.IsNullOrEmpty(Diagonal) || string.IsNullOrEmpty(YearOfRealise))
            {
                throw new Exception("Fields must not be empty");
            }
            else if (!int.TryParse(ID, out id))
            {
                throw new Exception("ID filed must be int");
            }
            else if (!int.TryParse(NumberOfCores, out numberOfCores))
            {
                throw new Exception("Number of cores filed must be int");
            }
            else if (!double.TryParse(Diagonal, out diagonal))
            {
                throw new Exception("Diagonal filed must be double");
            }
            else if (!int.TryParse(YearOfRealise, out yearOfRealise))
            {
                throw new Exception("Year of realise should be int");
            }

            return new Laptop(id, Producer, Model, CpuProducer, numberOfCores, diagonal, yearOfRealise);
        }
    }
}
