namespace LaboLocation_API.DTOs
{
    public class NewPersonne
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }
        public DateTime Date_naissance { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Passwd { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string Localite { get; set; }
        public int Codepostal { get; set; }
        public string Gsm { get; set; }
        public string Telfixe { get; set; }
    }
}
