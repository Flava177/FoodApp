﻿using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    internal sealed class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Address> GetAllAddresses(bool trackChanges) =>
            FindAll(trackChanges)
        .OrderBy(c => c.Street)
        .ToList();

        public Address GetAddress(Guid addressId, bool trackChanges) =>

         FindByCondition(c => c.Id.Equals(addressId), trackChanges)
                .SingleOrDefault() ?? throw new Exception("Address not found.");

        
        public void CreateAddress(Address address) => Create(address);




    }
}
