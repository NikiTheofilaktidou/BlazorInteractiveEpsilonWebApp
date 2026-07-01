using EpsilonWebApp.Application.DTOs;
using EpsilonWebApp.Application.Interfaces;
using EpsilonWebApp.Domain.Entities;

namespace EpsilonWebApp.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

        return customers.Select(ToDto);
    }

    public async Task<CustomerDto?> GetByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        return customer is null ? null : ToDto(customer);
    }

    public async Task<CustomerDto> AddAsync(CreateCustomerDto customerDto)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CompanyName = customerDto.CompanyName,
            ContactName = customerDto.ContactName,
            Address = customerDto.Address,
            City = customerDto.City,
            Region = customerDto.Region,
            PostalCode = customerDto.PostalCode,
            Country = customerDto.Country,
            Phone = customerDto.Phone
        };

        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();

        return ToDto(customer);
    }

    public async Task UpdateAsync(Guid id, UpdateCustomerDto customerDto)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer is null)
            return;

        customer.CompanyName = customerDto.CompanyName;
        customer.ContactName = customerDto.ContactName;
        customer.Address = customerDto.Address;
        customer.City = customerDto.City;
        customer.Region = customerDto.Region;
        customer.PostalCode = customerDto.PostalCode;
        customer.Country = customerDto.Country;
        customer.Phone = customerDto.Phone;

        await _customerRepository.UpdateAsync(customer);
        await _customerRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _customerRepository.DeleteAsync(id);
        await _customerRepository.SaveChangesAsync();
    }

    private static CustomerDto ToDto(Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            CompanyName = customer.CompanyName,
            ContactName = customer.ContactName,
            Address = customer.Address,
            City = customer.City,
            Region = customer.Region,
            PostalCode = customer.PostalCode,
            Country = customer.Country,
            Phone = customer.Phone
        };
    }
}