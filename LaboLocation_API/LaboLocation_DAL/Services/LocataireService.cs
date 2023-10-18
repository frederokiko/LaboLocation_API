using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using Microsoft.AspNetCore.Rewrite;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class LocataireService : ILocataireRepository
    {
        private readonly IDbConnection _connection;
        public LocataireService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateLocataire(AddLocataire lo)
        {
            string sql = "INSERT INTO Locataire(Id_personne,Budget_locatif,Salaire_mensuel)VALUES(@id_personne,@budget_locatif,@salaire_mensuel)";
            _connection.Query(sql, lo);
        }

        public IEnumerable<Locataire> GetAll()
        {
            return _connection.Query<Locataire>("SELECT l.Id_locataire,p.Id_personne,p.Nom,p.Prenom,l.Budget_locatif,l.Salaire_mensuel,p.Id_role\r\nFROM Locataire l JOIN Personne p \r\nON l.Id_personne=p.Id_personne");
        }

        public Locataire GetById(int id)
        {
            string sql = "SELECT l.Id_locataire,p.Id_personne,p.Nom,p.Prenom,l.Budget_locatif,l.Salaire_mensuel,p.Id_role\r\nFROM Locataire l JOIN Personne p \r\nON l.Id_personne=p.Id_personne WHERE l.Id_locataire = @id";
            return _connection.QueryFirst<Locataire>(sql, new { id });
        }

        public void SetLocataire(int id_locataire, int budget, int revenu)
        {
            string sql = "UPDATE Locataire SET Budget_locatif = @budget,Salaire_mensuel = @revenu WHERE Id_locataire = @id_locataire";
            var param = new { id_locataire, budget,revenu };
            _connection.Execute(sql, param);
        }
    }
}
