using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EpsilonWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "CompanyName", "ContactName", "Country", "Phone", "PostalCode", "Region" },
                values: new object[,]
                {
                    { new Guid("3c143f46-80ec-4d5d-a067-cd623ccea9fd"), "789 Oak St", "Somewhere", "Initech", "Bill Lumbergh", "USA", "555-555-5555", "54321", "TX" },
                    { new Guid("49e5a1d7-4eed-4e13-877b-c6055d085d82"), "10880 Malibu Point", "Malibu", "Stark Industries", "Tony Stark", "USA", "555-666-7777", "90265", "CA" },
                    { new Guid("62fda6aa-ba83-45fb-a0d1-cd2ba259ab05"), "20 Ingram Street", "New York", "Oscorp", "Norman Osborn", "USA", "555-888-9999", "10001", "NY" },
                    { new Guid("67654f9c-36d5-4acd-9340-5c6f0acf075e"), "5678 Skynet Avenue", "San Francisco", "Cyberdyne Systems", "Miles Dyson", "USA", "555-222-3333", "94101", "CA" },
                    { new Guid("69eb44c4-7974-4756-ba9b-f94e4290a13f"), "123 Main St", "Anytown", "Acme Corporation", "John Doe", "USA", "555-123-4567", "12345", "CA" },
                    { new Guid("7845cc6b-bc07-49cf-8ecb-826b3c04e519"), "1007 Mountain Drive", "Gotham", "Wayne Enterprises", "Bruce Wayne", "USA", "555-333-4444", "07001", "NJ" },
                    { new Guid("9a0da791-de71-43a6-bb90-ec3dc9ad3c62"), "321 Pine St", "Raccoon City", "Umbrella Corporation", "Alice Abernathy", "USA", "555-111-2222", "98765", "IL" },
                    { new Guid("a869edc0-df81-42e1-acbf-af1ef95e235b"), "456 Elm St", "Othertown", "Globex Corporation", "Jane Smith", "USA", "555-987-6543", "67890", "NY" },
                    { new Guid("b6d63e6b-c487-4c77-bfe3-adc71fa9af20"), "1234 Nexus Street", "Los Angeles", "Tyrell Corporation", "Eldon Tyrell", "USA", "555-000-1111", "90001", "CA" },
                    { new Guid("c53ea79d-15d3-444c-bd05-665e56053e4e"), "1 Chocolate Factory Lane", "Candyland", "Wonka Industries", "Willy Wonka", "USA", "555-444-5555", "90210", "CA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
