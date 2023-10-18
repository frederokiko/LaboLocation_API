namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Piece
    {
        public int Id_Pieces { get; set; }
      
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public int Surface { get; set; }
        public string Commentaire { get; set; }
        public int Id_genre { get; set; }
        public int Id_batiment { get; set; }
    }
}
//Id_Pieces INT,
//Longueur INT NOT NULL,
//Largeur INT NOT NULL,
//Surface INT NOT NULL,
//Commentaire VARCHAR(500),
//   Id_genre INT NOT NULL,
//   Id_batiment INT NOT NULL,
