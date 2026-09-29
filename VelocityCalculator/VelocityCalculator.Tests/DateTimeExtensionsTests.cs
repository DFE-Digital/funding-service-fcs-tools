namespace VelocityCalculator.Tests
{
    using System;
    using Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void GetWorkingDaysSince_ShouldReturnExpectedValuesWhenDatesAreInSameWeek()
        {
            Assert.AreEqual(1, new DateTime(2017, 03, 10, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc)));
            Assert.AreEqual(2, new DateTime(2017, 03, 10, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2017, 03, 09, 11, 00, 00, DateTimeKind.Utc)));
            Assert.AreEqual(3, new DateTime(2017, 03, 10, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2017, 03, 08, 11, 00, 00, DateTimeKind.Utc)));
            Assert.AreEqual(4, new DateTime(2017, 03, 10, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2017, 03, 07, 11, 00, 00, DateTimeKind.Utc)));
        }

        [TestMethod]
        public void GetWorkingDaysSince_ShouldReturnExpectedValuesWhenDatesCrossWeekend()
        {
            Assert.AreEqual(2, new DateTime(2017, 03, 06, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2017, 03, 03, 14, 00, 00, DateTimeKind.Utc)));
            Assert.AreEqual(5, new DateTime(2017, 03, 06, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2017, 02, 28, 14, 00, 00, DateTimeKind.Utc)));
        }

        [TestMethod]
        public void GetWorkingDaysSince_ShouldReturnExpectedValuesWhenDatesCrossTwoWeekends()
        {
            Assert.AreEqual(7, new DateTime(2017, 03, 06, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2017, 02, 24, 14, 00, 00, DateTimeKind.Utc)));
        }

        [TestMethod]
        public void GetWorkingDaysSince_ShouldReturnExpectedValuesWhenDatesCrossBankHoliday()
        {
            Assert.AreEqual(2, new DateTime(2017, 01, 03, 11, 00, 00, DateTimeKind.Utc).GetWorkingDaysSince(new DateTime(2016, 12, 30, 14, 00, 00, DateTimeKind.Utc)));
        }
    }
}
