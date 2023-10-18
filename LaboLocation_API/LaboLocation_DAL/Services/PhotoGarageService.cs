using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class PhotoGarageService :IPhotoGarageRepository
    {
        private readonly IDbConnection _connection;
        public PhotoGarageService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreatePhotoGarage(AddPhoto_Garage pg)
        {
            string sql = " INSERT INTO Photo_garage(Id_garage,Id_photos)VALUES(@id_garage,@id_photos)";
            _connection.Query(sql, pg);
        }
    }
}
