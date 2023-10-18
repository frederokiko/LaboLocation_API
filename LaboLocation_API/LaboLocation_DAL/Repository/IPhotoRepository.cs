using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IPhotoRepository
    {
        void CreatePhoto(NewPhotos ph);
        void CreatePhotoGarage(NewPhotosGarage pg);
        IEnumerable<Photo> GetAll();
        IEnumerable<Photo> GetAllById(int id);
        IEnumerable<Photo> GetAllByIdGarage(int id);
    }
}
