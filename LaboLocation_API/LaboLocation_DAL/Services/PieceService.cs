using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class PieceService : IPieceRepository
    {
        private readonly IDbConnection _connection;
        public PieceService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Createpiece(NewPiece pi)
        {
            string sql = "INSERT INTO Piece(Longueur,Largeur,Surface,Commentaire,Id_genre,Id_batiment) VALUES(@longueur,@largeur,@surface,@commentaire,@id_genre,@id_batiment)";
            _connection.Query(sql, pi);
        }

        public IEnumerable<Piece> GetAll()
        {
            return _connection.Query<Piece>("SELECT * FROM Piece");
        }

        public IEnumerable<Piece> GetBybat(int id_bat)
        {
            string sql = "SELECT * FROM Piece WHERE Id_batiment = @id_bat";
            return _connection.Query<Piece>(sql, new { id_bat });
        }

        public Piece GetById(int id)
        {
            string sql = "SELECT * FROM Piece WHERE Id_Piece = @id";
            return _connection.QueryFirst<Piece>(sql, new { id });
        }
    }
}
