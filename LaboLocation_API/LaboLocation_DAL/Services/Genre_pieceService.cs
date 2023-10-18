using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class Genre_pieceService : IGenre_pieceRepository

    {
        private readonly IDbConnection _connection;
        public Genre_pieceService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Createpiece(NewGenre_piece gp)
        {
            string sql = "INSERT INTO Genre_piece(Nom)VALUES(@nom)";
            _connection.Query(sql, gp);
        }

        public IEnumerable<Genre_piece> GetAll()
        {
            return _connection.Query<Genre_piece>("SELECT * FROM Genre_piece");
        }

        public Genre_piece GetById(int id)
        {
            string sql = "SELECT Id_genre ,Nom FROM Genre_piece WHERE Id_genre = @id";
            return _connection.QueryFirst<Genre_piece>(sql, new { id });
        }
    }
}
