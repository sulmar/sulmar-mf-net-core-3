using MF.Rb.Domain;
using MF.Rb.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MF.Rb.FakeRepository
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private Collection<Customer> customers;

        public FakeCustomerRepository()
        {
            customers = new Collection<Customer>();
            

        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }
    }
}
