using MF.Rb.Domain;
using MF.Rb.Domain.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MF.Rb.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/{controller}")]
    public class CustomersController : ControllerBase
    {
        // private readonly ICustomerRepository customerRepository;

        //public CustomersController(ICustomerRepository customerRepository)
        //{
        //    this.customerRepository = customerRepository;
        //}

        // GET api/customers

        [HttpGet]
        public IActionResult Get([FromServices] ICustomerRepository customerRepository)
        {
            IEnumerable<Customer> customers = customerRepository.Get();

            return Ok(customers);
        }
    }
}
