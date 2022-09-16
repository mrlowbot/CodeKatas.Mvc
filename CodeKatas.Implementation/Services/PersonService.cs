using CodeKatas.Abstractions.Contracts;
using CodeKatas.Abstractions.Services;

namespace CodeKatas.Implementation.Services
{
    public class PersonService : IPersonService
    {
        public Guid Create(PersonCarrier carrier)
        {
            throw new NotImplementedException();
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
