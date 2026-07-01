using EpsilonWebApp.Application.Interfaces;
using EpsilonWebApp.Domain.Entities;
using EpsilonWebApp.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EpsilonWebApp.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }

    public Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer is not null)
        {
            _context.Customers.Remove(customer);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}