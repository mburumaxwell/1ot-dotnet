using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    ///
    public class Session
    {
        ///
        [JsonProperty("id")]
        public string Id { get; set; }

        ///
        [JsonProperty("country")]
        public string Country { get; set; }

        ///
        [JsonProperty("alpha3")]
        public string Alpha3 { get; set; }

        ///
        [JsonProperty("operator")]
        public string Operator { get; set; }

        ///
        [JsonProperty("data_size")]
        public long DataSize { get; set; }

        ///
        [JsonProperty("data_cost")]
        public float DataCost { get; set; }

        ///
        [JsonProperty("currency")]
        public string Currency { get; set; }

        ///
        [JsonProperty("start_time")]
        public long StartTime { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset
    }
}
