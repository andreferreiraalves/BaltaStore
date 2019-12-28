using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;

namespace BaltaStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document) => false;

        public bool CheckEmail(string email) => false;

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            return new CustomerOrdersCountResult
            {
                Id = Guid.NewGuid(),
                Document = "11252529015",
                Name = "André",
                Orders = 10
            };
        }

        public void Save(Customer customer) { }
    }
}