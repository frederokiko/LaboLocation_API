using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagerieController : ControllerBase
    {
        private readonly IMessageRepository _messageService;

        public MessagerieController(IMessageRepository messageService)
        {
            _messageService = messageService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_messageService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_messageService.GetAllById(id));
        }
        [HttpPost("message")]
        public IActionResult Post(NewMessagerie ba)
        {
            DateTime values = DateTime.Now;

            _messageService.CreateMessage(
                new NewMessagerie
                {
                   Mess=ba.Mess,
                   Lu=ba.Lu,
                   Date_post=values,
                });
            return Ok();
        }
        [HttpPost("messagelien")]
        public IActionResult Post(NewMessageLien ba)
        {
            _messageService.CreateMessageLien(
                new NewMessageLien
                {
                 id_personne=ba.id_personne,
                 id_message=ba.id_message,
                 id_p_receive=ba.id_p_receive,
                });
            return Ok();
        }
        [HttpPatch("setmessage")]
        public IActionResult ChangeMessageStatut(ChangeMessagerie r)
        {
            _messageService.SetMessagerie(r.id_message, r.lu);
            return Ok();
        }
    }
}
