using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietaireController : ControllerBase
    {
        private readonly IProprietaireRepository _proprietaireService;

        public ProprietaireController(IProprietaireRepository proprietaireService)
        {
            _proprietaireService = proprietaireService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_proprietaireService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_proprietaireService.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(AddEmploye pr)
        {

            _proprietaireService.CreateProprietaire(
                new AddProprietaire
                {
                    Id_personne = pr.Id_personne
                });
            return Ok();
        }
    }
}
