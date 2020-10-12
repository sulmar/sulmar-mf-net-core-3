using System;
using System.Collections.Generic;
using System.Text;

namespace MF.Fundamentals.ConsoleClient
{
    public class Customer
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public decimal Salary;
        public DateTime CreatedDate;
        public bool IsRemoved;

        public void Print()
        {
            Console.WriteLine($"{Id} {FirstName} {LastName}");
        }
    }

    public class Order
    {
        public int Id;
        public string Number;
        public DateTime OrderDate;
        public Customer Customer;

        public IEnumerable<OrderDetail> Details;  // Typ generyczny
    }

    public class OrderDetail
    {
        public int Id;
        public byte Quantity;
        public decimal UnitPrice;
        public Product Product; 
    }

    public class Product
    {
        public int Id;
        public string Name;
        public decimal UnitPrice;
        public string Color;
    }
}
