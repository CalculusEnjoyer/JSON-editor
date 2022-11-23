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
            if (iD < 0 ) throw new Exception("Wrong data. Diagonal should be greater than 0");
            if (diagonal < 0 || diagonal > 100) throw new Exception("Wrong data. Diagonal should be in 0 to to 100");
            if (numberOfCores < 1 || numberOfCores > 1024) throw new Exception("Wrong data. Number of cores should be in 1 to 1024");
            if (yearOfRealise < 1900 || yearOfRealise > 2022) throw new Exception("Wrong data. Year should be in 1900 to 2022");
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
