﻿using Newtonsoft.Json;
using System;

namespace Mobi1ot.Models
{
    ///
    public class SimStatus
    {
        ///
        [JsonProperty("primary")]
        public SimPrimaryState Primary { get; set; }

        ///
        [JsonProperty("secondary")]
        public SimSecondaryState? Secondary { get; set; }

        ///
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
                    case SimSecondaryState.Deleted:return "SIM is transitioning to the DELETED state.";
                }
            }

            throw new NotSupportedException($"Primary={Primary} and Secondary={Secondary} is not supported");
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum SimPrimaryState
    {
        On,
        Off,
        Deleted,
        Pending
    }

    public enum SimSecondaryState
    {
        Live,
        Suspended,
        Test,
        Off,
        Deleted
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
