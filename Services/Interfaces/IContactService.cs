using AgendaApi.Entities;
using AgendaApi.Models;

namespace AgendaApi.Services.Interfaces
{
    public interface IContactService
    {
        void Create(CreateAndUpdateContact dto, int loggedUserId);
        void Delete(int id);
        List<Contact> GetAllByUser(int id);
        Contact GetById(int id);
        void Update(CreateAndUpdateContact dto, int contactId);
    }
}