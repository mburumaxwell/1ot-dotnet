using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents the balance of an account
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// The amount of data consumed in bytes
        /// </summary>
        [JsonProperty("data_used")]
        public long DataUsed { get; set; }

        /// <summary>
        /// The cost billed for the data used.
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
        /// The month in which this balance exists.
        /// </summary>
        [JsonProperty("month")]
        public int Month { get; set; }

        /// <summary>
        /// The year in which this balance exists.
        /// </summary>
        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
