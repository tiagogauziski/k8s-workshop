using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class NginxEndpointTest
{
    [Fact]
    public async Task Test_Nginx_Endpoint_Returns_Welcome()
    {
        var endpoint = Environment.GetEnvironmentVariable("TEST_ENDPOINT");
        Assert.False(string.IsNullOrWhiteSpace(endpoint), "TEST_ENDPOINT environment variable must be set.");

        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(endpoint);
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Welcome to nginx!", content);
    }
}
