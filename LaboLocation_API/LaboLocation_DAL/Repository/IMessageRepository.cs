using LaboLocation_API.DTOs;
using LaboLocation_API.LaboLocation_DAL.Models;

namespace LaboLocation_API.LaboLocation_DAL.Repository
{
    public interface IMessageRepository
    {
        void CreateMessage(NewMessagerie me);
        void CreateMessageLien(NewMessageLien ml);
        IEnumerable<Messagerie> GetAll();
        IEnumerable<MesMessage> GetAllById(int id);
        void SetMessagerie(int id_message, bool lu);

    }
}
