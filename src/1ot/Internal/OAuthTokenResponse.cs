using Newtonsoft.Json;

namespace Mobi1ot.Internal
{
    /// <summary>
    /// Represents a response from an OAuth request
    /// </summary>
    internal class OAuthTokenResponse
    {
        /// <summary>
        /// The access token
        /// </summary>
        [JsonProperty("access_token")]
        public virtual string AccessToken { get; set; }

        /// <summary>
        /// The refresh token
        /// </summary>
        [JsonProperty("refresh_token")]
        public virtual string RefreshToken { get; set; }

        /// <summary>
        /// The duration of the token from now in seconds
        /// </summary>
        [JsonProperty("expires_in")]
        public virtual long ExpiresIn { get; set; }
    }
}
