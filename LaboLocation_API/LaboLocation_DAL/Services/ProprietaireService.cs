using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class ProprietaireService : IProprietaireRepository
    {
        private readonly IDbConnection _connection;
        public ProprietaireService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProprietaire(AddProprietaire pr)
        {
            string sql = "INSERT INTO Proprietaire(Id_personne)VALUES(@id_personne)";
            _connection.Query(sql, pr);
        }

        public IEnumerable<Proprietaire> GetAll()
        {
            return _connection.Query<Proprietaire>("SELECT pr.Id_proprietaire,p.Id_personne,p.Nom,p.Prenom,p.Email,p.Id_role"+
" FROM Proprietaire pr JOIN Personne p"+
" ON pr.Id_personne = p.Id_personne");
        }

        public Proprietaire GetById(int id)
        {
            string sql = "SELECT pr.Id_proprietaire,p.Id_personne,p.Nom,p.Prenom,p.Email,p.Id_role\r\nFROM Proprietaire pr JOIN Personne p\r\nON pr.Id_personne = p.Id_personne WHERE pr.Id_proprietaire = @id";
            return _connection.QueryFirst<Proprietaire>(sql, new { id });
        }
    }
}
