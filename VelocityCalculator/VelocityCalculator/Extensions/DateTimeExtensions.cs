namespace VelocityCalculator.Extensions
{
    using System;
    using System.Linq;

    public static class DateTimeExtensions
    {
        private static readonly DateTime[] BankHolidays =
        {
            new DateTime(2017, 01, 02, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2017, 04, 14, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2017, 04, 17, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2017, 05, 01, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2017, 05, 29, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2017, 08, 28, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2017, 12, 25, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2017, 12, 26, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 01, 01, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 03, 30, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 04, 02, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 05, 07, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 05, 28, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 08, 27, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 12, 25, 00, 00, 00, DateTimeKind.Utc),
            new DateTime(2018, 12, 26, 00, 00, 00, DateTimeKind.Utc)
        };

        public static int GetWorkingDaysSince(this DateTime dt, DateTime since)
        {
            DateTime toDate = new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 00, DateTimeKind.Utc);
            DateTime fromDate = new DateTime(since.Year, since.Month, since.Day, 00, 00, 00, DateTimeKind.Utc);

            int totalDays = (int)toDate.Subtract(fromDate).TotalDays + 1;

            return
                Enumerable.Range(0, totalDays)
                .Select(i => fromDate.AddDays(i))
                .Count(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday && !BankHolidays.Contains(d));
        }
    }
}
