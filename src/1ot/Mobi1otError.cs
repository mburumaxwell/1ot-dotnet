using Newtonsoft.Json;

namespace Mobi1ot
{
    /// <summary>
    /// The detailed error returned from 1ot's API
    /// </summary>
    public class Mobi1otError
    {
        /// 
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        /// 
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        /// 
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
