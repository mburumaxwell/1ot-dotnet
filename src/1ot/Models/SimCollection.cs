using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mobi1ot.Models;

/// <summary>
/// Represents a collection of <see cref="Sim"/> objects
/// </summary>
public class SimCollection : CollectionBase
{
    /// <summary>
    /// The <see cref="Sim"/> objects
    /// </summary>
    [JsonPropertyName("sims")]
    public List<Sim> Sims { get; set; }
}
