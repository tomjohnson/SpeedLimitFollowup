namespace SpeedLimitFollowup.Core.Helpers {
    using System;

    public class CheckBirthdaySpeed {
        public static int GetSpeed(int speedLimit, int driverSpeed, DateTime driversBirthday, out string Comment) {
            var speedDifference = driverSpeed - speedLimit;
            // Check DOB
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            // Can't compare directly since the year witll be off.

            DateTime driverBirthday = new DateTime(DateTime.Now.Year, driversBirthday.Month, driversBirthday.Day);

            if (DateTime.Compare(driverBirthday, today) == 0) {
                speedDifference -= 5;
                Comment = "I've cut you a break reducing Overage by 5 MPH.\r\n";
            } else {
                speedDifference = 0;
                Comment = "Today is not your birthday, I cannot reduce your overage. \r\n";
            }

            return speedDifference;
        }
    }
}
