using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoGarageController : ControllerBase
    {
        private readonly IPhotoGarageRepository _photogarageService;

        public PhotoGarageController(IPhotoGarageRepository photogarageService)
        {
            _photogarageService = photogarageService;

        }
        [HttpPost]
        public IActionResult Post(AddPhoto_Garage pg)
        {


            _photogarageService.CreatePhotoGarage(
                new AddPhoto_Garage
                {
               id_garage=pg.id_garage,
               id_photos=pg.id_photos,
                });
            return Ok();
        }
    }
}
