﻿// <copyright file="CabInvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorProblem
{
    using System;

    /// <summary>
    /// Create Cab Invoice Generator Class.
    /// </summary>
    public class CabInvoiceGenerator
    {
        private static readonly double MINIMUMCOSTPERKILOMETER = 10.0;
        private static readonly int COSTPERTIME = 1;
        private static readonly double MINIMUMFARE = 5.0;

        /// <summary>
        /// Create Calculate Fare Method.
        /// </summary>
        /// <param name="distance">Input value distance.</param>
        /// <param name="time">Input value time.</param>
        /// <returns>Calculated Fare.</returns>
        public double CalculateFare(double distance, int time)
        {
            double premiumTotalFare = (distance * MINIMUMCOSTPERKILOMETER) + (time * COSTPERTIME);
            return Math.Max(premiumTotalFare, MINIMUMFARE);
        }

        /// <summary>
        /// Create Method For Multiple Ride And Calculate Aggregate Fare.
        /// </summary>
        /// <param name="rides">Distance and time array.</param>
        /// <returns>Total fare.</returns>
        public double AddRide(Ride[] rides)
        {
            double totalFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.Distance, ride.Time);
            }

            return totalFare / rides.Length;
        }
    }
}
