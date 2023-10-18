namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class ValideLocation
    {
        public int Id_bien { get; set; }
        public DateTime Date_debut { get; set; }
        public DateTime Date_fin { get; set; }
        public int Id_locataire { get; set; }
        public int Id_employe { get; set; }
    }
}
//Id_bien, Date_debut, Date_fin, Id_locataire, Id_employe