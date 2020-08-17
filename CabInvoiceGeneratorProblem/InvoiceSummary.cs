// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorProblem
{
    /// <summary>
    /// Class For Invoice Summary.
    /// </summary>
    public class InvoiceSummary
    {
        public double averageFare;
        public double totalFare;
        public int numberOfRides;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRides">Count of Rides.</param>
        /// <param name="totalFare">Total Fare.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

        /// <summary>
        /// Override Equal Method.
        /// </summary>
        /// <param name="obj">Object Parameter.</param>
        /// <returns>Object.</returns>
        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   this.averageFare == summary.averageFare &&
                   this.totalFare == summary.totalFare &&
                   this.numberOfRides == summary.numberOfRides;
        }

        /// <summary>
        /// Override GetHashCode Method.
        /// </summary>
        /// <returns>Hash Code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
