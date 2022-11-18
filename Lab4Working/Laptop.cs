using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Working
{
    internal class Laptop
    {
        public int ID { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public string CpuProducer { get; set; }
        public int NumberOfCores { get; set; }
        public double Diagonal { get; set; }
        public int YearOfRealise { get; set; }

        public Laptop(int iD, string producer, string model, string cpuProducer, int numberOfCores, double diagonal, int yearOfRealise)
        {
            ID = iD;
            Producer = producer ?? throw new ArgumentNullException(nameof(producer));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            CpuProducer = cpuProducer ?? throw new ArgumentNullException(nameof(cpuProducer));
            NumberOfCores = numberOfCores;
            Diagonal = diagonal;
            YearOfRealise = yearOfRealise;
        }
    }
}
