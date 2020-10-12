using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MF.Fundamentals.ConsoleClient
{


    //public class ProductRepository
    //{
    //    private Collection<Product> products;

    //    public Collection<Product> Get()
    //    {
    //        return products;
    //    }

    //    public void Add(Product product)
    //    {
    //        products.Add(product);
    //    }

    //    public Product Get(int id)
    //    {
    //        return products.SingleOrDefault(p => p.Id == id);
    //    }

    //    public void Remove(int id)
    //    {
    //        Product product = Get(id);
    //        products.Remove(product);
    //    }
    //}

    public class EntityRepository<TEntity>
        where TEntity : Base                    // reguła (constraint) - zawężenie zbioru typów
    {
        private Collection<TEntity> entities;

        public Collection<TEntity> Get()
        {
            return entities;
        }

        public void Add(TEntity entity)
        {

            // zła praktyka
            //if (entity.GetType()==typeof(Service))
            //{

            //}

            entities.Add(entity);
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            TEntity entity = Get(id);
            entities.Remove(entity);
        }
    }

    public class ProductRepository : EntityRepository<Product>
    {
    }

    public class ServiceRepository : EntityRepository<Service>
    {
    }

    public class CustomerRepository : EntityRepository<Customer>
    {

    }





    // Klasa generyczna (typ uogólniony), której parametrem jest typ T
    // Szablon (template)
    public class Printer<TItem>
    {
        private TItem lastItem;

        public void Print(TItem item)
        {
            Console.WriteLine($"Printing {item}");

            lastItem = item;
        }
    }

    public class Printer
    {
        // Metoda generyczna
        // Szablon metody, której parametrem jest typ T
        public void Print<TItem>(TItem item)
        {
            Console.WriteLine($"Printing {item}");
        }
    }


    /*
    public class Printer
    {
        private object lastItem;

        public void Print(string content)
        {
            Console.WriteLine($"Printing {content}");

            lastItem = content;
        }

        public void Print(DateTime date)
        {
            Console.WriteLine($"Printing {date}");

            lastItem = date;
        }

        public void Print(Product product)
        {
            Console.WriteLine($"Printing {product}");

            lastItem = product;
        }

        public void Print(Customer customer)
        {
            Console.WriteLine($"Printing {customer}");

            lastItem = customer;
        }

        public void Print(Service service)
        {
            Console.WriteLine($"Printing {service}");

            lastItem = service;
        }
    }

    */

}
