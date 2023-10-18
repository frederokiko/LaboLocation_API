using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface ILocataireRepository
    {
        void CreateLocataire(AddLocataire lo);
        IEnumerable<Locataire> GetAll();
        Locataire GetById(int id);
        void SetLocataire(int id_locataire, int budget, int revenu);
    }
}
