using CodeKatas.Abstractions.Contracts;
using CodeKatas.Abstractions.Services;
using CodeKatas.Database;

namespace CodeKatas.Implementations.Services
{
    public class PersonService : IPersonService
    {
        private readonly KataContext _context;

        public PersonService(KataContext context)
        {
            _context = context;
        }

        public Guid Create(PersonCarrier carrier)
        {
            var person = new Person
            {
                PersonId = Guid.NewGuid(),
                FirstName = carrier.FirstName,
                LastName = carrier.LastName,
                PhoneNumber = carrier.PhoneNumber,
            };

            _context.Persons.Add(person);
            _context.SaveChanges();

            return (Guid)person.PersonId;
        }

        public Guid CreateAddress(AddressCarrier carrier, Guid personId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid personId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public PersonCarrier Get(Guid personId)
        {
            throw new NotImplementedException();
        }

        public IList<PersonCarrier> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SetAddress(Guid personId, Guid addressId)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonCarrier carrier)
        {
            throw new NotImplementedException();
        }
    }
}

