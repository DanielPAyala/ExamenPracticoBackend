using Domain.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public IActionResult Get() {
            try
            {
                var listEmployees = _employeeRepository.GetEmployees().Select(x => new
                {
                    x.Dni,
                    x.TipoTrabajador,
                    x.Sueldo
                });
                return Ok(listEmployees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{dni}")]
        public IActionResult Get(int dni)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(dni);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
