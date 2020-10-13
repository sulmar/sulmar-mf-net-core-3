using System;

namespace MF.Rb.Domain
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Regon { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }     // Nullable typ? - Nullable<T>


        private Customer()
        {
            ActiveFrom = DateTime.Parse("2020-10-12");
        }

        public Customer(int id, string name, string shortName, string regon)
            : this()
        {
            this.Id = id;
            this.Name = name;
            this.ShortName = shortName;
            this.Regon = regon;
        }
    }

}
