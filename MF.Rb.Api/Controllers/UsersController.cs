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

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<User> users = userRepository.Get();

            return Ok(users);

        }
    }
}
