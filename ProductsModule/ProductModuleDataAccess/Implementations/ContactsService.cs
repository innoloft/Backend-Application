using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductModuleDataAccess.Implementations
{
    public class ContactsService : IContactsService
    {
        private readonly ProducrModuleDbContext _dbContext;

        public ContactsService(ProducrModuleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Contacts> GetAllContacts()
        {
            var allContacts = _dbContext.contacts.ToList();

            return allContacts;
        }
    }
}
