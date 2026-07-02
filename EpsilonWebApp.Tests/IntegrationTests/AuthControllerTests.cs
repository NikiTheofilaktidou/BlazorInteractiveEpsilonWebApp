using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EpsilonWebApp.Tests.IntegrationTests;

public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsToken()
    {
        var response = await _client.PostAsJsonAsync("/api/auth/login", new
        {
            UserName = "Niki",
            Password = "12345"
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var token = await response.Content.ReadAsStringAsync();

        Assert.False(string.IsNullOrWhiteSpace(token));
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        var response = await _client.PostAsJsonAsync("/api/auth/login", new
        {
            UserName = "xusername",
            Password = "xpassword"
        });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Logout_Succeeds()
    {
        var response = await _client.PostAsJsonAsync("/api/auth/logout", new { });

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}