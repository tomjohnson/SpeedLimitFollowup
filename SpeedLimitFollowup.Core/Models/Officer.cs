namespace SpeedLimitFollowup.Core.Models {
    using System.Collections.Generic;
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