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
        /// TC-1 ->Create Test For Calculate Total Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenMorethanFive_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = this.cabInvoiceGenerator.CalculateFare(Category.RideType.NORMAL, distance, time);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// TC-2 ->Create Test For Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenlessthanFive_ShouldReturnTotalFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = this.cabInvoiceGenerator.CalculateFare(Category.RideType.NORMAL, distance, time);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// TC-3 ->Create Test For Calculate Aggregate Of Multiple Rides.
        /// </summary>
        [Test]
        public void GivenMuiltpleRides_WhenRidesMoreThanFive_ShouldReturnTotalFare()
        {
            Ride[] ride = { new Ride(Category.RideType.NORMAL, 2.0, 5), new Ride(Category.RideType.NORMAL, 2.0, 5) };
            InvoiceSummary summary = this.cabInvoiceGenerator.AddRide(Category.RideType.NORMAL, ride);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// TC-4 ->Craete Test For Checking Pattern Of UserId Is Invalid.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_WhenUserIDIsValid_ShouldReturnTotalFare()
        {
            string userID = "seemarajpure16@gmail.com";
            double distance = 2.0;
            int time = 5;
            Ride[] ride = { new Ride(Category.RideType.NORMAL, distance, time), new Ride(Category.RideType.NORMAL, distance, time) };
            this.cabInvoiceGenerator.AddRide(userID, ride);
            InvoiceSummary summary = this.cabInvoiceGenerator.GetInvoiceSummary(Category.RideType.NORMAL, userID);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// TC-5 ->Create Test For Chekck Pattern Of UserId Is Invalid.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_WhenUserIDIsNotValid_ShouldThrowException()
        {
            string userID = "seemarajpure";
            double distance = 2.0;
            int time = 5;
            Ride[] ride = { new Ride(Category.RideType.NORMAL, distance, time), new Ride(Category.RideType.NORMAL, distance, time) };
            var userException = Assert.Throws<CabInvoiceException>(() => this.cabInvoiceGenerator.AddRide(userID, ride));
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_USERID, userException.type);
        }

        /// <summary>
        /// TC-6 ->Create Test Premium Type Return Total Fare.
        /// </summary>
        [Test]
        public void GivenPremiumDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = this.cabInvoiceGenerator.CalculateFare(Category.RideType.PREMIUM, distance, time);
            Assert.AreEqual(40, fare);
        }

        /// <summary>
        /// TC-7 ->Create Test Premium Type For Less Distance Return Minimum Fare.
        /// </summary>
        [Test]
        public void GivenPremiumLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = this.cabInvoiceGenerator.CalculateFare(Category.RideType.PREMIUM, distance, time);
            Assert.AreEqual(20, fare);
        }

        /// <summary>
        /// TC-8 ->Create Test For Premium Type Multiple Rides.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenPremiumRide_ShouldReturnInvoiceSummary()
        {
            Ride[] ride = { new Ride(Category.RideType.PREMIUM, 2.0, 5), new Ride(Category.RideType.PREMIUM, 0.1, 1) };
            InvoiceSummary summary = this.cabInvoiceGenerator.AddRide(Category.RideType.PREMIUM, ride);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}