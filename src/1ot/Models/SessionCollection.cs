using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mobi1ot.Models;

/// <summary>
/// Represents a collection of <see cref="Session"/> objects
/// </summary>
public class SessionCollection : CollectionBase
{
    /// <summary>
    /// The starting time for the sessions
    /// </summary>
    [JsonPropertyName("from")]
    public long From { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

    /// <summary>
    /// The ending time for the sessions
    /// </summary>
    [JsonPropertyName("to")]
    public long To { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

    /// <summary>
    /// The <see cref="Session"/> objects
    /// </summary>
    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; }
}
