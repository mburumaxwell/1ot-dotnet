using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents a collection of <see cref="Alert"/> objects
    /// </summary>
    public class AlertCollection : AccountRecordsBase
    {
        /// <summary>
        /// The <see cref="Alert"/> objects
        /// </summary>
        [JsonProperty("alerts")]
        public List<Alert> Sims { get; set; }
    }
}
