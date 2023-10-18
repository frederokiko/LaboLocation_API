using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using Microsoft.AspNetCore.Rewrite;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class ValideLocationService : IValideLocationRepository
    {
        private readonly IDbConnection _connection;
        public ValideLocationService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateValideLocation(AddValideLocation vl)
        {
            string sql = "  INSERT INTO Valide_location(Id_bien,Date_debut,Date_fin,Id_locataire,Id_employe)VALUES(@id_bien,@date_debut,@date_fin,@id_locataire,@id_employe)";
            _connection.Query(sql, vl); ;
        }

        public IEnumerable<ValideLocation> GetByIdBien(int id)
        {
            string sql = "SELECT * FROM Valide_location WHERE Id_bien = @id";
            return _connection.Query<ValideLocation>(sql, new { id });
        }

        public void SetValideLocation(int idbien, DateTime date_fin)
        {
            string sql = "UPDATE Valide_location SET Date_fin = @date_fin WHERE Id_bien = @idbien";
            var param = new { idbien, date_fin };
            _connection.Execute(sql, param);
        }
    }
}
