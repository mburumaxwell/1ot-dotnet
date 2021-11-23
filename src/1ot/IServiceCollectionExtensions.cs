using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Mobi1ot;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="IHttpClientFactory"/> with <see cref="Mobi1otClient"/> and
    /// related services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> in which to register the services.</param>
    /// <param name="configuration">A configuration object with values for a <see cref="Mobi1otClientOptions"/>.</param>
    /// <param name="configureOptions">A delegate that is used to configure a <see cref="Mobi1otClientOptions"/>.</param>
    /// <returns>An <see cref="IHttpClientBuilder" /> that can be used to configure the client.</returns>
    public static IHttpClientBuilder AddMobi1ot(this IServiceCollection services,
                                                IConfiguration? configuration = null,
                                                Action<Mobi1otClientOptions>? configureOptions = null)
    {
        // if we have a configuration, add it
        if (configuration != null)
        {
            services.Configure<Mobi1otClientOptions>(configuration);
        }

        // if we have a configuration action, add it
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }

        services
             .PostConfigure<Mobi1otClientOptions>(options => // TODO: migrate to an implementation of IValidateOptions<T>
             {
                 if (string.IsNullOrWhiteSpace(options.Username))
                 {
                     throw new InvalidOperationException($"'{nameof(options.Username)}' must be specified.");
                 }

                 if (string.IsNullOrWhiteSpace(options.Password))
                 {
                     throw new InvalidOperationException($"'{nameof(options.Password)}' must be specified.");
                 }

                 if (options.BaseUrl == null)
                 {
                     throw new InvalidOperationException($"'{nameof(options.BaseUrl)}' must be specified.");
                 }
             });

        services.TryAddTransient<Mobi1otClient>(resolver => resolver.GetRequiredService<InjectableMobi1otClient>());

        return services.AddHttpClient<InjectableMobi1otClient>();
    }

    /// <summary>
    /// Adds the <see cref="IHttpClientFactory"/> with <see cref="Mobi1otClient"/> and
    /// related services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> in which to register the services.</param>
    /// <param name="configureOptions">A delegate that is used to configure a <see cref="Mobi1otClientOptions"/>.</param>
    /// <returns>An <see cref="IHttpClientBuilder" /> that can be used to configure the client.</returns>
    public static IHttpClientBuilder AddMobi1ot(this IServiceCollection services, Action<Mobi1otClientOptions> configureOptions)
    {
        return services.AddMobi1ot(null, configureOptions);
    }

    /// <summary>
    /// Adds the <see cref="IHttpClientFactory"/> with <see cref="Mobi1otClient"/> and
    /// related services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> in which to register the services.</param>
    /// <param name="configuration">A configuration object with values for a <see cref="Mobi1otClientOptions"/>.</param>
    /// <returns>An <see cref="IHttpClientBuilder" /> that can be used to configure the client.</returns>
    public static IHttpClientBuilder AddMobi1ot(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMobi1ot(configuration, null);
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
