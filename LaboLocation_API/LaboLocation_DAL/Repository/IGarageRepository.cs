using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IGarageRepository
    {
        void CreateGarage(NewGarage ga);
        IEnumerable<Garage> GetAll();
        Garage GetByIdBien(int id);
    }
}
