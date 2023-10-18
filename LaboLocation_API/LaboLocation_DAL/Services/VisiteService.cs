using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class VisiteService :IVisiteRepository
    {
        private readonly IDbConnection _connection;
        public VisiteService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateVisite(AddVisite vi)
        {
            string sql = "INSERT INTO Visite(Id_locataire,Id_employe,Id_bien,Date__visite,Commentaire)VALUES (@id_locataire,@id_employe,@id_bien,@date__visite,@commentaire)";
            _connection.Query(sql, vi);
        }

        public IEnumerable<Visite> GetAllBien(int id)
        {
            string sql = "SELECT * FROM Visite WHERE Id_bien = @id";
            return _connection.Query<Visite>(sql, new { id });
        }

        public IEnumerable<Visite> GetByIdEmploye(int id)
        {
            string sql = "SELECT * FROM Visite WHERE Id_employe = @id";
            return _connection.Query<Visite>(sql, new { id });
        }

        public IEnumerable<Visite> GetByIdLocataire(int id)
        {
            string sql = "SELECT * FROM Visite WHERE Id_locataire = @id";
            return _connection.Query<Visite>(sql, new { id });
        }
    }
}
