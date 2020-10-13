using System;
using System.Collections.Generic;
using System.Text;

namespace MF.Rb.Domain.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
    }
}
