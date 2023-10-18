using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private readonly IGarageRepository _garageService;

        public GarageController(IGarageRepository garageService)
        {
            _garageService = garageService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_garageService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetBati(int id)
        {
            return Ok(_garageService.GetByIdBien(id));
        }
        [HttpPost]
        public IActionResult Post(NewGarage ga)
        {
            int resultcarre = (ga.longueur * ga.largeur);
            _garageService.CreateGarage(
                new NewGarage
                {
                    longueur = ga.longueur,
                    largeur = ga.largeur,
                    surface = resultcarre,   
                    id_bien = ga.id_bien, 
                });
            return Ok();
        }
    }
}
