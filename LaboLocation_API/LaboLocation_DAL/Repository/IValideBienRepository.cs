using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IValideBienRepository
    {
        void CreateValideBien(AddValideBien va);

        IEnumerable<ValideBien> GetByIdEmploye(int id);
    }
}
