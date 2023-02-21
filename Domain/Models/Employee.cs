using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        [Index(0)]
        public int Dni { get; set; }
        [Index(1)]
        public int HorasLaboradas { get; set; }
        [Index(2)]
        public int DiasLaborados { get; set; }
        [Index(3)]
        public int Faltas { get; set; }
        [Index(4)]
        public int TipoTrabajador { get; set; }

        public double Sueldo { get; set; }
    }
}
