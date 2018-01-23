namespace SpeedLimitFollowup.Core.Enums {

    /// <summary>
    /// Defines the type of Violation for a ticket/warning.
    /// </summary>
    public enum ViolationType {
        /// <summary>
        /// A moving violation (speeding, change of lane without indicator, etc.)
        /// </summary>
        Moving = 1,

        /// <summary>
        /// A nonmoving violation (equipment failure, illegal parking, etc.) 
        /// </summary>
        NonMoving = 2,
    }
}