namespace SpeedLimitFollowup.Core.classes {
    using System;
    using System.Text;
    using SpeedLimitFollowup.Core.enums;

    public class Citation {
        Officer CitingOfficer { get; set; }
        Driver CitedDriver { get; set; }
        ViolationReason CurrentViolationReason { get; set; }
        CitationType CurrentCitationType { get; set; }
        ViolationType CurrentViolationType { get; set; }
        public string OfficerComments { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("====================================== Citation" + GetRandomNumber(0, 10000).ToString() + "  =======================================");
            sb.AppendLine();
            sb.AppendFormat(string.Format("Officer: {0} {1} {2} ({3})",
                CitingOfficer.Rank, CitingOfficer.FirstName, CitingOfficer.LastName, CitingOfficer.BadgeId.ToString()));
            sb.AppendLine("=========================================================================================");
            sb.AppendLine();
            sb.AppendFormat(string.Format("Driver: {0} {1}", CitedDriver.FristName, CitedDriver.LastName));
            sb.AppendFormat(string.Format("Address: {0}", CitedDriver.Address1));

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

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max) {
            lock (syncLock) { // synchronize
                return getrandom.Next(min, max);
            }
        }
    }


}