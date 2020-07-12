using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents a SIM card or eSIM
    /// </summary>
    public class Sim
    {
        ///
        [JsonProperty("iccid")]
        public string ICCID { get; set; }

        /// <summary>
        /// The name of the group to which the SIM belongs
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// The type of SIM e.g. <c>UICC</c>
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The form factor of the SIM e.g. 2/3/4FF industrial
        /// </summary>
        [JsonProperty("form")]
        public string Form { get; set; }

        /// <summary>
        /// The limit on data usage in megabytes
        /// </summary>
        [JsonProperty("data_limit")]
        public int DataLimit { get; set; }

        /// <summary>
        /// The name assigned to the SIM
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The subscriber number of the SIM that can be used for SMSs/dialing.
        /// This value can remain the same with differences in <see cref="ICCID"/>.
        /// </summary>
        [JsonProperty("msisdn")]
        public string MSISDN { get; set; }

        /// <summary>
        /// The IMEI of the equipment/device that the SIM is connected to.
        /// </summary>
        [JsonProperty("imei")]
        public string IMEI { get; set; }

        /// <summary>
        /// The status of the SIM card
        /// </summary>
        [JsonProperty("status")]
        public SimStatus Status { get; set; }

        /// <summary>
        /// The profile currencly being used by the sSIM.
        /// This value is only present when using eSIM (<see cref="Type"/> is set to esim)
        /// </summary>
        [JsonProperty("active_profile")]
        public string ActiveProfile { get; set; }

        /// <summary>
        /// The profiles that have been downloaded by the eSIM.
        /// This value is only present when using eSIM (<see cref="Type"/> is set to esim)
        /// </summary>
        [JsonProperty("downloaded_profiles")]
        public List<string> DownloadedProfiles { get; set; }

        /// <summary>
        /// The mobile subscriber number of the SIM. This cannot be used for SMS/dialing.
        /// </summary>
        [JsonProperty("imsi")]
        public string IMSI { get; set; }

        /// <summary>
        /// The apn set for this SIM
        /// </summary>
        [JsonProperty("apn")]
        public string APN { get; set; }
    }
}
