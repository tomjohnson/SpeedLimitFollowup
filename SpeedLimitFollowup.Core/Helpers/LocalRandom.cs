﻿namespace SpeedLimitFollowup.Core.Helpers {
    using System;

    /// <summary>
    /// Methods to be used throughtout the system and not violated the DRY principle.
    /// </summary>
    public static class LocalRandom {
        private static readonly System.Random getrandom = new System.Random();
        private static readonly object syncLock = new object();

        /// <summary>
        /// Generates a random number between the passed in numbers.
        /// </summary>
        /// <param name="min">Lower end of the random set.</param>
        /// <param name="max">Upper end of the random set.</param>
        /// <returns>Random number between the passed in intergers.</returns>
        public static int GetRandomNumber(int min, int max) {
            lock (syncLock) { // synchronize
                return getrandom.Next(min, max);
            }
        }
    }
}