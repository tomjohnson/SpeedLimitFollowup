namespace SpeedLimitFollowup.Core.Services {
    using System;
    using SpeedLimitFollowup.Core.Enums;
    using SpeedLimitFollowup.Core.Helpers;
    using SpeedLimitFollowup.Core.Interfaces;
    using SpeedLimitFollowup.Core.Models;
    

    public class CitationService : ICitationService {
        /// <summary>
        /// Logic used for determining the ticket a driver will recieve.
        /// </summary>
        /// <param name="driver">Driver the officer has just pulled over.</param>
        /// <returns>The citation the driver recieved.</returns>
        public Citation PullOver(string officerRank, string officerFirstName, string officerLastName, int officerBadgeId,string officerNegativeComment, string officerPositiveComment, string driverFirstName, string driverLastName, string driverAddressOne, string driverAddressTwo, string driverCity, string driverState, string driverZipCode, DateTime driverDateOfBirth, bool driverIsImpaired) { 
            var driversSpeed = LocalRandom.GetRandomNumber(25, 95);
            var currentSpeedLimit = LocalRandom.GetRandomNumber(25, 75);
            var officersMood = LocalRandom.GetRandomNumber(1, 10);
            var reasonNumber = LocalRandom.GetRandomNumber(1, 4);
            var reason = (ViolationReason)reasonNumber;


            Citation newCitation = new Citation()
            {
                OfficerRank = officerRank,
                OfficerFirstName = officerFirstName,
                OfficerLastName = officerLastName,
                OfficerBadgeId = officerBadgeId,
                OfficerComments = string.Empty,
                DriverFirstName = driverFirstName,
                DriverLastName = driverLastName,
                DriverAddressOne = driverAddressOne,
                DriverAddressTwo = driverAddressTwo,
                DriverCity = driverCity,
                DriverDateOfBirth = driverDateOfBirth,
                DriverState = driverState,
                DriverZip = driverZipCode,
                CurrentViolationReason = reason,
            };

            CitationType currentCitationType = CitationType.Warning;
            ViolationType currentViolationType = ViolationType.Moving;
            var speeding = ViolationReason.Speeding; // Habit since linq does not like using Violation.foo in queries.
            var impariment = ViolationReason.SuspicionOfImpairment;
            // Handle speeding.
            if (newCitation.CurrentViolationReason == speeding) {
                var speedDifference = driversSpeed - currentSpeedLimit;

                newCitation.OfficerComments += string.Format("\r\n SpeedLimit: {0} Driver Speed: {1}  Speed: {2}\r\n"
                , currentSpeedLimit, driversSpeed, speedDifference < 0 ? Math.Abs(speedDifference) + " under" : speedDifference + " over");


                // Cut a break if needed.
                string comment = string.Empty;
                speedDifference = speedDifference = CheckBirthdaySpeed.GetSpeed(currentSpeedLimit, driversSpeed, driverDateOfBirth, out comment);
                newCitation.OfficerComments += comment;


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
            } else if (newCitation.CurrentViolationReason == impariment) {
                if (driverIsImpaired) {
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
                newCitation.OfficerComments += officerPositiveComment;
            } else {
                newCitation.OfficerComments += officerNegativeComment;
            }

            return newCitation;
        }
    }
}
