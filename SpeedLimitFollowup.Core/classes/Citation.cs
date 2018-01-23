namespace SpeedLimitFollowup.Core.classes {
    using System;
    using System.Text;
    using SpeedLimitFollowup.Core.enums;
    using SpeedLimitFollowup.Core.extentions;

    /// <summary>
    /// Displays information about the citation.
    /// </summary>
    public class Citation {
        /// <summary>
        /// Gets or sets the officer writing the citation.
        /// </summary>
        public Officer CitingOfficer { get; set; }

        /// <summary>
        /// Gets or sets the Driver recieving the citation.
        /// </summary>
        public Driver CitedDriver { get; set; }

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
            sb.AppendLine("====================================== Citation " + Extentions.GetRandomNumber(0, 10000).ToString() + "  =======================================\r\n");
            sb.AppendLine();
            sb.AppendFormat("Officer: {0} {1} {2} ({3})\r\n", CitingOfficer.Rank, CitingOfficer.FirstName, CitingOfficer.LastName, CitingOfficer.BadgeId.ToString());
            sb.AppendLine("============================================================================================\r\n");
            sb.AppendFormat("Driver: {0} {1}\r\n", CitedDriver.FristName, CitedDriver.LastName);
            sb.AppendFormat("Address: {0}\r\n", CitedDriver.Address1);

            if (CitedDriver.Address2 != String.Empty) {
                sb.AppendLine(CitedDriver.Address2 + "\r\n");
            }

            sb.AppendFormat("City: {0}\tState: {1}\tZip: {2}\r\n", CitedDriver.City, CitedDriver.State, CitedDriver.Zip);
            sb.AppendLine("=============================================================================================");
            sb.AppendFormat("Violation Type: {0}\r\n", Enum.GetName(typeof(CitationType), CurrentCitationType));
            sb.AppendFormat("Reason For Stop: {0}\r\n", Enum.GetName(typeof(ViolationReason), CurrentViolationReason));
            sb.AppendFormat("Disposition: {0}\r\n", Enum.GetName(typeof(CitationType), CurrentCitationType));
            sb.AppendFormat("Notes: {0}\r\n", OfficerComments);

            return sb.ToString();
        }
    }
}