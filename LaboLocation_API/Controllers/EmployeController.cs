using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using LaboLocation_API.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly IEmployeRepository _employeService;
       
        public EmployeController(IEmployeRepository employeService)
        {
            _employeService = employeService;
          
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_employeService.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(AddEmploye em)
        {
          
            _employeService.CreateEmploye(
                new AddEmploye
                {                   
                    Id_personne=em.Id_personne                  
                });
            return Ok();
        }
    }
}
