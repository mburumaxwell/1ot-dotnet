using System.Text.Json.Serialization;

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
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the country where the session happened
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The 3-letter code of the country where the session happened
        /// </summary>
        [JsonPropertyName("alpha3")]
        public string Alpha3 { get; set; }

        /// <summary>
        /// The operator who provided the session.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// The size of data transmitted during the session in bytes
        /// </summary>
        [JsonPropertyName("data_size")]
        public long DataSize { get; set; }

        /// <summary>
        /// The cost of data transmitted during the session.
        /// The value must be interprated together with <see cref="Currency"/>
        /// </summary>
        [JsonPropertyName("data_cost")]
        public float DataCost { get; set; }

        /// <summary>
        /// The currency used for <see cref="DataCost"/>
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The starting time for the session
        /// </summary>
        [JsonPropertyName("start_time")]
        public long StartTime { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset
    }
}
