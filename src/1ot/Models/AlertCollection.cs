using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mobi1ot.Models;

/// <summary>
/// Represents a collection of <see cref="Alert"/> objects
/// </summary>
public class AlertCollection : CollectionBase
{
    /// <summary>
    /// The <see cref="Alert"/> objects
    /// </summary>
    [JsonPropertyName("alerts")]
    public List<Alert>? Sims { get; set; }
}
