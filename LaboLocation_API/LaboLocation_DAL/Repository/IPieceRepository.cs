using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IPieceRepository
    {
        void Createpiece(NewPiece pi);
        IEnumerable<Piece> GetAll();
        IEnumerable<Piece> GetBybat(int id_bat);
        Piece GetById(int id);
    }
}
