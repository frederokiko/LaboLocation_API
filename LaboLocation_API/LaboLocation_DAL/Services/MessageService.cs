using Dapper;
using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;
using LaboLocation_API.LaboLocation_DAL.Repository;
using System.Data;
using System.Data.Common;

namespace LaboLocation_API.LaboLocation_DAL.Services
{
    public class MessageService : IMessageRepository
    {
        private readonly IDbConnection _connection;
        public MessageService(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateMessage(NewMessagerie me)
        {
            string sql = "INSERT INTO Messagerie(Mess,Lu,Date_post)VALUES(@mess,@lu,@date_post)";
            _connection.Query(sql, me);
        }

        public void CreateMessageLien(NewMessageLien ml)
        {
            string sql = "INSERT INTO Message(Id_personne,Id_message,Id_p_receive)VALUES(@id_personne,@id_message,@id_p_receive)";
            _connection.Query(sql, ml);
        }

        public IEnumerable<Messagerie> GetAll()
        {
            return _connection.Query<Messagerie>("SELECT * FROM Messagerie WHERE Lu ='false'");
        }

        public IEnumerable<MesMessage> GetAllById(int id)
        {
            string sql = "SELECT m.Id_message,me.Id_personne,m.Mess,m.Lu,m.Date_post,me.Id_p_receive FROM Messagerie m JOIN Message me ON m.Id_message=me.Id_message JOIN Personne p ON p.Id_personne =me.Id_p_receive WHERE m.Lu ='false' AND me.Id_p_receive = @id";
            return _connection.Query<MesMessage>(sql, new { id });
            
        }

        public void SetMessagerie(int id_message, bool lu)
        {
            string sql = "UPDATE Messagerie SET Lu = @lu WHERE Id_message = @id_message";
            var param = new { id_message, lu };
            _connection.Execute(sql, param);
        }
    }
}
