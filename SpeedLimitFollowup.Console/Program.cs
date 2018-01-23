namespace SpeedLimitFollowup.Console {
    using System;
    using System.Collections.Generic;
    using SpeedLimitFollowup.Core.Classes;

    public class Program {
        public static void Main() {
            List<Driver> drivers = Driver.GenerateDrivers();
            List<Officer> officers = Officer.GenerateOfficers();
            for (int i = 0; i < officers.Count; i++) {
                Citation currentCitation = officers[i].PullOver(drivers[i]);

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