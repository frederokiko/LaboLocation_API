using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BienController : ControllerBase
    {
        private readonly IBienRepository _bienService;

        public BienController(IBienRepository bienService)
        {
            _bienService = bienService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bienService.GetAll());
        }
        [HttpGet("cp{cp}")]
        public IActionResult GetCP(int cp)
        {
            return Ok(_bienService.GetByCp(cp));
        }
        [HttpGet("prix")]
        public IActionResult GetPrix(int min,int max)
        {
            return Ok(_bienService.GetByPrix(min , max));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_bienService.GetById(id));
        }
        [HttpPatch("setBien")]
        public IActionResult ChangeBien(ChangeBien bi)
        {
            _bienService.SetBien(bi.id_Bien,bi.est_louer,bi.location_prix,bi.disponible,bi.caution_txt,bi.caution_montant);
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(NewBien bi)
        {

            int insertedId = _bienService.CreateBien(
                new NewBien
                {
                    Rue =bi.Rue,
                    Numero =bi.Numero,
                    Localite =bi.Localite,
                    Codepostal=bi.Codepostal,
                    Est_louer =bi.Est_louer,
                    Location_prix =bi.Location_prix,
                    Disponible=bi.Disponible,
                    Caution_txt =bi.Caution_txt,
                    Caution_montant=bi.Caution_montant,
                    Id_proprietaire=bi.Id_proprietaire,                    
                });
            //int insertedId = _bienService.CreateBien(bi);
            return Ok(insertedId);
        }
    }
}
