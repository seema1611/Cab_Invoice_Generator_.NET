// <copyright file="CabInvoiceGeneratorTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGeneratorProblem;
    using NUnit.Framework;

    /// <summary>
    /// Create Test Class.
    /// </summary>
    public class CabInvoiceGeneratorTest
    {
        private CabInvoiceGenerator cabInvoiceGenerator;

        /// <summary>
        /// setUp Method For Initializing Instance of Class For Test Methods .
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        /// <summary>
        /// Create Test For Calculate Total Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenMorethanFive_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// Create Test For Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenlessthanFive_ShouldReturnTotalFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5.0, fare);
        }

        /// <summary>
        /// Create Test For Calculate Aggregate Of Multiplr Rides.
        /// </summary>
        [Test]
        public void GivenMuiltpleRides_WhenRidesMoreThanFive_ShouldReturnTotalFare()
        {
            Ride[] ride = { new Ride(2.0, 5), new Ride(2.0, 5) };
            double fare = this.cabInvoiceGenerator.AddRide(ride);
            Assert.AreEqual(25, fare);
        }
    }
}