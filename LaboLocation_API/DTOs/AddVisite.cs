namespace LaboLocation_API.DTOs
{
    public class AddVisite
    {
        public int id_locataire { get; set; }
        public int id_employe { get; set; }
        public int id_bien { get; set; }
        public DateTime date__visite { get; set; }
        public string commentaire { get; set; }
    }
}
