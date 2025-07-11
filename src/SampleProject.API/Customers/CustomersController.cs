﻿using System.Net;
using System.Threading.Tasks;
using Cortex.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Customers;
using SampleProject.Application.Customers.RegisterCustomer;

namespace SampleProject.API.Customers
{
[Route("api/customers")]
[ApiController]
[Authorize]
public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody]RegisterCustomerRequest request)
        {
           var customer = await _mediator.SendAsync(new RegisterCustomerCommand(request.Email, request.Name));

           return Created(string.Empty, customer);
        }       
    }
}
