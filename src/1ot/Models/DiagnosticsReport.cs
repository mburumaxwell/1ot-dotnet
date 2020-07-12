using Newtonsoft.Json;

namespace Mobi1ot.Models
{
    ///
    public class DiagnosticsReport
    {
        ///
        [JsonProperty("imei")]
        public string IMEI { get; set; }

        ///
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }

        ///
        [JsonProperty("inDataSession")]
        public object InDataSession { get; set; }

        ///
        [JsonProperty("lastNetworkActivity")]
        public long LastNetworkActivity { get; set; } // TODO: use custom JsonConverter for seconds to DateTimeOffset

        ///
        [JsonProperty("lastCountry")]
        public string LastCountry { get; set; }

        ///
        [JsonProperty("lastOperator")]
        public string LastOperator { get; set; }

        ///
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        ///
        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        ///
        [JsonProperty("radius")]
        public float Radius { get; set; }
    }
}
