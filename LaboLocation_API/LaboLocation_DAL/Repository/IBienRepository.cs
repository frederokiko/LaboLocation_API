using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IBienRepository
    {
        void CreateBien(NewBien bi);
        IEnumerable<Bien> GetAll();
        Bien GetById(int id);
        IEnumerable<Bien> GetByCp(int cp);
        IEnumerable<Bien> GetByPrix(int prix);
      
        void SetBien(int id_proprietaire,bool est_louer ,int location_prix, DateTime disponible ,string caution_txt,int caution_montant  );
    }
}
