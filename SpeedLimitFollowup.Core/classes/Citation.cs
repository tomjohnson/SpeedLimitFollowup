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
            sb.AppendLine("====================================== Citation" + Extentions.GetRandomNumber(0, 10000).ToString() + "  =======================================");
            sb.AppendLine();
            sb.AppendFormat("Officer: {0} {1} {2} ({3})", CitingOfficer.Rank, CitingOfficer.FirstName, CitingOfficer.LastName, CitingOfficer.BadgeId.ToString());
            sb.AppendLine("=========================================================================================");
            sb.AppendLine();
            sb.AppendFormat("Driver: {0} {1}", CitedDriver.FristName, CitedDriver.LastName);
            sb.AppendFormat("Address: {0}", CitedDriver.Address1);

            if (CitedDriver.Address2 != String.Empty) {
                sb.AppendLine(CitedDriver.Address2);
            }

            sb.AppendFormat("City: {0}\t\tState{1}\t\tZip{2}", CitedDriver.City, CitedDriver.State, CitedDriver.Zip);
            sb.AppendLine("=========================================================================================");
            sb.AppendFormat("Violation Type: {0}", Enum.GetName(typeof(CitationType), CurrentCitationType));
            sb.AppendFormat("Reason For Stop: {0}", Enum.GetName(typeof(ViolationReason), CurrentViolationReason));
            sb.AppendFormat("Disposition: {0}", Enum.GetName(typeof(CitationType), CurrentCitationType));
            sb.AppendFormat("Notes: {0}", OfficerComments);

            return sb.ToString();
        }
    }
}