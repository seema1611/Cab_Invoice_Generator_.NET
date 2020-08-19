// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorProblem
{
    using System.Collections.Generic;

    /// <summary>
    /// Create Class Ride Repository.
    /// </summary>
    public class RideRepository
    {
        private readonly Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Addition of Multiple Rides.
        /// </summary>
        /// <param name="userID">User id.</param>
        /// <param name="ride">Rides.</param>
        public void AddRide(string userID, Ride[] ride)
        {
            bool ridesList = this.userRides.ContainsKey(userID);
            if (!ridesList)
            {
                this.userRides.Add(userID, new List<Ride>(ride));
            }
        }

        /// <summary>
        /// Getting User Id.
        /// </summary>
        /// <param name="userID">User Id Field.</param>
        /// <returns>id.</returns>
        public Ride[] GetRides(string userID)
        {
            return this.userRides[userID].ToArray();
        }
    }
}
