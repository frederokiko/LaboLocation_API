using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IBatimentRepository
    {
        void CreateBatiment(NewBatiment ba);
        IEnumerable<Batiment> GetAll();
        Batiment GetById(int id);
        Batiment GetByApp(bool choix);
        Batiment GetByMai(bool choix);
        void SetBatiment(int id_bien, bool type_maison,bool type_appartement,bool charge_comprise,bool chauffage_central);
    }
}

