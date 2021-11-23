using System.Text.Json.Serialization;

namespace Mobi1ot.Internal;

/// <summary>
/// Represents a response from an OAuth request
/// </summary>
internal class OAuthTokenResponse
{
    /// <summary>
    /// The access token
    /// </summary>
    [JsonPropertyName("access_token")]
    public virtual string? AccessToken { get; init; }

    /// <summary>
    /// The refresh token
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public virtual string? RefreshToken { get; init; }

    /// <summary>
    /// The duration of the token from now in seconds
    /// </summary>
    [JsonPropertyName("expires_in")]
    public virtual string? ExpiresIn { get; init; }
}
