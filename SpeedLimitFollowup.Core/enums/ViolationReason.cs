namespace SpeedLimitFollowup.Core.enums {
    /// <summary>
    /// Defines the reason for a ticket/warning.
    /// </summary>
    public enum ViolationReason {
        /// <summary>
        /// Driver was driving to fast.
        /// </summary>
        Speeding = 1,

        /// <summary>
        /// Officer obsered the driver tailgaiting.
        /// </summary>
        Tailgaiting = 2,

        /// <summary>
        /// Officer observed a lane change without the use of an indicator.
        /// </summary>
        ImproperLaneChange = 3,

        /// <summary>
        /// Officer observed the driver driving below the flow of traffic.
        /// </summary>
        DrivingToSlowly = 4,

        /// <summary>
        /// Officer suspects the driver to be impaired.
        /// </summary>
        SuspicionOfImpairment = 5,

        /// <summary>
        /// Equipment failure: Headlight
        /// </summary>
        HeadlightOut = 6,

        /// <summary>
        /// Equipment failure: Taillight
        /// </summary>
        TaillightOut = 7,

        /// <summary>
        /// Equipment failure: License Plate Light
        /// </summary>
        LicensePlateLightOut = 8,

        /// <summary>
        /// Officer observed unusual activity from the driver.
        /// </summary>
        SuspiciousActivity = 9,

        /// <summary>
        /// Officer observed the driver using a cellular device when restricted.
        /// </summary>
        UseOfCellPhone = 10,

        /// <summary>
        /// Officer observed the driver not wearing a seatbealt.
        /// </summary>
        FailureToWearASeatbelt = 11,
    }
}