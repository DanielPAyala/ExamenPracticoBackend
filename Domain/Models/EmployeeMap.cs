using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(p => p.Dni).Index(0);
            Map(p => p.HorasLaboradas).Index(1);
            Map(p => p.DiasLaborados).Index(2);
            Map(p => p.Faltas).Index(3);
            Map(p => p.TipoTrabajador).Index(4);
        }
    }
}
