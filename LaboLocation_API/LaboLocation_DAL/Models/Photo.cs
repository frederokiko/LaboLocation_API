namespace LaboLocation_API.LaboLocation_DAL.Models
{
    public class Photo
    {
        public int Id_photos { get; set; }
        public string Nom { get; set; }
        public string Photos { get; set; }
        public int? Id_Pieces { get; set; }
    }
}
//Id_photos INT,
//  Nom VARCHAR(100) NOT NULL,
//  Photos LONGBINARY,
//  Id_Pieces INT NOT NULL,
