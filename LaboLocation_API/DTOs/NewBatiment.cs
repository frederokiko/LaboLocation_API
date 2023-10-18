namespace LaboLocation_API.DTOs
{
    public class NewBatiment
    {
        public bool Type_maison { get; set; }
        public bool Type_appartement { get; set; }
        public bool Charge_comprise { get; set; }
        public bool Chaufage_central { get; set; }
        public int Id_bien { get; set; }
    }
}
