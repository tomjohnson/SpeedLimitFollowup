namespace SpeedLimitFollowup.Console {
    using System;
    using System.Collections.Generic;
    using SpeedLimitFollowup.Core.classes;

    public class Program {
        static void Main(string[] args) {

            List<Driver> drivers = GenerateDrivers();
            List<Officer> officers = GenerateOfficer();
            for (int i = 0; i > 10; i++) {
                var citation = officers[i].PullOver(drivers[i]);
                citation.ToString();
                Console.WriteLine("Press any key to move on...");
                Console.ReadLine();
            }

            Console.WriteLine("Press any key to terminated execution...");
            Console.ReadLine();
        }

        private static List<Officer> GenerateOfficer() {
            throw new NotImplementedException();
        }

        private static List<Driver> GenerateDrivers() {
            throw new NotImplementedException();
        }
    }
}