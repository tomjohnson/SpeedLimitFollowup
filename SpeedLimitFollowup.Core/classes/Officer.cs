namespace SpeedLimitFollowup.Core.Classes {
    using System;
    using System.Collections.Generic;
    using SpeedLimitFollowup.Core.Enums;
    using SpeedLimitFollowup.Core.Helpers;

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
        ///  Gets or sets the comment number for use on the citation.
        /// </summary>
        private int CommentNumber {
            get {
                return LocalRandom.GetRandomNumber(1, 6);
            }
        }

        /// <summary>
        /// Returns the specified comment, 1-15 return a comment, otherwise N/A.
        /// </summary>
        public string NegativeComment {
            get {
                switch (this.CommentNumber) {
                    case 1:
                        return "Hostile driver";
                    case 2:
                        return "Third violation in the month";
                    case 3:
                        return "Muliple infractions at one time";
                    case 4:
                        return "Argumentative";
                    case 5:
                        return "Danger to other drivers";
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
                        return "Driver had a positive attitude so a warning was issued.";
                    case 2:
                        return "Driver explained reason for infraction.";
                    case 3:
                        return "Educated driver on infraction.";
                    case 4:
                        return "First time infraction.";
                    case 5:
                        return "New to the area.";
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
            var driversSpeed = LocalRandom.GetRandomNumber(25, 95);
            var currentSpeedLimit = LocalRandom.GetRandomNumber(25, 75);
            var officersMood = LocalRandom.GetRandomNumber(1, 10);
            var reasonNumber = LocalRandom.GetRandomNumber(1, 4);
            var reason  = (ViolationReason)reasonNumber;
                

                Citation newCitation = new Citation()
            {
                CitedDriver = driver,
                CitingOfficer = this,
                CurrentViolationReason = reason,
            };

            CitationType currentCitationType = CitationType.Warning;
            ViolationType currentViolationType = ViolationType.Moving;
            var speeding = ViolationReason.Speeding; // Habit since linq does not like using Violation.foo in queries.
            var impariment = ViolationReason.SuspicionOfImpairment;
            // Handle speeding.
            if (newCitation.CurrentViolationReason == speeding) {
                var speedDifference = driversSpeed - currentSpeedLimit;

                newCitation.OfficerComments += string.Format("\r\n SpeedLimit: {0} Driver Speed: {1}  Speed Overage:{2}\r\n"
                    , currentSpeedLimit, driversSpeed, speedDifference);

                // Check DOB
                DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                // Can't compare directly since the year witll be off.

                DateTime driverBirthday = new DateTime(DateTime.Now.Year, driver.DateOfBirth.Month, driver.DateOfBirth.Day);

                bool breakCut = false;

                if (DateTime.Compare(driverBirthday, today) == 0) {
                    speedDifference -= 10;
                    breakCut = true;
                }
                                   
                
                // Cut a break if needed.
                if (breakCut) { newCitation.OfficerComments += " I've cut you a break reducing Overage by 10 MPH.\r\n"; }
                if (speedDifference > 0) {
                    if (speedDifference >= 5 && speedDifference <= 10) {
                        currentCitationType = CitationType.SmallTicket;
                    } else if (speedDifference >= 11 && speedDifference <= 15) {
                        currentCitationType = CitationType.MediumTicket;
                    } else if (speedDifference >= 16) {
                        currentCitationType = CitationType.BigTicket;
                    }
                } else {
                    currentCitationType = CitationType.Warning;
                    currentViolationType = ViolationType.Moving;
                }
            }else if (newCitation.CurrentViolationReason == impariment) {
                if (driver.IsImpaired) {
                    currentCitationType = CitationType.Ticket;
                    currentViolationType = ViolationType.Moving;
                    newCitation.OfficerComments += "Driver was visibly impaired. \r\n";
                } else {
                    currentCitationType = CitationType.Warning;
                    currentViolationType = ViolationType.Moving;
                    newCitation.OfficerComments += "Driver was not visibly impaired. \r\n";
                }
            } else {
                // Other infractions are random chance.
                if (officersMood >= 5) {
                    currentCitationType = CitationType.Ticket;
                } else {
                    currentCitationType = CitationType.Warning;
                }
                if (reasonNumber <= 2) {
                    currentViolationType = ViolationType.Moving;
                } else {
                    currentViolationType = ViolationType.NonMoving;
                }
            }

            newCitation.CurrentCitationType = currentCitationType;
            newCitation.CurrentViolationType = currentViolationType;

            if (currentCitationType == CitationType.Warning) {
                newCitation.OfficerComments += this.PositiveComment;
            } else {
                newCitation.OfficerComments += this.NegativeComment;
            }

            return newCitation;
        }

        /// <summary>
        /// Generates a list of officers for testing.
        /// </summary>
        /// <returns>List of officers to test with.</returns>
        public static List<Officer> GenerateOfficers() {
            List<Officer> officers = new List<Officer>();
            var officerOne = new Officer()
            {
                FirstName = "Ricky",
                LastName = "Walsh",
                BadgeId = 6991,
                Rank = "Detective",
            };

            var officerTwo = new Officer()
            {
                FirstName = "John",
                LastName = "McCLain",
                BadgeId = 4227,
                Rank = "Officer",
            };

            var officerThree = new Officer()
            {
                FirstName = "Clarence",
                LastName = "Boddicker",
                BadgeId = 6781,
                Rank = "Sargent",
            };

            var officerFour = new Officer()
            {
                FirstName = "Carl",
                LastName = "Winslow",
                BadgeId = 7379,
                Rank = "Lieutenant",
            };

            var officerFive = new Officer()
            {
                FirstName = "Horatio",
                LastName = "Caine",
                BadgeId = 17671,
                Rank = "Detective",
            };

            var officerSix = new Officer()
            {
                FirstName = "Steven",
                LastName = "Seagal",
                BadgeId = 12727,
                Rank = "Deputy",
            };

            var officerSeven = new Officer()
            {
                FirstName = "Chuck",
                LastName = "Norris",
                BadgeId = 1,
                Rank = "Deputy",
            };

            var officerEight = new Officer()
            {
                FirstName = "Gene",
                LastName = "Roddenberry",
                BadgeId = 2233,
                Rank = "Officer",
            };

            var officerNine = new Officer()
            {
                FirstName = "Mark",
                LastName = "Williams",
                BadgeId = 6584,
                Rank = "Lieutenant",
            };

            var officerTen = new Officer()
            {
                FirstName = "Otto",
                LastName = "",
                BadgeId = 6991,
                Rank = "Detective",
            };

            officers.Add(officerOne);
            officers.Add(officerTwo);
            officers.Add(officerThree);
            officers.Add(officerFour);
            officers.Add(officerFive);
            officers.Add(officerSix);
            officers.Add(officerSeven);
            officers.Add(officerEight);
            officers.Add(officerNine);
            officers.Add(officerTen);
            return officers;
        }
    }
}