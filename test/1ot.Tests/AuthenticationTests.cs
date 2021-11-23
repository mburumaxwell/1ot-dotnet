using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text;
using Xunit;

namespace Mobi1ot.Tests;

public class AuthenticationTests
{
    private const string Json200Response = "{\"access_token\": \"1234567890\",\"refresh_token\": \"0987654321\", \"expires_in\": \"60\"}";

    [Fact]
    public async Task RequestIsSerializedCorrectly()
    {
        const string username = "username";
        const string password = "password";

        var handler = new DynamicHttpMessageHandler((req, ct) =>
        {
            Assert.Equal(HttpMethod.Post, req.Method);

            Assert.Null(req.Headers.Authorization);

            Assert.NotNull(req.Headers.UserAgent);
            var ua = Assert.Single(req.Headers.UserAgent);
            Assert.StartsWith("1ot-dotnet/", ua.ToString());

            Assert.Equal("/v1/oauth/token", req.RequestUri!.AbsolutePath);
            Assert.Equal($"?grant_type=password&client_id={username}&username={username}&password={password}",
                         req.RequestUri.Query);

            Assert.Null(req.Content);
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(Json200Response, Encoding.UTF8, "application/json")
            };
        });

        // Arrange
        var services = new ServiceCollection()
            .AddMobi1ot(username, password)
            .ConfigurePrimaryHttpMessageHandler(() => handler)
            .Services.BuildServiceProvider();

        // Act
        var client = services.GetRequiredService<Mobi1otClient>();
        var response = await client.RequestTokenAsync(default);
        Assert.NotNull(response);
        Assert.Equal("1234567890", response.AccessToken);
        Assert.Equal("0987654321", response.RefreshToken);
        Assert.Equal(60, long.Parse(response.ExpiresIn!));
    }

}
