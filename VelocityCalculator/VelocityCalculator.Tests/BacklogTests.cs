namespace VelocityCalculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;

    [TestClass]
    public class BacklogTests
    {
        [TestMethod]
        public void Backlog_GetAveragePointsPerDay_ShouldReturnExpectedValuesTest1()
        {
            Backlog backlog = new Backlog(new[]
            {
                new BacklogItem(1, "TEST", 1, new DateTime(2017, 03, 09, 00, 00, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 00, 00, 00, DateTimeKind.Utc))
            });

            Assert.AreEqual(0.5, backlog.GetAveragePointsPerDay());
        }

        [TestMethod]
        public void Backlog_GetAveragePointsPerDay_ShouldReturnExpectedValuesTest2()
        {
            Backlog backlog = new Backlog(new[]
            {
                new BacklogItem(1, "TEST", 1, new DateTime(2017, 03, 09, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc)),
                new BacklogItem(2, "TEST", 1, new DateTime(2017, 03, 09, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc))
            });

            Assert.AreEqual(1, backlog.GetAveragePointsPerDay());
        }

        [TestMethod]
        public void Backlog_GetAveragePointsPerDay_ShouldReturnExpectedValuesTest3()
        {
            Backlog backlog = new Backlog(new[]
            {
                new BacklogItem(1, "TEST", 1, new DateTime(2017, 03, 09, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc)),
                new BacklogItem(2, "TEST", 1, new DateTime(2017, 03, 09, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc)),
                new BacklogItem(3, "TEST", 2, new DateTime(2017, 03, 08, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc))
            });

            Assert.AreEqual(1.33, backlog.GetAveragePointsPerDay());
        }

        [TestMethod]
        public void Backlog_GetAveragePointsPerDay_ShouldReturnExpectedValuesTest4()
        {
            Backlog backlog = new Backlog(new[]
            {
                new BacklogItem(1, "TEST", 1, new DateTime(2017, 03, 09, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc)),
                new BacklogItem(2, "TEST", 1, new DateTime(2017, 03, 09, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc)),
                new BacklogItem(3, "TEST", 2, new DateTime(2017, 03, 08, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 10, 14, 00, 00, DateTimeKind.Utc)),
                new BacklogItem(4, "TEST", 3, new DateTime(2017, 03, 02, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 07, 14, 00, 00, DateTimeKind.Utc)),
                new BacklogItem(5, "TEST", 2, new DateTime(2017, 03, 02, 11, 30, 00, DateTimeKind.Utc),  new DateTime(2017, 03, 07, 14, 00, 00, DateTimeKind.Utc))
            });

            Assert.AreEqual(1.29, backlog.GetAveragePointsPerDay());
        }
    }
}
