using System.Text.Json.Serialization;

namespace Mobi1ot;

/// <summary>
/// The detailed error returned from 1ot's API
/// </summary>
public class Mobi1otError
{
    /// <summary>
    /// The unique code identifying the type of error.
    /// </summary>
    [JsonPropertyName("error_code")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// The description of the error.
    /// </summary>
    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }

    /// <summary>
    /// The time the error happened
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset
}
