using System.Text.Json.Serialization;

namespace Mobi1ot.Models
{
    /// <summary>
    /// Represents the result of a request to send a mesage
    /// </summary>
    public class MessageSendResult
    {
        /// <summary>
        /// The response of the 1ot terminal
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
