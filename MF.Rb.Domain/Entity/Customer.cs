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
    }

}
