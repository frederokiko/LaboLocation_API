using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IValideLocationRepository
    {
        void CreateValideLocation(AddValideLocation vl);

        IEnumerable<ValideLocation> GetByIdBien(int id);
        void SetValideLocation(int idbien, DateTime date_fin);
    }
}
