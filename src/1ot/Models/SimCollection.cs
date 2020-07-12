using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobi1ot.Models
{
    ///
    public class SimCollection : AccountRecordsBase
    {
        ///
        [JsonProperty("sims")]
        public List<Sim> Sims { get; set; }
    }
}
