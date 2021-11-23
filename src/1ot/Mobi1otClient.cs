using Mobi1ot.Internal;
using Mobi1ot.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Mobi1ot;

/// <summary>
/// A client, used to issue requests to 1ot's API and deserialize responses.
/// </summary>
public partial class Mobi1otClient
{
    private static readonly string[] KnownJsonContentTypes = new[] { "application/json", "text/json" };

    private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    private readonly Mobi1otClientOptions options;
    private readonly HttpClient httpClient;
    private readonly SemaphoreSlim tokensLock = new SemaphoreSlim(1, 1);
    private OAuthTokenResponse? tokens = null;
    private DateTimeOffset? tokensExpiry = null;


    /// <summary>
    /// Creates an instance if <see cref="Mobi1otClient"/>
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="options">The options for configuring the client</param>
    public Mobi1otClient(Mobi1otClientOptions options, HttpClient? httpClient = null)
    {
        this.httpClient = httpClient ?? new HttpClient();
        this.options = options ?? throw new ArgumentNullException(nameof(options));

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

        // populate the User-Agent header
        var productVersion = typeof(Mobi1otClient).Assembly.GetName().Version!.ToString();
        var userAgent = new ProductInfoHeaderValue("1ot-dotnet", productVersion);
        this.httpClient.DefaultRequestHeaders.UserAgent.Add(userAgent);
    }

    /// <summary>
    /// Gets a list of all the different SIM groups associated with the account.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Mobi1otResponse<List<string>>> GetAccountGroupsAsync(CancellationToken cancellationToken = default)
    {
        var url = new Uri(options.BaseUrl, "/v1/get_account_groups");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<List<string>>(request, cancellationToken);
    }

    /// <summary>
    /// Gets the <see cref="Balance"/> object associated with the users monthly balance.
    /// </summary>
    /// <param name="month">Month (1-12) of the <see cref="Balance"/> to query</param>
    /// <param name="year">Year of the <see cref="Balance"/> to query</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Parameters <paramref name="month"/> and <paramref name="year"/> can be used to specify a certain month and year.
    /// </remarks>
    public async Task<Mobi1otResponse<Balance>> GetAccountBalanceAsync(int? month = null,
                                                                       int? year = null,
                                                                       CancellationToken cancellationToken = default)
    {
        var args = new Dictionary<string, string>();
        if (month != null) args["month"] = $"{month}";
        if (year != null) args["year"] = $"{year}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_account_balance{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<Balance>(request, cancellationToken);
    }

    /// <summary>
    /// Gets <see cref="Sim"/> objects belonging to the user.
    /// </summary>
    /// <param name="offset">Offset query by n objects</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Retrieves the first 1000 instances found in the database.
    /// Optional <paramref name="offset"/> can be used offset the query by skipping the first n ALERT objects.
    /// </remarks>
    public async Task<Mobi1otResponse<SimCollection>> GetAccountSimsAsync(int? offset = null,
                                                                          CancellationToken cancellationToken = default)
    {
        var args = new Dictionary<string, string>();
        if (offset != null) args["offset"] = $"{offset}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_account_sims{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<SimCollection>(request, cancellationToken);
    }

    /// <summary>
    /// Gets all ALERT objects associated with the user.
    /// </summary>
    /// <param name="unread">Only return unread alerts</param>
    /// <param name="markRead">Mark the returned alerts read after returning</param>
    /// <param name="offset">Offset query by n objects</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Retrieves the first 1000 instances found in the database.
    /// Optional <paramref name="offset"/> can be used offset the query by skipping the first n ALERT objects.
    /// </remarks>
    public async Task<Mobi1otResponse<AlertCollection>> GetAccountAlertsAsync(bool? unread = null,
                                                                              bool? markRead = null,
                                                                              int? offset = null,
                                                                              CancellationToken cancellationToken = default)
    {
        var args = new Dictionary<string, string>();
        if (offset != null) args["offset"] = $"{offset}";
        if (unread != null) args["unread"] = $"{unread}";
        if (markRead != null) args["markRead"] = $"{markRead}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_account_alerts{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<AlertCollection>(request, cancellationToken);
    }

    /// <summary>
    /// Gets a list of the available eSIM profiles for download.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Mobi1otResponse<List<string>>> GetAvailableProfilesAsync(CancellationToken cancellationToken = default)
    {
        var url = new Uri(options.BaseUrl, "/v1/get_available_profiles");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<List<string>>(request, cancellationToken);
    }

