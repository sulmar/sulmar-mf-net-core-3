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
            return reader.GetNullableDateTime(reader.GetOrdinal(name));
        }
        public static DateTime? GetNullableDateTime(this OracleDataReader reader, int col)
        {
            return reader.IsDBNull(col) ? null : (DateTime?)reader.GetDateTime(col);
        }

        public static string GetNullableString(this OracleDataReader reader, int col)
        {
            return reader.IsDBNull(col) ? null : reader.GetString(col);
        }

        public static string GetNullableString(this OracleDataReader reader, string name)
        {
            return reader.GetNullableString(reader.GetOrdinal(name));
        }

        public static short? GetNullableInt16(this OracleDataReader reader, int col)
        {
            return reader.IsDBNull(col) ? null : (short?)reader.GetInt16(col);
        }

        public static short? GetNullableInt16(this OracleDataReader reader, string name)
        {
            return reader.GetNullableInt16(reader.GetOrdinal(name));
        }

        public static int? GetNullableInt32(this OracleDataReader reader, int col)
        {
            return reader.IsDBNull(col) ? null : (int?) reader.GetInt32(col);
        }

        public static int? GetNullableInt32(this OracleDataReader reader, string name)
        {
            return reader.GetNullableInt32(reader.GetOrdinal(name));
        }

        public static long? GetNullableInt64(this OracleDataReader reader, int col)
        {
            return reader.IsDBNull(col) ? null : (long?)reader.GetInt64(col);
        }

        public static long? GetNullableInt64(this OracleDataReader reader, string name)
        {
            return reader.GetNullableInt64(reader.GetOrdinal(name));
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
