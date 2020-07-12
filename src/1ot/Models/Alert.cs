using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents an alert from a <see cref="Sim"/>
    /// </summary>
    public class Alert
    {
        /// <summary>
        /// The unique identifier of the alert
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The cause of the alert. Also referred to as the trigger.
        /// </summary>
        [JsonProperty("trigger")]
        public string Trigger { get; set; }

        /// <summary>
        /// The time which the alert was triggered
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

        /// <summary>
        /// An indication of whether the alert has been read
        /// </summary>
        [JsonProperty("is_read")]
        public bool Read { get; set; }

        /// <summary>
        /// The unique identifier of the SIM
        /// </summary>
        [JsonProperty("iccid")]
        public string ICCID { get; set; }
    }
}
