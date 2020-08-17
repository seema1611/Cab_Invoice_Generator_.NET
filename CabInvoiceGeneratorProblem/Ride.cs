// <copyright file="Ride.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorProblem
{
    /// <summary>
    /// Create Class Ride.
    /// </summary>
    public class Ride
    {
        public double Distance;
        public int Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// Create Constructor.
        /// </summary>
        /// <param name="distance">Value Distance.</param>
        /// <param name="time">Value Time.</param>
        public Ride(double distance, int time)
        {
            this.Distance = distance;
            this.Time = time;
        }
    }
}
