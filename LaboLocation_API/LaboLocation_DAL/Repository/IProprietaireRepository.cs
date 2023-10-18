using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IProprietaireRepository
    {
        void CreateProprietaire(AddProprietaire pr);
        IEnumerable<Proprietaire> GetAll();
        Proprietaire GetById(int id);
    }
}
