// <copyright file="Category.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorProblem
{
    public class Category
    {
        public double CostPerKm;
        public int CostPerMin;
        public double MinimumFare;

        public enum RideType
        {
            NORMAL,
            PREMIUM,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="costPerKm">Cost Per Kilometer.</param>
        /// <param name="costPerMin">Cost Per Minute.</param>
        /// <param name="minimumFare">Minimum Fare.</param>
        public Category(double costPerKm, int costPerMin, double minimumFare)
        {
            this.CostPerKm = costPerKm;
            this.CostPerMin = costPerMin;
            this.MinimumFare = minimumFare;
        }

        public Category GetRideValue(RideType rideType)
        {
            if (rideType.Equals(RideType.NORMAL))
            {
                return new Category(10, 1, 5);
            }

            if (rideType.Equals(RideType.PREMIUM))
            {
                return new Category(15, 2, 20);
            }
            else
            {
                return null;
            }
        }
    }
}
