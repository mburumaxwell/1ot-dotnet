using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents a session for data usage by a <see cref="Sim"/>
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The unique identifier of the session
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the country where the session happened
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// The 3-letter code of the country where the session happened
        /// </summary>
        [JsonProperty("alpha3")]
        public string Alpha3 { get; set; }

        /// <summary>
        /// The operator who provided the session.
        /// </summary>
        [JsonProperty("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// The size of data transmitted during the session in bytes
        /// </summary>
        [JsonProperty("data_size")]
        public long DataSize { get; set; }

        /// <summary>
        /// The cost of data transmitted during the session.
        /// The value must be interprated together with <see cref="Currency"/>
        /// </summary>
        [JsonProperty("data_cost")]
        public float DataCost { get; set; }

        /// <summary>
        /// The currency used for <see cref="DataCost"/>
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The starting time for the session
        /// </summary>
        [JsonProperty("start_time")]
        public long StartTime { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset
    }
}
