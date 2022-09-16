﻿using CodeKatas.Abstractions.Contracts;

namespace CodeKatas.Abstractions.Services
{
    public interface IPersonService
    {
        IList<PersonCarrier> GetAll();

        PersonCarrier Get(Guid personId);

        Guid Create(PersonCarrier carrier);

        void Update(PersonCarrier carrier);

        void Delete(Guid personId);

        Guid CreateAddress(AddressCarrier carrier, Guid personId);

        void SetAddress(Guid personId, Guid addressId);

        void DeleteAddress(Guid addressId);
    }
}
