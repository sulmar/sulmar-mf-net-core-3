using MF.Rb.Domain;
using MF.Rb.Domain.Repository;
using MF.Rb.FakeRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Schema;
using MF.Fundamentals.Extensions;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace MF.Fundamentals.ConsoleClient
{
    public class CustomerInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerInfo2
    {
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }

    //public class Anounmouse_5034534573475934757349534959346534
    //{
    //    public string Imie { get; set; }
    //    public string Nazwisko { get; set; }
    //}

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello .NET Core!");

            // TypesTest();
            // StructTest();
            // ClassTest();
            // ArrayTest();
            // CollectionTest();
            // GenericTypesTest();
            // InterfacesTest();
            // ConstructorTest();
            // RepositoryTest();
            // ExtensionMethodTest();


             // AnonymousTypesTest();


            // Wyświetlenie bieżącego identyfikatora wątku
            // Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");

            // Sender sender = new Sender();

            // Synchroniczne wywołanie metody
            // sender.Send("Hello World!");

            // Asynchroniczne wywołanie metody
            // Task task = new Task(() => sender.Send("Hello World!"));
            // ...
            // task.Start();

            //  Task task = Task.Run(() => sender.Send("Hello World!"));


            // Synchronicznie

            //decimal cost = sender.Calculate("Hello !");

            //if (cost < 10)
            //{
            //    sender.Send("Hello World!");
            //}
            //else
            //{
            //    Console.WriteLine($"Zbyt drogo {cost}");
            //}


            // Asynchronicznie za pomocą Task i ContitueWith

            /*
            Task<decimal> task = Task.Run(()=>sender.Calculate("Hello World!"));

            // Jak zakończysz pierwsze zadanie, to wykonaj kolejne zadanie (ContinueWith)
            task.ContinueWith(t =>
            {
                if (t.Result < 10)
                {
                    Task.Run(()=>sender.Send("Hello !"));
                }
                else
                {
                    Console.WriteLine($"Zbyt drogo {t.Result}");
                }
            });

            */

            /*
           

            */

            // SendMessageAsync(sender);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        // Typy anonimowe
        private static void AnonymousTypesTest()
        {
            Customer customer = new Customer("John", "Smith");

            // SQL: SELECT * FROM Customers

            // SQL: SELECT FirstName, LastName FROM Customers

            //CustomerInfo customerInfo = new CustomerInfo();
            //customerInfo.FirstName = customer.FirstName;
            //customerInfo.LastName = customer.LastName;


            // Typ anonimowy
            // Klasa jest generowana automatycznie przez kompilator na podstawie przypisanych pól

            // SQL: SELECT FirstName AS Imie, LastName AS Nazwisko, Salary = 1000 FROM Customers
            var customerInfo = new { Imie = customer.FirstName, Nazwisko = customer.LastName, Salary = 1000m };

            Console.WriteLine(customerInfo);

            // var - określa automatycznie typ na podstawie przypisania
            // nie można później zmienić tego typu
            float x = 10.0f;
        }



        // Metoda synchroniczna 
        private static void SendMessage(Sender sender)
        {
            decimal cost = sender.Calculate("Hello!");

            if (cost < 10)
            {
                sender.Send("Hello!");
            }
            else
            {
                Console.WriteLine($"Zbyt drogo {cost}");
            }
        }

        // Metoda asynchroniczna z użyciem async-await
        private static async Task SendMessageAsync(Sender sender)
        {
            // await - oczekiwanie na zakończenie Task i pobiera wartość typu T ze zmiennej Task.Result
            decimal cost = await sender.CalculateAsync("Hello!");

            if (cost < 10)
            {
                await sender.SendAsync("Hello World!");
            }
            else
            {
                Console.WriteLine($"Zbyt drogo {cost}");
            }
        }

        // Metoda asynchroniczna z użyciem ContinueWith
        private static void SendMessageWithContinueWith(Sender sender)
        {
            Task<decimal> task = sender.CalculateAsync("Hello World!");

            // Jak zakończysz pierwsze zadanie, to wykonaj kolejne zadanie (ContinueWith)
            task.ContinueWith(t =>
            {
                if (t.Result < 10)
                {
                    sender.SendAsync("Hello !");
                }
                else
                {
                    Console.WriteLine($"Zbyt drogo {t.Result}");
                }
            });
        }

        private static void ExtensionMethodTest()
        {
            DateTime date = DateTime.Today;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Weekend!");
            }
            else
            {
                Console.WriteLine("Dzień roboczy");
            }


            // Wywołanie metody statycznej
            if (DateTimeHelper.IsHoliday(date))
            {
                Console.WriteLine("Weekend!");
            }
            else
            {
                Console.WriteLine("Dzień roboczy");
            }

            // Wywołanie metody rozszerzającej

            if (date.IsHoliday())
            {
                Console.WriteLine("Weekend!");
            }
            else
            {
                Console.WriteLine("Dzień roboczy");
            }


            DateTime dueDate = date.AddWorkingDays(5);

            // Rozszerzenie typu string

            string message = "Hello Wor    ld!";

            message = message.Normalization();

            Console.WriteLine(message);
        }

        private static void RepositoryTest()
        {
            IReportRepository reportRepository = new FakeReportRepository();

            IEnumerable<Report> reports = reportRepository.Get(1);

            foreach (Report report in reports)
            {
                Console.WriteLine(report.Dysponent.Name);
            }
        }

        private static void ConstructorTest()
        {
            Customer customer = new Customer("John", "Smith");
            customer.FirstName = "Ann";
            // customer.LastName = "Smith";
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
            Customer customer = new Customer("John", "Smith");
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
