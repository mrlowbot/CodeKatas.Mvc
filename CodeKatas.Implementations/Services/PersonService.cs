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
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                StreetAddress1 = carrier.StreetAddress1,
                StreetAddress2 = carrier.StreetAddress2,
                PostalCode = carrier.PostalCode,
                City = carrier.City,
                Country = carrier.Country,
                PersonId = personId,
            };

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return (Guid)carrier.AddressId;
        }

        public void Delete(Guid personId)
        {
            var person = _context.Persons.Find(personId);

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public void DeleteAddress(Guid addressId)
        {
            var address = _context.Addresses.Find(addressId);

            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public PersonCarrier Get(Guid personId)
        {
            return ProjectCarrierModel(_context.Persons.Find(personId));
        }

        public IList<PersonCarrier> GetAll()
        {
            return _context.Persons
                //.Include(p => p.Addresses)
                .Select(ProjectCarrierModel)
                .ToList();
        }

        public void SetAddress(Guid personId, Guid addressId)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonCarrier carrier)
        {
            var person = new Person
            {
                PersonId = carrier.PersonId,
                FirstName = carrier.FirstName,
                LastName = carrier.LastName,
                PhoneNumber = carrier.PhoneNumber
            };

            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        private PersonCarrier ProjectCarrierModel(Person person)
        {
            return new PersonCarrier
            {
                PersonId = (Guid)person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Addresses = person.Addresses != null
                    ? person.Addresses
                            .Select(a => new AddressCarrier
                            {
                                AddressId = a.AddressId,
                                StreetAddress1 = a.StreetAddress1,
                                StreetAddress2 = a.StreetAddress2,
                                PostalCode = a.PostalCode,
                                City = a.City,
                                Country = a.Country
                            })
                            .ToArray()
                    : Array.Empty<AddressCarrier>()
             };
        }
    }
}

