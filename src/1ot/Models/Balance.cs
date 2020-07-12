using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    ///
    public class Balance
    {
        ///
        [JsonProperty("data_used")]
        public long DataUsed { get; set; }

        ///
        [JsonProperty("data_cost")]
        public float DataCost { get; set; }

        ///
        [JsonProperty("currency")]
        public string Currency { get; set; }

        ///
        [JsonProperty("month")]
        public int Month { get; set; }

        ///
        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
