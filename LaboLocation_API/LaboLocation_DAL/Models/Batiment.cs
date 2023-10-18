namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Batiment
    {
        public int Id_batiment { get; set; }
        public bool Type_maison { get; set; }
        public bool Type_appartement { get; set; }
        public bool Charge_comprise { get; set; }
        public bool Chaufage_central { get; set; }
        public int Id_bien { get; set; }
    }
}

