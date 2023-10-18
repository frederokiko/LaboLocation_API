using LaboLocation_API.DTOs;

namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class ValideBien
    {
        public int Id_employe { get; set; }
        public int Id_bien { get; set; }
        public DateTime Date_validation { get; set; }
    }
}
//Id_employe, Id_bien, Date_validation