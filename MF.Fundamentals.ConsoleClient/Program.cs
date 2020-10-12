using System;
using System.Xml.Schema;

namespace MF.Fundamentals.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello .NET Core!");

            // TypesTest();
            // StructTest();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "John";
            customer.LastName = "Smith";
            customer.Salary = 1000;
            customer.IsRemoved = false;
            customer.CreatedDate = DateTime.Now;

            customer.Print();
        }

        private static void StructTest()
        {
            Console.Write("Podaj miasto: ");
            string city = Console.ReadLine();

            Console.Write("Podaj ulicę: ");
            string street = Console.ReadLine();

            Address address = new Address();
            address.City = city;
            address.Street = street;
            address.PostCode = "01-001";
            address.Country = "Poland";

            address.Print();
        }

        private static void TypesTest()
        {
            // liczby całkowite
            byte age = 100;
            short a = 100;
            int x = 10;
            long counter = 100;


            // liczby rzeczywiste
            double speed = 100.99;
            float weight = 0.6f;

            decimal salary = 10.99m;  // kwoty

            // daty
            DateTime createdDate = DateTime.Today;
            TimeSpan interval = TimeSpan.FromMinutes(5);

            // ciąg tekstowy
            string firstName = "John";
        }
    }



    struct Address
    {
        public string City;
        public string Street;
        public string PostCode;
        public string Country;

        public void Print()
        {
            // zła praktyka
            // string fullAddress = City + " " + Street + " " + PostCode + " " + Country;

            // string fullAddress = string.Format("{0} {1} {2} {4}", City, Street, PostCode, Country);

            string fullAddress = $"{City} {Street} {PostCode} {Country}";   // interpolacja

            Console.WriteLine(fullAddress);
        }
    }
}
