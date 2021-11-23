using System.Text.Json.Serialization;

namespace Mobi1ot.Models;

/// <summary>
/// An abstraction for when querying potentially large amounts of data
/// </summary>
public abstract class CollectionBase
{
    /// <summary>
    /// The number of records found
    /// </summary>
    [JsonPropertyName("found")]
    public int Found { get; set; }

    /// <summary>
    /// The offset from which the records begin
    /// </summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>
    /// The total number of records on the server database
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}
