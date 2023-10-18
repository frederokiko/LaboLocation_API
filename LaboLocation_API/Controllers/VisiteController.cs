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
    public class VisiteController : ControllerBase
    {
        private readonly IVisiteRepository _visiteService;
      
        public VisiteController(IVisiteRepository visiteService)
        {
            _visiteService = visiteService;
         
        }
        [HttpGet("/bien{id}")]
        public IActionResult GetCP(int id)
        {
            return Ok(_visiteService.GetAllBien(id));
        }
        [HttpGet("/locataire{id}")]
        public IActionResult GetLoc(int id)
        {
            return Ok(_visiteService.GetByIdLocataire(id));
        }
        [HttpGet("/employe{id}")]
        public IActionResult GetEmp(int id)
        {
            return Ok(_visiteService.GetByIdEmploye(id));
        }
        [HttpPost]
        public IActionResult Post(AddVisite vi)
        {

            _visiteService.CreateVisite(
                new AddVisite
                {
                    id_bien=vi.id_bien,
                    id_employe=vi.id_employe,
                    id_locataire=vi.id_locataire,   
                    date__visite=vi.date__visite,
                    commentaire=vi.commentaire,
                });
            return Ok();
        }
    }
}
