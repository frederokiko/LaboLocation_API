using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IGenre_pieceRepository
    {
        void Createpiece(NewGenre_piece gp);
        IEnumerable<Genre_piece> GetAll();
        Genre_piece GetById(int id);
    }
}
