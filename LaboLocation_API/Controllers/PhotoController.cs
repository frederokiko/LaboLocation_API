using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoService;

        public PhotoController(IPhotoRepository photoService)
        {
            _photoService = photoService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_photoService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_photoService.GetAllById(id));
        }
        [HttpGet("gar{id}")]
        public IActionResult GetIdGarage(int id)
        {
            return Ok(_photoService.GetAllByIdGarage(id));
        }
        [HttpPost]
        public IActionResult Post(NewPhotos ph)
        {
         

            _photoService.CreatePhoto(
                new NewPhotos
                {
                  nom=ph.nom,
                  photos=ph.photos,
                  id_Pieces=ph.id_Pieces,
                });
            return Ok();
        }
        [HttpPost("garage")]
        public IActionResult Post(NewPhotosGarage pg)
        {


            _photoService.CreatePhotoGarage(
                new NewPhotosGarage
                {
                    nom = pg.nom,
                    photos = pg.photos,
                });
            return Ok();
        }
    }
}