    /// <summary>
    /// Gets <see cref="Sim"/> objects in the specified group.
    /// </summary>
    /// <param name="group">Name of the group</param>
    /// <param name="offset">Offset query by n objects</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Retrieves the first 1000 instances found in the database.
    /// Optional <paramref name="offset"/> can be used offset the query by skipping the first n <see cref="Sim"/> objects.
    /// </remarks>
    public async Task<Mobi1otResponse<SimCollection>> GetGroupSimsAsync(string group,
                                                                        int? offset,
                                                                        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(group)) throw new ArgumentNullException(nameof(group));

        var args = new Dictionary<string, string>
        {
            ["group"] = group
        };
        if (offset != null) args["offset"] = $"{offset}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_group_sims{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<SimCollection>(request, cancellationToken);
    }

    /// <summary>
    /// Gets all ALERT objects associated with the SIMs in the specified group.
    /// </summary>
    /// <param name="group">Name of the group</param>
    /// <param name="unread">Only return unread alerts</param>
    /// <param name="markRead">Mark the returned alerts read after returning</param>
    /// <param name="offset">Offset query by n objects</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Retrieves the first 1000 instances found in the database.
    /// Optional <paramref name="offset"/> can be used offset the query by skipping the first n ALERT objects.
    /// </remarks>
    public async Task<Mobi1otResponse<AlertCollection>> GetGroupAlertsAsync(string group,
                                                                            bool? unread = null,
                                                                            bool? markRead = null,
                                                                            int? offset = null,
                                                                            CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(group)) throw new ArgumentNullException(nameof(group));

        var args = new Dictionary<string, string>
        {
            ["group"] = group
        };
        if (offset != null) args["offset"] = $"{offset}";
        if (unread != null) args["unread"] = $"{unread}";
        if (markRead != null) args["markRead"] = $"{markRead}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_group_alerts{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<AlertCollection>(request, cancellationToken);
    }

    #region Helpers

    private async Task<Mobi1otResponse<T>> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        // ensure request is not null
        if (request == null) throw new ArgumentNullException(nameof(request));

        // setup authentication
        await AuthenticateAsync(request);

        // execute the request
        var response = await httpClient.SendAsync(request, cancellationToken);

        // extract the response
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var resource = default(T);
            var error = default(Mobi1otError);

            // get the content type
            var contentType = response.Content.Headers?.ContentType;

            // get the encoding and always default to UTF-8
            var encoding = Encoding.GetEncoding(contentType?.CharSet ?? Encoding.UTF8.BodyName);

            // Only deserialize if the content type matched JSON. There are numerous situations where
            // the API documentation indicates that the response is application/json but instead
            // provides text/plain and the body is just "OK".
            if (!string.IsNullOrWhiteSpace(contentType?.MediaType) && KnownJsonContentTypes.Contains(contentType?.MediaType))
            {
                if (response.IsSuccessStatusCode)
                {
                    resource = await JsonSerializer.DeserializeAsync<T>(stream, serializerOptions, cancellationToken);
                }
                else
                {
                    error = await JsonSerializer.DeserializeAsync<Mobi1otError>(stream, serializerOptions, cancellationToken);
                }
            }

            return new Mobi1otResponse<T>
            {
                StatusCode = response.StatusCode,
                IsSuccessful = response.IsSuccessStatusCode,
                Error = error,
                Resource = resource,
            };
        }
    }

    internal async Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        await tokensLock.WaitAsync(cancellationToken);
        try
        {
            // if we do not have a valid token, get one
            if (tokens == null || string.IsNullOrWhiteSpace(tokens.AccessToken) || tokensExpiry < DateTimeOffset.UtcNow)
            {
                tokens = await RequestTokenAsync(cancellationToken);
                // bring the expiry time 5 seconds earlier to allow time for renewal
                tokensExpiry = DateTimeOffset.UtcNow.AddSeconds(long.Parse(tokens.ExpiresIn!)) - TimeSpan.FromSeconds(5);
            }

            // at this point, we should have a valid token, so set the header
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
        }
        finally
        {
            tokensLock.Release();
        }
    }

    internal async Task<OAuthTokenResponse> RequestTokenAsync(CancellationToken cancellationToken = default)
    {
        var query = $"?grant_type=password&client_id={options.Username}&username={options.Username}&password={options.Password}";
        var url = new Uri(options.BaseUrl, $"/v1/oauth/token{query}");
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        return (await JsonSerializer.DeserializeAsync<OAuthTokenResponse>(stream, serializerOptions, cancellationToken))!;
    }

    #endregion
}
