using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    ///
    public class Alert
    {
        ///
        [JsonProperty("id")]
        public string Id { get; set; }

        ///
        [JsonProperty("trigger")]
        public string Trigger { get; set; }

        ///
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

        ///
        [JsonProperty("is_read")]
        public bool Read { get; set; }

        ///
        [JsonProperty("iccid")]
        public string ICCID { get; set; }
    }
}
