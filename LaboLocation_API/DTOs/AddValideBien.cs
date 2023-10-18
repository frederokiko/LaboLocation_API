namespace LaboLocation_API.DTOs
{
    public class AddValideBien
    {
        public int id_employe { get; set; }
        public int id_bien { get; set; }
        public DateTime date_validation { get; set; }
    }
}
