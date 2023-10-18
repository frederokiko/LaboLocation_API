namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Bien
    {
        public int Id_bien { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string Localite { get; set; }
        public int Codepostal { get; set; }
        public bool Est_louer { get; set; }
        public bool Est_valider { get; set; }
        public int Location_prix { get; set; }
        public DateTime Disponible { get; set; }
        public string Caution_txt { get; set; }
        public int Caution_montant { get; set; }
        public int Id_proprietaire { get; set; }
    }
}
//Id_bien INT,
//  Rue VARCHAR(100) NOT NULL,
//  Numero VARCHAR(10) NOT NULL,
//  Localite VARCHAR(100) NOT NULL,
//  Codepostal INT NOT NULL,
//  Est_louer LOGICAL NOT NULL,
//  Est_valider LOGICAL NOT NULL,
//  Location_prix INT NOT NULL,
//  Disponible DATE NOT NULL,
//  Caution_txt VARCHAR(200),
//   Caution_montant INT NOT NULL,
//   Id_proprietaire INT NOT NULL,
