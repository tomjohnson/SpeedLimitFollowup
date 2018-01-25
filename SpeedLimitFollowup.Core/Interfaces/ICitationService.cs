namespace SpeedLimitFollowup.Core.Interfaces {
    using System;
    using SpeedLimitFollowup.Core.Models;

    public interface ICitationService {
        Citation PullOver(
            string officerRank,
            string officerFirstName,
            string officerLastName,
            int officerBadgeId,
            string officerNegativeComment, 
            string officerPositiveComment,
            string driverFirstName,
            string driverLastName,
            string driverAddressOne,
            string driverAddressTwo,
            string driverCity,
            string driverState,
            string driverZipCode,
            DateTime driverDateOfBirth,
            bool driverIsImpaired
            );
    }
}