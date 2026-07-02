using System.Net.Http.Json;

namespace EpsilonWebApp.Client.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly TokenService _tokenService;

    public AuthService(HttpClient httpClient, TokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task LoginAsync(string userName, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", new
        {
            UserName = userName,
            Password = password
        });

        response.EnsureSuccessStatusCode();

        var jwt = await response.Content.ReadAsStringAsync();

        jwt = jwt.Trim('"');

        _tokenService.SetToken(jwt);
    }

    public async Task LogoutAsync()
    {
        await _httpClient.PostAsJsonAsync("api/auth/logout", new { });

        _tokenService.ClearToken();
    }
}