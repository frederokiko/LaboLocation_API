
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatimentController : ControllerBase
    {
        private readonly IBatimentRepository _batimentService;

        public BatimentController(IBatimentRepository batimentService)
        {
            _batimentService = batimentService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_batimentService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_batimentService.GetById(id));
        }
        [HttpGet("/app{choix}")]
        public IActionResult Getapp(bool choix)
        {
            return Ok(_batimentService.GetByApp(choix));
        }
        [HttpGet("/mai{choix}")]
        public IActionResult Getmai(bool choix)
        {
            return Ok(_batimentService.GetByMai(choix));
        }
        [HttpPatch("setBien")]
        public IActionResult ChangeBien(ChangeBatiment ba)
        {
            _batimentService.SetBatiment(ba.id_bien, ba.type_maison, ba.type_appartement, ba.charge_comprise, ba.chaufage_central);
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(NewBatiment ba)
        {

            _batimentService.CreateBatiment(
                new NewBatiment
                {
                    Type_maison = ba.Type_maison,
                    Type_appartement = ba.Type_appartement,
                    Charge_comprise = ba.Charge_comprise,
                    Chaufage_central = ba.Chaufage_central,
                    Id_bien = ba.Id_bien,

                });
            return Ok();
        }
    }
}