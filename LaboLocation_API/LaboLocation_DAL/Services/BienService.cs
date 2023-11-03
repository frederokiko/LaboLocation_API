using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class BienService : IBienRepository
    {
        private readonly IDbConnection _connection;
        public BienService(IDbConnection connection)
        {
            _connection = connection;
        }
        public int CreateBien(NewBien bi)
        {
            string sql = "INSERT INTO Bien (Rue, Numero, Localite, Codepostal, Est_louer, Location_prix, Disponible, Caution_txt, Caution_montant, Id_proprietaire) " +
                         "VALUES (@rue, @numero, @localite, @codepostal, @est_louer, @location_prix, @disponible, @caution_txt, @caution_montant, @id_proprietaire);" +
                         "SELECT CAST(SCOPE_IDENTITY() AS INT)";
            return _connection.Query<int>(sql, bi).Single();
        }

        public IEnumerable<Bien> GetAll()
        {
            return _connection.Query<Bien>("SELECT * FROM Bien");
        }
        public IEnumerable<Bien> GetById(int id)
        {
            string sql = "SELECT * FROM Bien WHERE Id_bien = @id";
            return _connection.Query<Bien>(sql, new { id });
        }

        public IEnumerable<Bien> GetByCp(int cp)
        {
            string sql = "SELECT * FROM Bien WHERE Codepostal = @cp";
            return _connection.Query<Bien>(sql, new { cp });
        }

        public IEnumerable<Bien> GetByPrix(int min,int max)
        {
            string sql = "SELECT * FROM Bien WHERE Location_prix BETWEEN @min AND @max";
            return _connection.Query<Bien>(sql, new { min , max });
        }

        public void SetBien(int id_bien, bool est_louer, int location_prix, DateTime disponible, string caution_txt, int caution_montant)
        {
            string sql = "UPDATE Bien SET Est_louer = @est_louer,Location_prix=@location_prix,Disponible = @disponible , Caution_txt=@caution_txt,Caution_montant = @caution_montant WHERE Id_bien = @id_bien";
            var param = new { id_bien, est_louer, location_prix, disponible, caution_txt, caution_montant };
            _connection.Execute(sql, param);
        }
    }
}
