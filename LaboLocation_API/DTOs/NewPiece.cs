namespace LaboLocation_API.DTOs
{
    public class NewPiece
    {
       
        public int longueur { get; set; }
        public int largeur { get; set; }
        public int surface { get; set; }
        public string? commentaire { get; set; }
        public int id_genre { get; set; }
        public int id_batiment { get; set; }
    }
}
