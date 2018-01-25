namespace SpeedLimitFollowup.Console {
    using System;
    using System.Collections.Generic;
    using SpeedLimitFollowup.Core.Models;
    using SpeedLimitFollowup.Core.Services;

    public class Program {
        public static void Main() {
            List<Driver> drivers = Driver.GenerateDrivers();
            List<Officer> officers = Officer.GenerateOfficers();
            var service = new CitationService();
            for (int i = 0; i < officers.Count; i++) {
                Citation currentCitation = service.PullOver(
                    officers[i].Rank,
                    officers[i].FirstName,
                    officers[i].LastName,
                    officers[i].BadgeId,
                    officers[i].NegativeComment,
                    officers[i].PositiveComment,
                     drivers[i].FirstName,
                     drivers[i].LastName,
                     drivers[i].AddressOne,
                     drivers[i].AddressTwo,
                     drivers[i].City,
                     drivers[i].State,
                     drivers[i].Zip,
                    drivers[i].DateOfBirth,
                    drivers[i].IsImpaired
                    );

                Console.WriteLine(currentCitation.ToString());
                Console.WriteLine("");
                Console.Write("Press any key to move on...");
                Console.ReadLine();
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Press any key to terminated execution...");
            Console.ReadLine();
        }
    }
}