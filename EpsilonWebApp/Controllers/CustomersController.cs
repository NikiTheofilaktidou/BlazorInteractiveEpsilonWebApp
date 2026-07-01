using EpsilonWebApp.Application.DTOs;
using EpsilonWebApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EpsilonWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetById(Guid id)
    {
        var customer = await _customerService.GetByIdAsync(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create(CreateCustomerDto customer)
    {
        var createdCustomer = await _customerService.AddAsync(customer);

        return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateCustomerDto customer)
    {
        await _customerService.UpdateAsync(id, customer);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _customerService.DeleteAsync(id);

        return NoContent();
    }
}