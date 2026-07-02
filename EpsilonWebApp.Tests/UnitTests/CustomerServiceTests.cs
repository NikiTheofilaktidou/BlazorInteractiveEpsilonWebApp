using EpsilonWebApp.Application.DTOs;
using EpsilonWebApp.Application.Interfaces;
using EpsilonWebApp.Application.Services;
using EpsilonWebApp.Domain.Entities;

namespace EpsilonWebApp.Tests.UnitTests;

public class CustomerServiceTests
{
    private class FakeCustomerRepository : ICustomerRepository
    {
        public List<Customer> Customers { get; } = [];
        public bool SaveChangesSucceeds{ get; private set; }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.FromResult(Customers.AsEnumerable());
        }

        public Task<Customer?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Customers.FirstOrDefault(c => c.Id == id));
        }

        public Task AddAsync(Customer customer)
        {
            Customers.Add(customer);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Customer customer)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var customer = Customers.FirstOrDefault(c => c.Id == id);

            if (customer is not null)
                Customers.Remove(customer);

            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            SaveChangesSucceeds = true;
            return Task.CompletedTask;
        }
    }

    [Fact]
    public async Task AddAsync_CreatesCustomer()
    {
        var repository = new FakeCustomerRepository();
        var service = new CustomerService(repository);

        var customer = new CreateCustomerDto
        {
            CompanyName = "Some Company",
            ContactName = "Some Contact",
            Address = "Some Address",
            PostalCode = "12345",
            Phone = "2101234567"
        };

        var result = await service.AddAsync(customer);

        Assert.Single(repository.Customers);
        Assert.True(repository.SaveChangesSucceeds);
        Assert.Equal("Some Company", result.CompanyName);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsCustomer()
    {
        var id = Guid.NewGuid();
        var repository = new FakeCustomerRepository();

        repository.Customers.Add(new Customer
        {
            Id = id,
            CompanyName = "A Company"
        });

        var service = new CustomerService(repository);

        var result = await service.GetByIdAsync(id);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task DeleteAsync_DeletesCustomer()
    {
        var id = Guid.NewGuid();
        var repository = new FakeCustomerRepository();

        repository.Customers.Add(new Customer { Id = id });

        var service = new CustomerService(repository);

        await service.DeleteAsync(id);

        Assert.Empty(repository.Customers);
        Assert.True(repository.SaveChangesSucceeds);
    }
}