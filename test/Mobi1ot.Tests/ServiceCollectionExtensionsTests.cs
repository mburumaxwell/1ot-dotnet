using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using Xunit;

namespace Mobi1ot.Tests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void TestAddMobi1otWithoutApiKey()
    {
        // Arrange
        var services = new ServiceCollection().AddMobi1ot(options => { }).Services.BuildServiceProvider();

        // Act && Assert
        Assert.Throws<ArgumentNullException>(() => services.GetRequiredService<Mobi1otClient>());
    }

    [Fact]
    public void TestAddMobi1otReturnHttpClientBuilder()
    {
        // Arrange
        var collection = new ServiceCollection();

        // Act
        var builder = collection.AddMobi1ot(options =>
        {
            options.Username = "FAKE_USERNAME";
            options.Password = "FAKE_PASSWORD";
        });

        // Assert
        Assert.NotNull(builder);
        Assert.IsAssignableFrom<IHttpClientBuilder>(builder);
    }

    [Fact]
    public void TestAddMobi1otRegisteredWithTransientLifeTime()
    {
        // Arrange
        var collection = new ServiceCollection();

        // Act
        var builder = collection.AddMobi1ot(options =>
        {
            options.Username = "FAKE_USERNAME";
            options.Password = "FAKE_PASSWORD";
        });

        // Assert
        var serviceDescriptor = collection.FirstOrDefault(x => x.ServiceType == typeof(Mobi1otClient));
        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Transient, serviceDescriptor!.Lifetime);
    }

    [Fact]
    public void TestAddMobi1otCanResolveMobi1otClientOptions()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddMobi1ot(options =>
            {
                options.Username = "FAKE_USERNAME";
                options.Password = "FAKE_PASSWORD";
            }).Services.BuildServiceProvider();

        // Act
        var Mobi1otClientOptions = services.GetService<IOptions<Mobi1otClientOptions>>();

        // Assert
        Assert.NotNull(Mobi1otClientOptions);
    }

    [Fact]
    public void TestAddMobi1otCanResolveMobi1otClient()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddMobi1ot(options =>
            {
                options.Username = "FAKE_USERNAME";
                options.Password = "FAKE_PASSWORD";
            })
            .Services.BuildServiceProvider();

        // Act
        var Mobi1ot = services.GetService<Mobi1otClient>();

        // Assert
        Assert.NotNull(Mobi1ot);
    }
}
