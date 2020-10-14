using System;
using System.Collections.Generic;
using System.Text;

namespace MF.Fundamentals.ConsoleClient
{

    // Klasa abstrakcyjna - nie można utworzyć bezpośrednio instancji tej klasy lecz tylko klas, które dziedziczą po tej klasie
    public abstract class Base
    {
        public int Id { get; set; }
    }

    // Klasa - typ referencyjny (trzymany na stercie)
    // Może zawierać pole i metody
    // Klasa umożliwia dziedziczenie po innej klasie, ale tylko po jednej!
    public class Customer : Base
    {
        //private int id;
        //public int Id 
        //{
        //    get { return id; }
        //    set { id = value; }
        //}


        private bool isSelected;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }


        // hermetyzacja danych

        /*
         
        private decimal salary;

        // getter
        public decimal GetSalary()
        {
            return salary;
        }

        // setter
        public void SetSalary(decimal value)
        {
            Console.WriteLine($"Dnia {DateTime.Now} zmieniono wynagrodzenie z {salary} na {value}");

            salary = value;

        }

        */

        private decimal salary;

        // Właściwość (property)  - prywatne pole opakowane getterem i setterem
        public decimal Salary
        {
            // getter
            get     
            {
                return salary;
            }

            // setter
            set
            {
                Console.WriteLine($"Dnia {DateTime.Now} zmieniono wynagrodzenie z {salary} na {value}");

                salary = value;
            }
        }


        // Konstruktor - wywoływany przy tworzenia instacji obiektu
        // służy do ustawiania wartości domyślnych i definowania wymaganych parametrów

        private Customer()
        {
            CreatedDate = DateTime.Now;
            IsRemoved = false;
        }

        public Customer(string firstName, string lastName)
            : this(lastName)                                // this - wywołuje inny konstruktor na tym samym poziomie
        {
            this.FirstName = firstName;
        }

        public Customer(string lastName)
            : this()
        {
            this.LastName = lastName;
        }


      

        public void Print()
        {
            Console.WriteLine($"{Id} {FirstName} {LastName}");
        }

        public void CalculateSalary()
        {
            salary = 999.99m;
        }
    }

    public class Order : Base
    {
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; } // Typ generyczny <T>
    }

    public class OrderDetail : Base
    {
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Item Item { get; set; }
    }

    public abstract class Item : Base  // abstract - klasa jest abstracyjna i nie można utworzyć jej obiektu za pomocą new()
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class Product : Item     // klasa Product dziedziczy po klasie bazowej Item
    {
        public string Color { get; set; }
        public float Weight { get; set; }
    }

    public class Service : Item     // klasa Service dziedziczy po klasie bazowej Item
    {
        public TimeSpan Duration { get; set; }
    }


    // W C# nie ma wielodziedziczenia!
    //public class ProductService : Product, Service
    //{

    //}
}
