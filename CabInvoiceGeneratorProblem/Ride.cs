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
        public Category.RideType RideType;
        public double Distance;
        public int Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// Create Constructor.
        /// </summary>
        /// <param name="rideType">RideType .</param>
        /// <param name="distance">Value Distance.</param>
        /// <param name="time">Value Time.</param>
        public Ride(Category.RideType rideType, double distance, int time)
        {
            this.RideType = rideType;
            this.Distance = distance;
            this.Time = time;
        }
    }
}
