using System;
using System.Collections;
using System.Collections.ObjectModel;
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
            // ClassTest();
            // ArrayTest();
            // CollectionTest();
            // GenericTypesTest();

            InterfacesTest();

        }

        private static void InterfacesTest()
        {
           // ISmsMessageService smsMessageService = new ASmsMessageService();
            
            SmsMessageFactory smsMessageFactory = new SmsMessageFactory();

            ISmsMessageService smsMessageService = smsMessageFactory.Create("A");

            smsMessageService.SendSms("Hello .NET Core!");
            // smsMessageService.SendPremiumSms("Hello Premium");

            decimal cost = smsMessageService.GetCostSms("Hello .NET Core!");

            // snippet: cw
            Console.WriteLine($"Cost {cost}");
        }

        // Typy generyczne - klasy generyczne, metody generyczne, (interfejsy generyczne)
        private static void GenericTypesTest()
        {
            GenericMethodsTest();
            GenericClassesTest();
        }

        private static void GenericClassesTest()
        {
            Printer<string> stringPrinter = new Printer<string>();
            stringPrinter.Print("Hello World!");

            Printer<Product> productPrinter = new Printer<Product>();
            productPrinter.Print(new Product());

            Printer<Service> servicePrinter = new Printer<Service>();
            servicePrinter.Print(new Service());
        }

        private static void GenericMethodsTest()
        {
            Printer printer = new Printer();
            printer.Print<string>("Hello World!");
            printer.Print<DateTime>(DateTime.Now);
            printer.Print<Product>(new Product());
            printer.Print(new Service());
            printer.Print(DateTime.Now);
            printer.Print(true);
        }

        // Kolekcje - posiada określony typ i jest zmiennego rozmiaru
        private static void CollectionTest()
        {
            Collection<int> numbers = new Collection<int>();
            numbers.Add(10);
            numbers.Add(20);

            Collection<Product> products = new Collection<Product>();
            products.Add(new Product());
            products.Add(new Product());
            products.Add(new Product());

            products.RemoveAt(1);

            products.Clear();

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }
        }


        // Tablica - posiada określony typ i jest stałego rozmiaru
        private static void ArrayTest()
        {
            int[] numbers = new int[10];    // tablica jednowymiarowa 
            numbers[0] = 10;
            numbers[1] = 20;
            numbers[2] = 30;

            int[] happyNumbers = new int[] { 10, 20, 30 };

            foreach (int number in numbers)     // iteracja po wszystkich elementach zbioru
            {
                Console.WriteLine(number);
            }
        }

        private static void ClassTest()
        {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "John";
            customer.LastName = "Smith";
            customer.IsRemoved = false;
            customer.CreatedDate = DateTime.Now;

            customer.CalculateSalary();

            customer.Salary = 1000;
            Console.WriteLine(customer.Salary);

            //customer.SetSalary(1000);
            //Console.WriteLine(customer.GetSalary());

            customer.Print();


            Product product = new Product();
            product.Id = 1;
            product.Name = "Myszka komputera";
            product.Color = "Biały";

            Service service = new Service();
            service.Id = 1;
            service.Name = "Szkolenie .NET Core";
            service.Duration = TimeSpan.FromDays(5);

            Item item1 = product;
            Item item2 = service;
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


    // Struktura - typ wartościowy (trzymany na stosie)
    // Może zawierać pola i metody
    // struktura nie ma możliwości dziedziczenia z innej struktury
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
