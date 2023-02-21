using Domain.IRepository;
using Domain.Models;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbContext _context = new();

        public Employee GetEmployeeById(int id)
        {
            return _context.ReadEmployees().Where(x => x.Dni == id).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return _context.ReadEmployees().Select(x => new Employee
            {
                Dni = x.Dni,
                TipoTrabajador = x.TipoTrabajador,
                Sueldo = CalcularSueldo(x)

            }).ToList();
        }


        private double CalcularSueldo(Employee employee)
        {
            double sueldo = 0;
            var cases = new Dictionary<Func<Employee, bool>, Action>
            {
                {
                    employee => employee.TipoTrabajador == 0,
                    () =>  sueldo = (((employee.HorasLaboradas * employee.DiasLaborados * 15.0) - (120.0 * employee.Faltas)) + 130.0) * 0.88
                },
                {
                    employee => employee.TipoTrabajador == 1,
                    () =>  sueldo = (((employee.HorasLaboradas * employee.DiasLaborados * 35.0) - (280.0 * employee.Faltas)) + 200.0) * 0.84
                },
                {
                    employee => employee.TipoTrabajador == 2,
                    () =>  sueldo = (((employee.HorasLaboradas * employee.DiasLaborados * 85.0) - (680.0 * employee.Faltas)) + 350.0) * 0.82
                }
            };
            cases.First(x => x.Key(employee)).Value();
            return sueldo;
        }
    }
}
