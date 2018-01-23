namespace SpeedLimitFollowup.Core.classes {
    using System;
    using SpeedLimitFollowup.Core.extentions;

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

        /// <summary>
        /// Gets the speed the driver was going.
        /// </summary>
        public int CurrentSpeed {
            get {
                return Extentions.GetRandomNumber(25, 95);
            }
        }
    }
}