using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System;
using System.Data;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class PersonneService : IPersonneRepository
    {
        private readonly IDbConnection _connection;
        public PersonneService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreatePersonne(NewPersonne np)
        {
            string sql = "INSERT INTO Personne (Nom,Prenom,Date_naissance,Email,Nickname,Passwd,Rue,Numero,Localite,Codepostal,Gsm,Telfixe) " +
                " VALUES (@nom,@prenom,@date_naissance,@email,@nickname,@passwd,@rue,@numero,@localite,@codepostal,@gsm,@telfixe)";
            _connection.Query(sql, np);
        }
        //Nom, Prenom, Date_naissance, Email, Nickname, Passwd, Rue, Numero, Localite, Codepostal, Gsm, Telfixe, Id_role
        public IEnumerable<Personne> GetAll()
        {
            return _connection.Query<Personne>("SELECT * FROM Personne");
        }

        public Personne GetById(int id)
        {
            string sql = "SELECT * FROM Personne WHERE Id_personne = @id";
            return _connection.QueryFirst<Personne>(sql, new { id });
        }
        public Personne LoginPersonne(string email, string password)
        {
            try
            {
                string sql = "SELECT * FROM Personne WHERE Email = @email ";//+
                  //  "Passwd = @password";
                var param = new { email, password };
                return _connection.QueryFirst<Personne>(sql, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine(password);
                throw new InvalidOperationException("Utilisateur inéxistant");
            }
        }

        public void SetRole(int idUser, int idRole)
        {
            string sql = "UPDATE Personne SET Id_role = @idRole WHERE Id_personne = @idUser";
            var param = new { idUser, idRole };
            _connection.Execute(sql, param);
        }
    }
}
