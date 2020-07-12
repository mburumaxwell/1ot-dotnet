using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    /// <summary>
    /// An abstraction for when querying potentially large amounts of data
    /// </summary>
    public abstract class AccountRecordsBase
    {
        /// <summary>
        /// The number of records found
        /// </summary>
        [JsonProperty("found")]
        public int Found { get; set; }

        /// <summary>
        /// The offset from which the records begin
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// The total number of records on the server database
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
