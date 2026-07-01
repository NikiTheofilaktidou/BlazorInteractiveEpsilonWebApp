using EpsilonWebApp.Application.DTOs;

namespace EpsilonWebApp.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(Guid id);

    Task<CustomerDto> AddAsync(CreateCustomerDto customer);

    Task UpdateAsync(Guid id, UpdateCustomerDto customer);

    Task DeleteAsync(Guid id);
}