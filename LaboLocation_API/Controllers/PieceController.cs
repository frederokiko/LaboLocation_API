using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieceController : ControllerBase
    {
        private readonly IPieceRepository _pieceService;

        public PieceController(IPieceRepository pieceService)
        {
            _pieceService = pieceService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pieceService.GetAll());
        }

        [HttpGet("/bat{pi}")]
        public IActionResult GetBati(int pi)
        {
            return Ok(_pieceService.GetBybat(pi));
        }
        [HttpPost]
        public IActionResult Post(NewPiece pi)
        {
            int resultcarre = (pi.longueur*pi.largeur);
            _pieceService.Createpiece(
                new NewPiece
                {
                    longueur = pi.longueur,
                    largeur = pi.largeur,
                    surface = resultcarre,
                    commentaire = pi.commentaire,
                    id_batiment = pi.id_batiment,
                    id_genre = pi.id_genre,      
                });
            return Ok();
        }
    }
}
