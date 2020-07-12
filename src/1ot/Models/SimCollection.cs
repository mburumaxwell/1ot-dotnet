using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents a collection of <see cref="Sim"/> objects
    /// </summary>
    public class SimCollection : CollectionBase
    {
        /// <summary>
        /// The <see cref="Sim"/> objects
        /// </summary>
        [JsonProperty("sims")]
        public List<Sim> Sims { get; set; }
    }
}
