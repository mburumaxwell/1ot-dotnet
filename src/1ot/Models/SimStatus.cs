using System;
using System.Text.Json.Serialization;

namespace Mobi1ot.Models
{
    /// <summary>
    /// The primary state of a <see cref="Sim"/>
    /// </summary>
    public enum SimPrimaryState
    {
        ///
        On,

        ///
        Off,

        ///
        Deleted,

        ///
        Pending
    }

    /// <summary>
    /// The secondary state of a <see cref="Sim"/>
    /// </summary>
    public enum SimSecondaryState
    {
        ///
        Live,

        ///
        Suspended,

        ///
        Test,

        ///
        Off,

        ///
        Deleted
    }

    /// <summary>
    /// The status of a <see cref="Sim"/>
    /// </summary>
    public class SimStatus
    {
        /// <summary>
        /// The primary state of a <see cref="Sim"/>
        /// </summary>
        [JsonPropertyName("primary")]
        public SimPrimaryState Primary { get; set; }

        /// <summary>
        /// The secondary state of a <see cref="Sim"/>
        /// </summary>
        [JsonPropertyName("secondary")]
        public SimSecondaryState? Secondary { get; set; }

        /// <summary>
        /// Gets a representation of the status that is suitable for display/UI purposes.
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            if (Primary == SimPrimaryState.Off) return "SIM is deactivated.";
            else if (Primary == SimPrimaryState.Deleted) return "SIM is permanently disabled and cannot be reactivated.";
            else if (Primary == SimPrimaryState.On)
            {
                switch (Secondary)
                {
                    case SimSecondaryState.Live: return "SIM is active and data service is enabled";
                    case SimSecondaryState.Suspended: return "SIM is active and data service is disabled.";
                    case SimSecondaryState.Test: return "SIM is in test mode.";
                }
            }
            else if (Primary == SimPrimaryState.Pending)
            {
                switch (Secondary)
                {
                    case SimSecondaryState.Off: return "SIM is transitioning to the OFF state.";
                    case SimSecondaryState.Live: return "SIM is transitioning to the LIVE state.";
                    case SimSecondaryState.Test: return "SIM is transitioning to the TEST state.";
                    case SimSecondaryState.Suspended: return "SIM is transitioning to the SUSPENDED state.";
                    case SimSecondaryState.Deleted: return "SIM is transitioning to the DELETED state.";
                }
            }

            throw new NotSupportedException($"Primary={Primary} and Secondary={Secondary} is not supported");
        }
    }
}
