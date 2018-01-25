namespace SpeedLimitFollowup.Core.Models {
    using System;
    using System.Text;
    using SpeedLimitFollowup.Core.Enums;
    using SpeedLimitFollowup.Core.Helpers;

    /// <summary>
    /// Displays information about the citation.
    /// </summary>
    public class Citation {
        /// <summary>
        /// Gets or sets the officer's rank.
        /// </summary>
        public string OfficerRank { get; set; }

        /// <summary>
        /// Gets or sets the officer's first.
        /// </summary>
        public string OfficerFirstName { get; set; }
        
        /// <summary>
        /// Gets or sets the officer's last name.
        /// </summary>
        public string OfficerLastName { get; set; }
        
        /// <summary>
        /// Gets or sets the officer's badge number.
        /// </summary>
        public int OfficerBadgeId { get; set; }

        /// <summary>
        /// Gets or sets the Driver's first name.
        /// </summary>
        public string DriverFirstName { get; set; }

        /// <summary>
        /// Gets or sets the Driver's last name.
        /// </summary>
        public string DriverLastName { get; set; }

        /// <summary>
        /// Gets or sets the Driver's date of birth.
        /// </summary>
        public DateTime DriverDateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the Driver's address.
        /// </summary>
        public string DriverAddressOne { get; set; }

        /// <summary>
        /// Gets or sets the Driver's address (continued).
        /// </summary>
        public string DriverAddressTwo { get; set; }

        /// <summary>
        /// Gets or sets the Driver's city.
        /// </summary>
        public string DriverCity { get; set; }

        /// <summary>
        /// Gets or sets the Driver's state.
        /// </summary>
        public string DriverState { get; set; }

        /// <summary>
        /// Gets or sets the Driver's zip.
        /// </summary>
        public string DriverZip { get; set; }

        /// <summary>
        /// Gets or sets the reason for the driver being pulled over. (headlight out, suspicious activity, etc.)
        /// </summary>
        public ViolationReason CurrentViolationReason { get; set; }

        /// <summary>
        /// Gets or sets the type of citation. (moving, non-moving)
        /// </summary>
        public CitationType CurrentCitationType { get; set; }

        /// <summary>
        /// Gets or sets the disposition of the citation. (warning, ticket)
        /// </summary>
        public ViolationType CurrentViolationType { get; set; }

        /// <summary>
        /// Gets or sets the comments of the officer if any.
        /// </summary>
        public string OfficerComments { get; set; }


        /// <summary>
        /// Override to the string method to display the citation in a pretty mannor.
        /// </summary>
        /// <returns>Stylized string of the citation.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("====================================== Citation " + LocalRandom.GetRandomNumber(0, 10000).ToString() + "  =======================================\r\n");
            sb.AppendLine();
            sb.AppendFormat("Officer: {0} {1} {2} ({3})\r\n", OfficerRank, OfficerFirstName, OfficerLastName, OfficerBadgeId.ToString());
            sb.AppendLine("============================================================================================\r\n");
            sb.AppendFormat("Driver: {0} {1}\r\n", DriverFirstName, DriverLastName);
            sb.AppendFormat("DOB: {0}\r\n", DriverDateOfBirth.ToShortDateString());
            sb.AppendFormat("Address: {0}\r\n", DriverAddressOne);

            if (DriverAddressTwo != String.Empty) {
                sb.AppendLine(DriverAddressTwo + "\r\n");
            }

            sb.AppendFormat("City: {0}\tState: {1}\tZip: {2}\r\n", DriverCity, DriverState, DriverZip);
            sb.AppendLine("=============================================================================================");
            
            sb.AppendFormat("Violation Type: {0}\r\n", Enum.GetName(typeof(CitationType), CurrentCitationType));
            sb.AppendFormat("Reason For Stop: {0}\r\n", Enum.GetName(typeof(ViolationReason), CurrentViolationReason));
            sb.AppendFormat("Disposition: {0}\r\n", Enum.GetName(typeof(CitationType), CurrentCitationType));
            sb.AppendFormat("Notes: {0}\r\n", OfficerComments);

            return sb.ToString();
        }
    }
}