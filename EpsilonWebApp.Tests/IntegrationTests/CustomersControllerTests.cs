using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using EpsilonWebApp.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EpsilonWebApp.Tests.IntegrationTests;

public class CustomersControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CustomersControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCustomers_Succeeds()
    {
        var response = await _client.GetAsync("/api/customers");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateCustomer_Succeeds()
    {
        var customer = new CreateCustomerDto
        {
            CompanyName = "Test Company",
            ContactName = "Test Contact",
            Address = "Test Address",
            City = "Athens",
            Region = "Attiki",
            PostalCode = "12345",
            Country = "Greece",
            Phone = "2101234567"
        };

        var response = await _client.PostAsJsonAsync("/api/customers", customer);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task UpdateCustomer_WithoutJwt_ReturnsUnauthorized()
    {
        var customer = new UpdateCustomerDto
        {
            CompanyName = "Updated Company",
            ContactName = "Updated Contact",
            Address = "Updated Address",
            City = "Athens",
            Region = "Attiki",
            PostalCode = "12345",
            Country = "Greece",
            Phone = "2107654321"
        };

        var response = await _client.PutAsJsonAsync($"/api/customers/{Guid.NewGuid()}", customer);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task UpdateCustomer_WithJwt_Succeeds()
    {
        var createdCustomer = await CreateCustomerAsync();
        var token = await LoginAndGetTokenAsync();

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var updateCustomer = new UpdateCustomerDto
        {
            CompanyName = "Updated Test Company",
            ContactName = "Updated Contact",
            Address = "Updated Address",
            City = "Athens",
            Region = "Attiki",
            PostalCode = "54321",
            Country = "Greece",
            Phone = "2107654321"
        };

        var response = await _client.PutAsJsonAsync($"/api/customers/{createdCustomer.Id}", updateCustomer);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task DeleteCustomer_Succeeds()
    {
        var createdCustomer = await CreateCustomerAsync();

        var response = await _client.DeleteAsync($"/api/customers/{createdCustomer.Id}");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    private async Task<CustomerDto> CreateCustomerAsync()
    {
        var customer = new CreateCustomerDto
        {
            CompanyName = "Helper Company",
            ContactName = "Helper Contact",
            Address = "Helper Address",
            City = "Athens",
            Region = "Attiki",
            PostalCode = "12345",
            Country = "Greece",
            Phone = "2101234567"
        };

        var response = await _client.PostAsJsonAsync("/api/customers", customer);

        response.EnsureSuccessStatusCode();

        var createdCustomer = await response.Content.ReadFromJsonAsync<CustomerDto>();

        return createdCustomer!;
    }

    private async Task<string> LoginAndGetTokenAsync()
    {
        var response = await _client.PostAsJsonAsync("/api/auth/login", new
        {
            UserName = "Niki",
            Password = "12345"
        });

        response.EnsureSuccessStatusCode();

        var token = await response.Content.ReadAsStringAsync();

        return token.Trim('"');
    }
}