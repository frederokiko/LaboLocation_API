namespace LaboLocation_API.DTOs
{
    public class ChangeBien
    {
        public int id_Bien { get; set; }
        public bool est_louer { get; set; }
        public int location_prix { get; set; }
        public DateTime disponible { get; set; }
        public string caution_txt { get; set; }
        public int caution_montant { get; set; }
        
    }
}
