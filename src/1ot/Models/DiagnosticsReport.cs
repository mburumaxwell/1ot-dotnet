using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents a diagnostics report for a <see cref="Sim"/>
    /// </summary>
    public class DiagnosticsReport
    {
        /// <summary>
        /// The IMEI of the equipment/device that the SIM is connected to
        /// </summary>
        [JsonProperty("imei")]
        public string IMEI { get; set; }

        ///
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }

        ///
        [JsonProperty("inDataSession")]
        public object InDataSession { get; set; }

        /// <summary>
        /// The last time, the device was connected to the network.
        /// </summary>
        [JsonProperty("lastNetworkActivity")]
        public long LastNetworkActivity { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

        /// <summary>
        /// The country in which the SIM was last connected.
        /// </summary>
        [JsonProperty("lastCountry")]
        public string LastCountry { get; set; }

        /// <summary>
        /// The operator through which the SIM was last connected.
        /// </summary>
        [JsonProperty("lastOperator")]
        public string LastOperator { get; set; }

        /// <summary>
        /// The inteprated latitude at which the SIM was last connected.
        /// </summary>
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// The inteprated longitude at which the SIM was last connected.
        /// </summary>
        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// The radius within which the SIM was in during the last connection.
        /// Use this value to mesaure the accuracy of the co-ordinates specified by
        /// <see cref="Latitude"/> and <see cref="Longitude"/>
        /// </summary>
        [JsonProperty("radius")]
        public float Radius { get; set; }
    }
}
