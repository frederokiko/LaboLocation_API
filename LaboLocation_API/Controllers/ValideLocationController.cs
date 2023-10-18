using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValideLocationController : ControllerBase
    {
        private readonly IValideLocationRepository _validelocationService;

        public ValideLocationController(IValideLocationRepository validelocationService)
        {
            _validelocationService = validelocationService;

        }
        [HttpGet("{id}")]
        public IActionResult GetBien(int id)
        {
            return Ok(_validelocationService.GetByIdBien(id));
        }
        [HttpPost]
        public IActionResult Post(AddValideLocation vl)
        {

            _validelocationService.CreateValideLocation(
                new AddValideLocation
                {
                    id_bien=vl.id_bien,
                    date_debut=vl.date_debut,
                    date_fin=vl.date_fin,
                    id_employe=vl.id_employe,
                    id_locataire=vl.id_locataire,
                });
            return Ok();
        }
        [HttpPatch("setdate")]
        public IActionResult ChangeRole(ChangeValideLocation vl)
        {
            _validelocationService.SetValideLocation(vl.id_bien,vl.date_fin);
            return Ok();
        }
    }
}
