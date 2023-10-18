using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValideBienController : ControllerBase
    {
        private readonly IValideBienRepository _validebienService;

        public ValideBienController(IValideBienRepository validebienService)
        {
            _validebienService = validebienService;

        }
        [HttpGet("{id}")]
        public IActionResult GetEmp(int id)
        {
            return Ok(_validebienService.GetByIdEmploye(id));
        }
        [HttpPost]
        public IActionResult Post(AddValideBien va)
        {

            _validebienService.CreateValideBien(
                new AddValideBien
                {
                 id_bien =va.id_bien,
                 id_employe = va.id_employe,
                 date_validation = DateTime.Now,
                });
            return Ok();
        }
    }
}
