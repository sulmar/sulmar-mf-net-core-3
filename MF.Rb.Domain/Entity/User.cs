using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace MF.Rb.Domain.Entity
{
    public class User : Base
    {
        // snippet: prop + 2 x Tab  - utworzenie właściwości z get set (property)

        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwisko powinno mieć od 3 do 50 znaków")]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }


        // Adnotacje 
        // CTRL+.
        // Należy zainstalować pakiet System.ComponentModel.DataAnnotations
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        // Bardziej skomplikowane reguły możemy definiować za pomocą wyrażeń regularnych (Regular Expression)
        // Na przykład walidacja kodu pocztowego: 00-000
        // możemy uzyskać za pomocą maski: ^\d{2}-\d{3}$
        // Strona do testowania wyrażeń regularnych: https://regex101.com/

        [RegularExpression(@"^\d{2}-\d{3}$")]
        public string PostCode { get; set; }

        public User()
        {

        }
        
        public User(int id, string firstName, string lastName, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;

        }
    }
}
