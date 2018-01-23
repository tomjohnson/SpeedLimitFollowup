using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedLimitFollowup.Core.enums {
    /// <summary>
    /// Defines the reason for a ticket/warning.
    /// </summary>
    public enum ViolationReason {
        /// <summary>
        /// Driver was driving to fast.
        /// </summary>
        Speeding,
        /// <summary>
        /// Equipment failure: Headlight
        /// </summary>
        HeadlightOut,
        /// <summary>
        /// Equipment failure: Taillight
        /// </summary>
        TaillightOut,
        /// <summary>
        /// Equipment failure: License Plate Light
        /// </summary>
        LicensePlateLightOut,
        /// <summary>
        /// Officer observed unusual activity from the driver.
        /// </summary>
        SuspiciousActivity,
        /// <summary>
        /// Officer observed the driver using a cellular device when restricted.
        /// </summary>
        UseOfCellPhone,
        /// <summary>
        /// Officer obsered the driver tailgaiting.
        /// </summary>
        Tailgaiting,
        /// <summary>
        /// Officer observed a lane change without the use of an indicator.
        /// </summary>
        ImproperLaneChange,
        /// <summary>
        /// Officer observed the driver driving below the flow of traffic.
        /// </summary>
        DrivingToSlowly,
        /// <summary>
        /// Officer suspects the driver to be impaired.
        /// </summary>
        SuspicionOfImpairment,
        /// <summary>
        /// Officer observed the driver not wearing a seatbealt.
        /// </summary>
        FailureToWearASeatbelt,
    }
}
