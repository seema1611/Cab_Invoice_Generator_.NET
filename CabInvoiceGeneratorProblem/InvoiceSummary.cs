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
        public double AverageFare;
        public double TotalFare;
        public int NumberOfRides;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRides">Count of Rides.</param>
        /// <param name="totalFare">Total Fare.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.NumberOfRides = numberOfRides;
            this.TotalFare = totalFare;
            this.AverageFare = this.TotalFare / this.NumberOfRides;
        }

        /// <summary>
        /// Override Equal Method.
        /// </summary>
        /// <param name="obj">Object Parameter.</param>
        /// <returns>Object.</returns>
        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   this.AverageFare == summary.AverageFare &&
                   this.TotalFare == summary.TotalFare &&
                   this.NumberOfRides == summary.NumberOfRides;
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
