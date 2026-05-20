using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net;
namespace tests;

public class GistApiTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public GistApiTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    [Fact]
    public async Task Get_Gists_For_Octocat_Returns_OK_And_Content()
    {
        var response = await _client.GetAsync("/octocat");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.False(string.IsNullOrWhiteSpace(content));
    }

}
