namespace CabInvoiceGeneratorProblemTest
{
    using CabInvoiceGeneratorProblem;
    using NUnit.Framework;

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
    }
}