using System;
using System.Collections.Generic;
using System.Text;

namespace MF.Rb.Domain.Entity
{
    public class User : Base
    {
        // snippet: prop + 2 x Tab

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
