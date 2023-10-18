using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;
using System.Data.Common;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class GarageService : IGarageRepository
    {
        private readonly IDbConnection _connection;
        public GarageService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateGarage(NewGarage ga)
        {
            string sql = "INSERT INTO Garage (Longueur,Largeur,Surface,Id_bien)Values (@longueur,@largeur,@surface,@id_bien)";
            _connection.Query(sql, ga);
        }

        public IEnumerable<Garage> GetAll()
        {
            return _connection.Query<Garage>("SELECT * FROM Garage");
        }

        public Garage GetByIdBien(int id)
        {
            string sql = "SELECT * FROM Garage WHERE Id_bien = @id";
            return _connection.QueryFirst<Garage>(sql, new { id });
        }
    }
}
