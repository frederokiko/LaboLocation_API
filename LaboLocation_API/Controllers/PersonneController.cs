using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.Tools;
using Microsoft.AspNetCore.Mvc;
using System;


namespace LaboLocation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly IPersonneRepository _personneService;
        private readonly TokenGenerator _tokenGenerator;
        public PersonneController(IPersonneRepository personneService, TokenGenerator tokenGenerator)
        {
            _personneService = personneService;
            _tokenGenerator = tokenGenerator;
        }
   
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personneService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_personneService.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(NewPersonne person)
        {         
            string customSalt = person.Email;
            // Mot de passe entré par l'utilisateur
            string motDePasseUtilisateur = person.Passwd;
            // Concaténez le sel personnalisé avec le mot de passe
            string motDePasseAvecSel = customSalt + motDePasseUtilisateur;
            // Hachez le mot de passe avec BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(motDePasseAvecSel);
            _personneService.CreatePersonne(
                new NewPersonne
                {
                    Nom = person.Nom,
                    Prenom = person.Prenom,
                    Date_naissance = person.Date_naissance,
                    Email = person.Email,
                    Nickname = person.Nickname,
                    Passwd = hashedPassword,          
                    Rue=person.Rue,
                    Numero=person.Numero,
                    Localite=person.Localite,
                    Codepostal=person.Codepostal,
                    Gsm=person.Gsm,
                    Telfixe=person.Telfixe,
                }) ;
            return Ok();
        }
        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangeRole r)
        {
            _personneService.SetRole(r.UserId, r.RoleId);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(PersonneLogin user)
        {
            try
            {
               
                Personne connectedUser = _personneService.LoginPersonne(user.Email, user.Password);
                // Sel personnalisé extrait de la base de données
                string selPersonnaliseDeLaBaseDeDonnees = user.Email;
                // Mot de passe entré par l'utilisateur
                string motDePasseUtilisateur = user.Password;
                // Concaténez le sel personnalisé avec le mot de passe
                string motDePasseAvecSel = selPersonnaliseDeLaBaseDeDonnees + motDePasseUtilisateur;
                // Mot de passe haché extrait de la base de données
                string motDePasseStockeDansLaBaseDeDonnees = connectedUser.Passwd;
                bool motDePasseValide = BCrypt.Net.BCrypt.Verify(motDePasseAvecSel, motDePasseStockeDansLaBaseDeDonnees);
                if (motDePasseValide)
                {
                    // Le mot de passe est valide, accordez l'accès à l'utilisateur.
                    return Ok(_tokenGenerator.GenerateToken(connectedUser));
                }
                else
                {
                    // Le mot de passe est incorrect, rejetez l'accès.
                    return BadRequest();
                }
               // return Ok(_tokenGenerator.GenerateToken(connectedUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
