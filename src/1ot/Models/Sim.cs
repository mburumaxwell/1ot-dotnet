using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobi1ot.Models
{
    ///
    public class Sim
    {
        ///
        [JsonProperty("iccid")]
        public string ICCID { get; set; }

        ///
        [JsonProperty("group")]
        public string Group { get; set; }

        ///
        [JsonProperty("type")]
        public string Type { get; set; }

        ///
        [JsonProperty("form")]
        public string Form { get; set; }

        ///
        [JsonProperty("data_limit")]
        public int DataLimit { get; set; }

        ///
        [JsonProperty("name")]
        public string Name { get; set; }

        ///
        [JsonProperty("msisdn")]
        public string MSISDN { get; set; }

        ///
        [JsonProperty("imei")]
        public string IMEI { get; set; }

        ///
        [JsonProperty("status")]
        public SimStatus Status { get; set; }

        ///
        [JsonProperty("active_profile")]
        public string ActiveProfile { get; set; }

        ///
        [JsonProperty("downloaded_profiles")]
        public List<string> DownloadedProfiles { get; set; }

        ///
        [JsonProperty("imsi")]
        public string IMSI { get; set; }

        ///
        [JsonProperty("apn")]
        public string APN { get; set; }
    }
}
