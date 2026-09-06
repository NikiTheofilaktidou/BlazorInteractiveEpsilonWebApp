using EpsilonWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpsilonWebApp.Infrastructure.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = new Guid("69eb44c4-7974-4756-ba9b-f94e4290a13f"),
                    CompanyName = "Acme Corporation",
                    ContactName = "John Doe",
                    Address = "123 Main St",
                    City = "Anytown",
                    Region = "CA",
                    PostalCode = "12345",
                    Country = "USA",
                    Phone = "555-123-4567"
                },
                new Customer
                {
                    Id = new Guid("a869edc0-df81-42e1-acbf-af1ef95e235b"),
                    CompanyName = "Globex Corporation",
                    ContactName = "Jane Smith",
                    Address = "456 Elm St",
                    City = "Othertown",
                    Region = "NY",
                    PostalCode = "67890",
                    Country = "USA",
                    Phone = "555-987-6543"
                },
                new Customer
                {
                    Id = new Guid("3c143f46-80ec-4d5d-a067-cd623ccea9fd"),
                    CompanyName = "Initech",
                    ContactName = "Bill Lumbergh",
                    Address = "789 Oak St",
                    City = "Somewhere",
                    Region = "TX",
                    PostalCode = "54321",
                    Country = "USA",
                    Phone = "555-555-5555"
                },
                new Customer
                {
                    Id = new Guid("9a0da791-de71-43a6-bb90-ec3dc9ad3c62"),
                    CompanyName = "Umbrella Corporation",
                    ContactName = "Alice Abernathy",
                    Address = "321 Pine St",
                    City = "Raccoon City",
                    Region = "IL",
                    PostalCode = "98765",
                    Country = "USA",
                    Phone = "555-111-2222"
                },
                new Customer
                {
                    Id = new Guid("7845cc6b-bc07-49cf-8ecb-826b3c04e519"),
                    CompanyName = "Wayne Enterprises",
                    ContactName = "Bruce Wayne",
                    Address = "1007 Mountain Drive",
                    City = "Gotham",
                    Region = "NJ",
                    PostalCode = "07001",
                    Country = "USA",
                    Phone = "555-333-4444"
                },
                new Customer
                {
                    Id = new Guid("49e5a1d7-4eed-4e13-877b-c6055d085d82"),
                    CompanyName = "Stark Industries",
                    ContactName = "Tony Stark",
                    Address = "10880 Malibu Point",
                    City = "Malibu",
                    Region = "CA",
                    PostalCode = "90265",
                    Country = "USA",
                    Phone = "555-666-7777"
                },
                new Customer
                {
                    Id = new Guid("62fda6aa-ba83-45fb-a0d1-cd2ba259ab05"),
                    CompanyName = "Oscorp",
                    ContactName = "Norman Osborn",
                    Address = "20 Ingram Street",
                    City = "New York",
                    Region = "NY",
                    PostalCode = "10001",
                    Country = "USA",
                    Phone = "555-888-9999"
                },
                new Customer
                {
                    Id = new Guid("b6d63e6b-c487-4c77-bfe3-adc71fa9af20"),
                    CompanyName = "Tyrell Corporation",
                    ContactName = "Eldon Tyrell",
                    Address = "1234 Nexus Street",
                    City = "Los Angeles",
                    Region = "CA",
                    PostalCode = "90001",
                    Country = "USA",
                    Phone = "555-000-1111"
                },
                new Customer
                {
                    Id = new Guid("67654f9c-36d5-4acd-9340-5c6f0acf075e"),
                    CompanyName = "Cyberdyne Systems",
                    ContactName = "Miles Dyson",
                    Address = "5678 Skynet Avenue",
                    City = "San Francisco",
                    Region = "CA",
                    PostalCode = "94101",
                    Country = "USA",
                    Phone = "555-222-3333"
                },
                new Customer
                {
                    Id = new Guid("c53ea79d-15d3-444c-bd05-665e56053e4e"),
                    CompanyName = "Wonka Industries",
                    ContactName = "Willy Wonka",
                    Address = "1 Chocolate Factory Lane",
                    City = "Candyland",
                    Region = "CA",
                    PostalCode = "90210",
                    Country = "USA",
                    Phone = "555-444-5555"
                }
            );
        }
    }
}
