namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Proprietaire
    {
        public int Id_proprietaire { get; set; }
        public int Id_personne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Id_role { get; set; }
    }
}
