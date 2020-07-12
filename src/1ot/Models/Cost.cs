using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents a billed/billable cost resulting from usage
    /// </summary>
    public class Cost
    {
        ///
        [JsonProperty("iccid")]
        public string ICCID { get; set; }

        /// <summary>
        /// The plan on which this cost was charged
        /// </summary>
        [JsonProperty("data_plan")]
        public string DataPlan { get; set; }

        /// <summary>
        /// The amount of data used in bytes
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
        /// The month in which this cost was billed.
        /// </summary>
        [JsonProperty("month")]
        public int Month { get; set; }

        /// <summary>
        /// The year in which this cost was billed.
        /// </summary>
        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
