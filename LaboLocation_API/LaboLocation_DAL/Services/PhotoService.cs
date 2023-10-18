using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;
using System.Data.Common;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class PhotoService : IPhotoRepository
    {
        private readonly IDbConnection _connection;
        public PhotoService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreatePhoto(NewPhotos ph)
        {
            string sql = "INSERT INTO Photos(Nom,Photos,Id_Pieces) VALUES(@nom,@photos,@id_Pieces)";
            _connection.Query(sql, ph);
        }

        public void CreatePhotoGarage(NewPhotosGarage pg)
        {
            string sql = "INSERT INTO Photos(Nom,Photos) VALUES(@nom,@photos)";
            _connection.Query(sql, pg);
        }

        public IEnumerable<Photo> GetAll()
        {
            return _connection.Query<Photo>("SELECT * FROM Photos");
        }

        public IEnumerable<Photo> GetAllById(int id)
        {
            string sql = "SELECT * FROM Photos WHERE Id_Pieces = @id";
            return _connection.Query<Photo>(sql, new { id });
        }

        public IEnumerable<Photo> GetAllByIdGarage(int id)
        {
            string sql = " SELECT*  FROM Photos p Join Photo_garage pg  ON p.Id_photos=pg.Id_photos JOIN Garage g ON pg.Id_garage= g.Id_garage  WHERE g.Id_garage=@id";
            return _connection.Query<Photo>(sql, new { id });
        }
    }
}
