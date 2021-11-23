using Microsoft.Extensions.Options;
using Mobi1ot;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>
/// </summary>
public static partial class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="IHttpClientFactory"/> with <see cref="Mobi1otClient"/> and
    /// related services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> in which to register the services.</param>
    /// <param name="configureOptions">A delegate that is used to configure a <see cref="Mobi1otClientOptions"/>.</param>
    /// <returns>An <see cref="IHttpClientBuilder" /> that can be used to configure the client.</returns>
    public static IHttpClientBuilder AddMobi1ot(this IServiceCollection services, Action<Mobi1otClientOptions>? configureOptions = null)
    {
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }

        services.AddSingleton<IValidateOptions<Mobi1otClientOptions>, Mobi1otClientValidateOptions>();
        return services.AddHttpClient<Mobi1otClient>();
    }

    /// <summary>
    /// Adds the <see cref="IHttpClientFactory"/> with <see cref="Mobi1otClient"/> and
    /// related services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> in which to register the services.</param>
    /// <param name="username">
    /// The username for the Mobi1ot account.
    /// This value maps to <see cref="Mobi1otClientOptions.Username"/>
    /// </param>
    /// <param name="password">
    /// The passwrd used to access the Mobi1ot APIs.
    /// This value maps to <see cref="Mobi1otClientOptions.Password"/>
    /// </param>
    /// <returns>An <see cref="IHttpClientBuilder" /> that can be used to configure the client.</returns>
    public static IHttpClientBuilder AddMobi1ot(this IServiceCollection services, string username, string password)
    {
        return services.AddMobi1ot(o =>
        {
            o.Username = username;
            o.Password = password;
        });
    }
}
