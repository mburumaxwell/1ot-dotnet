using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobi1ot.Models
{
    ///
    public class SessionCollection : AccountRecordsBase
    {
        ///
        [JsonProperty("from")]
        public long From { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

        ///
        [JsonProperty("to")]
        public long To { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

        ///
        [JsonProperty("sessions")]
        public List<Session> Sessions { get; set; }
    }
}
