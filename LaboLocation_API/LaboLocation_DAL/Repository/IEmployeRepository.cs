using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IEmployeRepository
    {
        void CreateEmploye(AddEmploye em);
        IEnumerable<Employe> GetAll();
        Employe GetById(int id);
    }
}
