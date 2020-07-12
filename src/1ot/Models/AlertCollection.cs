using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobi1ot.Models
{
    ///
    public class AlertCollection : AccountRecordsBase
    {
        ///
        [JsonProperty("alerts")]
        public List<Alert> Sims { get; set; }
    }
}
