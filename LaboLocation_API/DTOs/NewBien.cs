namespace LaboLocation_API.DTOs
{
    public class NewBien
    {
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string Localite { get; set; }
        public int Codepostal { get; set; }
        public bool Est_louer { get; set; }
        public int Location_prix { get; set; }
        public DateTime Disponible { get; set; }
        public string Caution_txt { get; set; }
        public int Caution_montant { get; set; }
        public int Id_proprietaire { get; set; }
    }
}
