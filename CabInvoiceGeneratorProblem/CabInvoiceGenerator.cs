namespace CabInvoiceGeneratorProblem
{
    using System;

    /// <summary>
    /// Create Cab Invoice Generator Class.
    /// </summary>
    public class CabInvoiceGenerator
    {
        private static readonly double MINIMUM_COST_PER_KILOMETER = 10.0;
        private static readonly int COST_PER_TIME = 1;
        private static readonly double MINIMUM_FARE = 5.0;

        /// <summary>
        /// Create Calculate Fare Method.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double premiumTotalFare = (distance * MINIMUM_COST_PER_KILOMETER) + (time * COST_PER_TIME);
            return Math.Max(premiumTotalFare, MINIMUM_FARE);
        }
    }
}