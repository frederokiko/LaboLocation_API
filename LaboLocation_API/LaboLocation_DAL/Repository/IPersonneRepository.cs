using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IPersonneRepository
    {
        void CreatePersonne(NewPersonne np);
        IEnumerable<Personne> GetAll();
        Personne GetById(int id);
        Personne LoginPersonne(string email, string password);
        void SetRole(int idUser, int idRole);
    }
}
