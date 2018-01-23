using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedLimitFollowup.Core.enums {
    /// <summary>
    /// Defines the disposition of the citation.
    /// </summary>
    public enum CitationType {
        /// <summary>
        /// Driver was given a break.
        /// </summary>
        Warning,

        /// <summary>
        /// Driver was given a ticket.
        /// </summary>
        Ticket
    }
}
