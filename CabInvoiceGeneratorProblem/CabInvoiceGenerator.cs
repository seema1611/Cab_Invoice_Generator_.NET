// <copyright file="CabInvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorProblem
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Create Cab Invoice Generator Class.
    /// </summary>
    public class CabInvoiceGenerator
    {
        private double minimumCostPerKm = 10.0;
        private int costPerTime = 1;
        private double minimumFare = 5.0;
        private RideRepository rideRepository;
        private Category type = new Category();
        private Regex userIDPattern = new Regex(@"^[A-Za-z]{3,}([.|+|_|-]?[A-Za-z0-9]+)?[@][A-Za-z0-9]+[.][A-Za-z]{2,4}([.][A-Za-z]{2,4})?$");

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceGenerator"/> class.
        /// </summary>
        public CabInvoiceGenerator()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// Create Calculate Fare Method.
        /// </summary>
        /// <param name="rideType">Input Ride Type.</param>
        /// <param name="distance">Input value distance.</param>
        /// <param name="time">Input value time.</param>
        /// <returns>Calculated Fare.</returns>
        public double CalculateFare(Category.RideType rideType, double distance, int time)
        {
            this.SetValue(rideType);
            double totalFare = (distance * this.minimumCostPerKm) + (time * this.costPerTime);
            return Math.Max(totalFare, this.minimumFare);
        }

        /// <summary>
        /// Value Set.
        /// </summary>
        /// <param name="rideType">RideType is Normal Or Premium.</param>
        public void SetValue(Category.RideType rideType)
        {
            Category ride = this.type.GetRideValue(rideType);
            this.minimumCostPerKm = ride.CostPerKm;
            this.costPerTime = ride.CostPerMin;
            this.minimumFare = ride.MinimumFare;
        }

        /// <summary>
        /// Create Method For Multiple Ride And Calculate Aggregate Fare.
        /// </summary>
        /// <param name="rideType">Ride Type.</param>
        /// <param name="rides">Distance and time array.</param>
        /// <returns>Total fare.</returns>
        public InvoiceSummary AddRide(Category.RideType rideType, Ride[] rides)
        {
            double totalFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(rideType, ride.Distance, ride.Time);
            }

            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Add UserId and value.
        /// </summary>
        /// <param name="userId">Value is userId.</param>
        /// <param name="rides">Rides value.</param>
        public void AddRide(string userId, Ride[] rides)
        {
            if (this.userIDPattern.IsMatch(userId))
            {
                this.rideRepository.AddRide(userId, rides);
            }
            else
            {
                throw new CabInvoiceException("User Id Is Not Valid", CabInvoiceException.ExceptionType.INVALID_USERID);
            }
        }

        public InvoiceSummary GetInvoiceSummary(Category.RideType type, string userID)
        {
            return this.AddRide(type, this.rideRepository.GetRides(userID));
        }
    }
}