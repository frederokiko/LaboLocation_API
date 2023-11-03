using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;
using System.Data.Common;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class BatimentService : IBatimentRepository
    {
        private readonly IDbConnection _connection;
        public BatimentService(IDbConnection connection)
        {
            _connection = connection;
        }
        public int CreateBatiment(NewBatiment ba)
        {
            string sql = "INSERT INTO Batiment(Type_maison,Type_appartement,Charge_comprise,Chaufage_central,Id_bien)VALUES(@type_maison,@type_appartement,@charge_comprise,@chaufage_central,@id_bien)" +
                         "SELECT CAST(SCOPE_IDENTITY() AS INT)"; 
           return _connection.Query<int>(sql, ba).Single();
        }
         //return _connection.Query<int>(sql, bi).Single();

        public IEnumerable<Batiment> GetAll()
        {
            return _connection.Query<Batiment>("SELECT * FROM Batiment");
        }

        public Batiment GetById(int id)
        {
            string sql = "SELECT * FROM Batiment WHERE Id_batiment = @id";
            return _connection.QueryFirst<Batiment>(sql, new { id });
        }
        public Batiment GetByIdBat(int id)
        {
            string sql = "SELECT * FROM Batiment WHERE Id_bien = @id";
            return _connection.QueryFirst<Batiment>(sql, new { id });
        }
        public IEnumerable<Batiment> GetByApp(bool choix)
        {
            string sql = "SELECT * FROM Batiment WHERE Type_appartement = @choix";
            return _connection.Query<Batiment>(sql, new { choix });
        }
        public IEnumerable<Batiment> GetByMai(bool choix)
        {
            string sql = "SELECT * FROM Batiment WHERE Type_maison = @choix";
            return _connection.Query<Batiment>(sql, new { choix });
        }

        public void SetBatiment(int id_bien, bool type_maison, bool type_appartement, bool charge_comprise, bool chauffage_central)
        {
            string sql = "UPDATE Batiment SET Type_maison=@type_maison,Type_appartement=@type_appartement,Charge_comprise=@charge_comprise,Chaufage_central=@chauffage_central WHERE Id_bien = @id_bien";
            var param = new { id_bien, type_maison,type_appartement,charge_comprise,chauffage_central };
            _connection.Execute(sql, param);
        }
    }
}
