namespace LaboLocation_API.DTOs
{
    public class AddValideLocation
    {
        public int id_bien { get; set; }
        public DateTime date_debut { get; set; }
        public DateTime date_fin { get; set; }
        public int id_locataire { get; set; }
        public int id_employe { get; set; }
    }
}
