using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    ///
    public abstract class AccountRecordsBase
    {
        ///
        [JsonProperty("found")]
        public int Found { get; set; }

        ///
        [JsonProperty("offset")]
        public int Offset { get; set; }

        ///
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
