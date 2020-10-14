using MF.Rb.Domain.Entity;
using MF.Rb.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MF.Rb.Api.Controllers
{
    [Route("api/{controller}")]
   
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // [Produces("application/json", "application/xml")]   // Zawęża obsługiwane formaty

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<User> users = userRepository.Get();

            return Ok(users);

        }

        // Route
        // GET api/users/{id}

      
        [FormatFilter]      // pobiera z adresu url format i przekazuje go do nagłówka jako Accept
        [HttpGet("{id}.{format?}", Name ="GetUserById")]            
        public ActionResult GetById(int id)
        {
            // Jeśli zasób (resource) nie zostanie odnaleziony
            // to powinien być zwracany status odpowiedzi jako 404NotFound

            User user = userRepository.Get(id);

            if (user==null)
            {
                return NotFound(); // Zwraca 404 NotFound
            }

            return Ok(user);   // Zwraca 200 OK
        }

        // HEAD - sprawdza czy wskazany zasób (np. użytkownik) istnieje

        [HttpHead("{id}")]
        public ActionResult Head(int id)
        {
            User user = userRepository.Get(id);

            if (user == null)
            {

                
                return NotFound(); // Zwraca 404 NotFound
            }

            return Ok();    // Zwraca 200 OK bez zawartości
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)  // User = model
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userRepository.Add(user);

            // Utworzenie odpowiedzi
            // w nagłówku znajdą się:
            // location: api/users/10
            // w treści odpowiedzi: użytkownik w formacie json
            return CreatedAtRoute("GetUserById", new { Id = user.Id }, user);
        }
    }
}
