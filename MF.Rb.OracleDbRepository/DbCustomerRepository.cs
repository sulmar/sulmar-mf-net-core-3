using MF.Rb.Domain;
using MF.Rb.Domain.Repository;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MF.Rb.OracleDbRepository
{

    public static class ReaderExtensions
    {
        public static DateTime? GetNullableDateTime(this OracleDataReader reader, string name)
        {
            int col = reader.GetOrdinal(name);
            return reader.GetNullableDateTime(col);
        }
        public static DateTime? GetNullableDateTime(this OracleDataReader reader, int col)
        {
            return reader.IsDBNull(col) ? (DateTime?)null : (DateTime?)reader.GetDateTime(col);
        }
    }

    // dotnet add package Oracle.ManagedDataAccess.Core
    public class DbCustomerRepository : ICustomerRepository
    {
        private readonly OracleConnection connection;

        public DbCustomerRepository(OracleConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Customer> Get()
        {
            string sql = "select * from Customers";
            OracleCommand command = new OracleCommand(sql, connection);

            ICollection<Customer> customers = new Collection<Customer>();
            
            using(OracleDataReader reader = command.ExecuteReader())
            {
                customers.Add(Map(reader));
            }

            return customers;
        }

        private Customer Map(OracleDataReader reader)
        {
            Customer customer = new Customer
            {
                ActiveTo = reader.GetNullableDateTime("From"),

            };

            return customer;
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
