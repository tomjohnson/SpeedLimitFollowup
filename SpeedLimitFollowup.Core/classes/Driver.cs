namespace SpeedLimitFollowup.Core.Classes {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Displays information about a driver.
    /// </summary>
    public class Driver {
        /// <summary>
        /// Gets or sets the first name of the driver.
        /// </summary>
        public string FristName { get; set; }
        /// <summary>
        ///  Gets or sets the last name of the driver.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the driver.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or set the address of the driver.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        ///  Gets or sets any overflow address information of the driver.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        ///  Gets or sets the city of the driver.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state of the driver.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zipcode of the driver.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the impairment status of the driver.
        /// </summary>
        public bool IsImpaired { get; set; }

        public static List<Driver> GenerateDrivers() {
            List<Driver> drivers = new List<Driver>();

            var driverOne = new Driver()
            {
                FristName = "Tom",
                LastName = "Johnson",
                Address1 = "800 Krause",
                Address2 = string.Empty,
                City = "Westlake",
                State = "LA",
                IsImpaired = false,
                Zip = "70669",
                DateOfBirth = new DateTime(1986, 11, 26),
            };

            var driverTwo = new Driver()
            {
                FristName = "Mary",
                LastName = "Wajert",
                Address1 = "7720 Forest Park Drive",
                Address2 = string.Empty,
                City = "Beaumont",
                State = "TX",
                IsImpaired = false,
                Zip = "77707",
                DateOfBirth = new DateTime(1952, 08, 10),
            };

            var driverThree = new Driver()
            {
                FristName = "Donna",
                LastName = "Johnson",
                Address1 = "780 Vivian",
                Address2 = string.Empty,
                City = "Bridge City",
                State = "TX",
                IsImpaired = false,
                Zip = "70611",
                DateOfBirth = new DateTime(1955, 01, 07),
            };

            var driverFour = new Driver()
            {
                FristName = "Debbie",
                LastName = "Falcon",
                Address1 = "2300 Sunmeadow",
                Address2 = string.Empty,
                City = "Lake Charles",
                State = "LA",
                IsImpaired = false,
                Zip = "70611",
                DateOfBirth = new DateTime(1951, 01, 26),
            };

            var driverFive = new Driver()
            {
                FristName = "Matt",
                LastName = "Johnson",
                Address1 = "417 Anthony Ln",
                Address2 = string.Empty,
                City = "Pearland",
                State = "TX",
                IsImpaired = true,
                Zip = "80729",
                DateOfBirth = new DateTime(1982, 08, 28),
            };

            var driverSix = new Driver()
            {
                FristName = "Adam",
                LastName = "Swann",
                Address1 = "127 E Vouge",
                Address2 = string.Empty,
                City = "Lake Charles",
                State = "LA",
                IsImpaired = false,
                Zip = "70605",
                DateOfBirth = new DateTime(1979, 1, 17),
            };

            var driverSeven = new Driver()
            {
                FristName = "Jude",
                LastName = "Melancon",
                Address1 = "127 Bit Drive",
                Address2 = string.Empty,
                City = "Kansas City",
                State = "MI",
                IsImpaired = true,
                Zip = "84246",
                DateOfBirth = new DateTime(1980, 07, 12),
            };

            var driverEight = new Driver()
            {
                FristName = "Amy",
                LastName = "McCan",
                Address1 = "1927 Angola Way",
                Address2 = string.Empty,
                City = "Tallahassee",
                State = "FL",
                IsImpaired = false,
                Zip = "65424",
                DateOfBirth = new DateTime(1981, 05, 14),
            };

            var driverNine = new Driver()
            {
                FristName = "Dima",
                LastName = "Barashkov",
                Address1 = "024 Kushner Drive",
                Address2 = "Unit 3",
                City = "Boulder",
                State = "CA",
                IsImpaired = true,
                Zip = "15743",
                DateOfBirth = new DateTime(1982, 11, 22),
            };

            var driverTen = new Driver()
            {
                FristName = "Jennifer",
                LastName = "Johnson",
                Address1 = "800 Krause",
                Address2 = string.Empty,
                City = "Westlake",
                State = "LA",
                IsImpaired = false,
                Zip = "70669",
                DateOfBirth = new DateTime(1986, 01, 22),
            };

            drivers.Add(driverOne);
            drivers.Add(driverTwo);
            drivers.Add(driverThree);
            drivers.Add(driverFour);
            drivers.Add(driverFive);
            drivers.Add(driverSix);
            drivers.Add(driverSeven);
            drivers.Add(driverEight);
            drivers.Add(driverNine);
            drivers.Add(driverTen);

            return drivers;
        }
    }
}