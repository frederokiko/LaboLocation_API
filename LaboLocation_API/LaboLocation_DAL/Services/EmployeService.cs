using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class EmployeService : IEmployeRepository
    {
        private readonly IDbConnection _connection;
        public EmployeService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateEmploye(AddEmploye em)
        {
            string sql = "INSERT INTO Employe(Id_personne)VALUES(@id_personne)";
            _connection.Query(sql, em);
        }

        public IEnumerable<Employe> GetAll()
        {
            return _connection.Query<Employe>("SELECT e.Id_employe,p.Id_personne,p.Nom,p.Prenom,p.Email,p.Id_role\r\n" +
                                              "FROM Employe e JOIN Personne p\r\n" +
                                              "ON e.Id_personne = p.Id_personne");
        }

        public Employe GetById(int id)
        {
            string sql = "SELECT e.Id_employe,p.Id_personne,p.Nom,p.Prenom,p.Email,p.Id_role\r\nFROM Employe e JOIN Personne p\r\nON e.Id_personne = p.Id_personne WHERE e.Id_employe = @id";
            return _connection.QueryFirst<Employe>(sql, new { id });
        }
    }
}
