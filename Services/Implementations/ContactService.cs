using AgendaApi.Data;
using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly AgendaContext _context;

        public ContactService(AgendaContext context)
        {
            _context = context;
        }
        public List<Contact> GetAllByUser(int id)
        {

            return _context.Contacts.Include(c => c.User).Where(c => c.User.Id == id).ToList();
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.SingleOrDefault(c => c.Id == id);
        }

        public void Create(CreateAndUpdateContact dto, int loggedUserId)
        {
            Contact contact = new Contact()
            {
                Email = dto.email,
                Image = dto.image,
                Number = dto.number,
                Company = dto.company,
                Address = dto.address,
                LastName = dto.lastName,
                Name = dto.name,
                UserId = loggedUserId,
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(CreateAndUpdateContact dto, int contactId)
        {
            Contact? contact = _context.Contacts.SingleOrDefault(contact => contact.Id == contactId);
            if (contact is not null)
            {
                contact.Email = dto.email;
                contact.Image = dto.image;
                contact.Number = dto.number;
                contact.Company = dto.company;
                contact.Address = dto.address;
                contact.LastName = dto.lastName;
                contact.Name = dto.name;
                _context.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            var contactToDelete = _context.Contacts.SingleOrDefault(c => c.Id == id);
            if (contactToDelete != null)
            {
                _context.Contacts.Remove(contactToDelete);
                _context.SaveChanges();
            }
        }
    }
}
