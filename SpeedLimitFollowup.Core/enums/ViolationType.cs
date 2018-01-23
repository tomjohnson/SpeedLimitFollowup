namespace SpeedLimitFollowup.Core.enums {

    /// <summary>
    /// Defines the type of Violation for a ticket/warning.
    /// </summary>
    public enum ViolationType {
        /// <summary>
        /// A moving violation (speeding, change of lane without indicator, etc.)
        /// </summary>
        Moving,

        /// <summary>
        /// A nonmoving violation (equipment failure, illegal parking, etc.) 
        /// </summary>
        NonMoving,
    }
}