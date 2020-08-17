// <copyright file="CabInvoiceGenerator.cs" company="PlaceholderCompany">
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
        public double MINIMUMCOSTPERKILOMETER = 10.0;
        public int COSTPERTIME = 1;
        public double MINIMUMFARE = 5.0;
        private RideRepository rideRepository;
        private RideTypeEnum type = new RideTypeEnum();

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
        public double CalculateFare(RideTypeEnum.RideType rideType, double distance, int time)
        {
            this.SetValue(rideType);
            double premiumTotalFare = (distance * MINIMUMCOSTPERKILOMETER) + (time * COSTPERTIME);
            return Math.Max(premiumTotalFare, MINIMUMFARE);
        }

        public void SetValue(RideTypeEnum.RideType rideType)
        {
            RideTypeEnum ride = this.type.GetRideValue(rideType);
            MINIMUMCOSTPERKILOMETER = ride.costPerKm;
            COSTPERTIME = ride.costPerMin;
            MINIMUMFARE = ride.minimumFare;
        }

        /// <summary>
        /// Create Method For Multiple Ride And Calculate Aggregate Fare.
        /// </summary>
        /// <param name="rideType">Ride Type.</param>
        /// <param name="rides">Distance and time array.</param>
        /// <returns>Total fare.</returns>
        public InvoiceSummary AddRide(RideTypeEnum.RideType rideType, Ride[] rides)
        {
            double totalFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(rideType, ride.Distance, ride.Time);
            }

            return new InvoiceSummary(rides.Length, totalFare);
        }

        public void AddRide(string userId, Ride[] rides)
        {
            this.rideRepository.AddRide(userId, rides);
        }

        public InvoiceSummary GetInvoiceSummary(RideTypeEnum.RideType type, string userID)
        {
            return this.AddRide(type, this.rideRepository.GetRides(userID));
        }
    }
}