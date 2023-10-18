using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;
using System.Data.Common;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class ValideBienService : IValideBienRepository
    {
        private readonly IDbConnection _connection;
       
        public ValideBienService(IDbConnection connection)
        {
            _connection = connection;
        }
        
        public void CreateValideBien(AddValideBien va)
        {
            string sql = "  INSERT INTO Valide(Id_employe,Id_bien,Date_validation)VALUES(@id_employe,@id_bien,@date_validation)";
            _connection.Query(sql, va);
        }

        public IEnumerable<ValideBien> GetByIdEmploye(int id)
        {
            string sql = "SELECT * FROM Valide WHERE Id_employe = @id";
            return _connection.Query<ValideBien>(sql, new { id });
        }
    }
}
