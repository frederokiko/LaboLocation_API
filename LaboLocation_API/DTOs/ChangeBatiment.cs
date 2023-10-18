namespace LaboLocation_API.DTOs
{
    public class ChangeBatiment
    {
        public bool type_maison { get; set; }
        public bool type_appartement { get; set; }
        public bool charge_comprise { get; set; }
        public bool chaufage_central { get; set; }
        public int id_bien { get; set; }
    }
}
