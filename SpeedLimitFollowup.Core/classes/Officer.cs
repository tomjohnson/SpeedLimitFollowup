namespace SpeedLimitFollowup.Core.classes {
    using SpeedLimitFollowup.Core.enums;
    using SpeedLimitFollowup.Core.extentions;
    using System;

    /// <summary>
    /// Displays information about the driver.
    /// </summary>
    public class Officer {

        /// <summary>
        /// Gets or sets the first name of the officer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the officer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the rank of the officer.
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets the badge id of the officer.
        /// </summary>
        public int BadgeId { get; set; }

        /// <summary>
        /// Gets the mood of the officer (1 = nice, mean = 10)/
        /// </summary>
        public int Mood {
            get {
                return Extentions.GetRandomNumber(1, 10);
            }
        }

        /// <summary>
        /// Gets or sets the current speed limit for the area.
        /// </summary>
        public int CurrentSpeedLimit {
            get {
                return Extentions.GetRandomNumber(25, 75);
            }
        }

        /// <summary>
        /// Gets or sets the reason the officer pulled the driver over.
        /// </summary>
        public ViolationReason reason {
            get {
                var reasonNumber = Extentions.GetRandomNumber(1, 11);
                return (ViolationReason)reasonNumber;
            }
        }

        /// <summary>
        ///  Gets or sets the comment number for use on the citation.
        /// </summary>
        private int CommentNumber {
            get {
                return Extentions.GetRandomNumber(1, 20);
            }
        }

        /// <summary>
        /// Returns the specified comment, 1-15 return a comment, otherwise N/A.
        /// </summary>
        public string NegativeComment {
            get {
                switch (this.CommentNumber) {
                    case 1:
                        return "N/A";
                    case 2:
                        return "N/A";
                    case 3:
                        return "N/A";
                    case 4:
                        return "N/A";
                    case 5:
                        return "N/A";
                    case 6:
                        return "N/A";
                    case 7:
                        return "N/A";
                    case 8:
                        return "N/A";
                    case 9:
                        return "N/A";
                    case 10:
                        return "N/A";
                    case 11:
                        return "N/A";
                    case 12:
                        return "N/A";
                    case 13:
                        return "N/A";
                    case 14:
                        return "N/A";
                    case 15:
                        return "N/A";
                    default:
                        return "N/A";
                }
            }
        }

        /// <summary>
        /// Returns the specified comment, 1-15 return a comment, otherwise N/A.
        /// </summary>
        public string PositiveComment {
            get {
                switch (this.CommentNumber) {
                    case 1:
                        return "N/A";
                    case 2:
                        return "N/A";
                    case 3:
                        return "N/A";
                    case 4:
                        return "N/A";
                    case 5:
                        return "N/A";
                    case 6:
                        return "N/A";
                    case 7:
                        return "N/A";
                    case 8:
                        return "N/A";
                    case 9:
                        return "N/A";
                    case 10:
                        return "N/A";
                    case 11:
                        return "N/A";
                    case 12:
                        return "N/A";
                    case 13:
                        return "N/A";
                    case 14:
                        return "N/A";
                    case 15:
                        return "N/A";
                    default:
                        return "N/A";
                }
            }
        }

        /// <summary>
        /// Logic used for determining the ticket a driver will recieve.
        /// </summary>
        /// <param name="driver">Driver the officer has just pulled over.</param>
        /// <returns>The citation the driver recieved.</returns>
        public Citation PullOver(Driver driver) {
            Citation newCitation = new Citation()
            {
                CitedDriver = driver,
                CitingOfficer = this,
                CurrentViolationReason = this.reason,
            };

            CitationType currentCitationType = CitationType.Warning;
            ViolationType currentViolationType = ViolationType.Moving;
            var speeding = ViolationReason.Speeding;
            if (newCitation.CurrentViolationReason == speeding) {
                var speedDifference = this.CurrentSpeedLimit - driver.CurrentSpeed;
                // Check DOB
                DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (DateTime.Compare(driver.DateOfBirth, today) == 0) { speedDifference -= 10; }
                if (speedDifference >= 5 && speedDifference <= 10) {
                    currentCitationType = CitationType.SmallTicket;
                } else if (speedDifference >= 11 && speedDifference <= 15) {
                    currentCitationType = CitationType.MediumTicket;
                } else if (speedDifference >= 16) {
                    currentCitationType = CitationType.BigTicket;
                }
            } else {
                if (this.Mood >= 5) {
                    currentCitationType = CitationType.Ticket;
                } else {
                    currentCitationType = CitationType.Warning;
                }
                var reasonNumber = (int)this.reason;
                if (reasonNumber >= 5) {
                    currentViolationType = ViolationType.Moving;
                } else {
                    currentViolationType = ViolationType.NonMoving;
                }
            }

            newCitation.CurrentCitationType = currentCitationType;
            newCitation.CurrentViolationType = currentViolationType;

            if (currentCitationType == CitationType.Warning) {
                newCitation.OfficerComments = this.NegativeComment;
            } else {
                newCitation.OfficerComments = this.PositiveComment;
            }

            return newCitation;
        }
    }
}