using System.Net.Http.Json;
using EpsilonWebApp.Application.DTOs;

namespace EpsilonWebApp.Client.Services;

public class CustomerApiService
{
    private readonly HttpClient _httpClient;
    private readonly TokenService _tokenService;

    public CustomerApiService(HttpClient httpClient, TokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task<List<CustomerDto>> GetCustomersAsync()
    {
        var customers = await _httpClient.GetFromJsonAsync<List<CustomerDto>>("api/customers");

        return customers ?? [];
    }

    public async Task<CustomerDto?> GetCustomerByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<CustomerDto>($"api/customers/{id}");
    }

    public async Task CreateCustomerAsync(CreateCustomerDto customer)
    {
        await _httpClient.PostAsJsonAsync("api/customers", customer);
    }

    public async Task UpdateCustomerAsync(Guid id, UpdateCustomerDto customer)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _tokenService.Token);
        var response = await _httpClient.PutAsJsonAsync($"api/customers/{id}", customer);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/customers/{id}");
    }
}