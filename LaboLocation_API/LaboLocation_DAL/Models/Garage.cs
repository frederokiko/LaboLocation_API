namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Garage
    {
        public int Id_garage { get; set; }
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public int Surface { get; set; }
        public int Id_bien { get; set; }

    }
}
//Id_garage INT,
// Longueur INT NOT NULL,
// Largeur INT NOT NULL,
// Surface INT NOT NULL,
// Id_bien INT NOT NULL,
