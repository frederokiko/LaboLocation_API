using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IVisiteRepository
    {
        void CreateVisite(AddVisite vi);

        IEnumerable <Visite> GetByIdEmploye(int id);
        IEnumerable<Visite> GetByIdLocataire(int id);
        IEnumerable<Visite> GetAllBien(int id);    
    }
}
