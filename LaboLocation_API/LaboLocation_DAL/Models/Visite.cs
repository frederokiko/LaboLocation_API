using LaboLocation_API.DTOs;

namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Visite
    {
        public int Id_locataire { get; set; }
        public int Id_employe { get; set; }
        public int Id_bien { get; set; }
        public DateTime Date__visite { get; set; }
        public string Commentaire { get; set; }
    }
}
//Id_locataire, Id_employe, Id_bien, Date__visite, Commentaire