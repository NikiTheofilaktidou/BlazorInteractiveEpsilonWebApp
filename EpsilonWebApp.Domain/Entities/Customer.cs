using System.ComponentModel.DataAnnotations;

namespace EpsilonWebApp.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string ContactName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string? City { get; set; }

        public string? Region { get; set; }

        [MinLength(5)]
        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        [Required]
        [MinLength(10)]
        public string Phone { get; set; } = string.Empty;
    }
}