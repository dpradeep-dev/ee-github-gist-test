using System.Net.Http.Headers;
using System.Text.Json;
using Api.Models;
using Microsoft.Extensions.Caching.Memory;
namespace Api.Services;

public class GitHubService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;

    public GitHubService(HttpClient httpClient, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
        _httpClient.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue("GistApp", "1.0"));
    }

    public async Task<List<Gist>> GetPublicGists(string username)
    {
        return await _cache.GetOrCreateAsync(username, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            var response = await _httpClient.GetAsync(
                $"https://api.github.com/users/{username}/gists");

            if (!response.IsSuccessStatusCode)
                return new List<Gist>();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Gist>>(content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<Gist>();
        }) ?? new List<Gist>();
    }
}
