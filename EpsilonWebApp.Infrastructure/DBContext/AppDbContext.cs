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

    }
}
