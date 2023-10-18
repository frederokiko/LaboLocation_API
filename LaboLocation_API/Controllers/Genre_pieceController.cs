using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Genre_pieceController : ControllerBase
    {
        private readonly IGenre_pieceRepository _genre_pieceService;

        public Genre_pieceController(IGenre_pieceRepository genre_pieceService)
        {
            _genre_pieceService = genre_pieceService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_genre_pieceService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_genre_pieceService.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(NewGenre_piece gp)
        {

            _genre_pieceService.Createpiece(
                new NewGenre_piece
                {
                    nom = gp.nom,
                });
            return Ok();
        }
    }
}
