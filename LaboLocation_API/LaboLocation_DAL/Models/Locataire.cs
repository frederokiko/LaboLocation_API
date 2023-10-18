namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Locataire
    {
        public int Id_locataire { get; set; }
        public int Id_personne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Budget_locatif { get; set; }
        public int Salaire_mensuel { get; set; }
        public int Id_role { get; set; }

       
        
    }
}
