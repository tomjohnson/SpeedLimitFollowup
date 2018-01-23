namespace SpeedLimitFollowup.Core.Enums {
    /// <summary>
    /// Defines the disposition of the citation.
    /// </summary>
    public enum CitationType {
        /// <summary>
        /// Driver was given a break.
        /// </summary>
        Warning = 1,

        /// <summary>
        /// Driver was given a ticket.
        /// </summary>
        Ticket = 2,

        /// <summary>
        /// Driver was given a big ticket because they were going 16+ MPH over the speed limit.
        /// </summary>
        BigTicket = 3,

        /// <summary>
        /// Driver was given a medium ticket because they were going 11 - 15 MPH over the speed limit.
        /// </summary>
        MediumTicket = 4,

        /// <summary>
        /// Driver was given a small ticket because they were going 5 - 10 MPH over the speed limit.
        /// </summary>
        SmallTicket = 5,
    }
}