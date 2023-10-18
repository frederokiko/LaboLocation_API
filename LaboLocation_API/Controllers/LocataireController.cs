using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocataireController : ControllerBase
    {
        private readonly ILocataireRepository _locataireService;

        public LocataireController(ILocataireRepository locataireService)
        {
            _locataireService = locataireService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_locataireService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_locataireService.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(AddLocataire lo)
        {

            _locataireService.CreateLocataire(
                new AddLocataire
                {
                    Id_personne = lo.Id_personne,
                    Budget_locatif=lo.Budget_locatif,
                    Salaire_mensuel=lo.Salaire_mensuel,
                });
            return Ok();
        }
        [HttpPatch("setLocataire")]
        public IActionResult ChangeRole(ChangeLocataire r)
        {
            _locataireService.SetLocataire(r.id_locataire, r.budget,r.revenu);
            return Ok();
        }
    }
}
