using CsvHelper;
using CsvHelper.Configuration;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class DbContext
    {
        public List<Employee> ReadEmployees()
        {
            var employees = new List<Employee>();
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|"
            };

            using (var reader = new StreamReader("data-trabajadores.csv"))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.RegisterClassMap<EmployeeMap>();
                employees = csv.GetRecords<Employee>().ToList();
            }

            return employees;
        }
    }
}
