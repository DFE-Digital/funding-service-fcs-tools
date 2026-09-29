namespace VelocityCalculator.Model
{
    using System;
    using Extensions;

    public class BacklogItem
    {
        public BacklogItem(int number, string title, decimal effort, DateTime workStartedDate, DateTime doneDate)
        {
            if (doneDate < workStartedDate)
            {
                throw new ArgumentException($"{nameof(doneDate)} cannot be earlier that {nameof(workStartedDate)}");
            }

            Number = number;
            Title = title;
            Effort = effort;
            WorkStartedDate = workStartedDate;
            DoneDate = doneDate;
        }

        public int Number { get; }

        public string Title { get; }

        public decimal Effort { get; }

        public DateTime WorkStartedDate { get; }

        public DateTime DoneDate { get; }

        public int WorkingDaysTaken => DoneDate.GetWorkingDaysSince(WorkStartedDate);
    }
}
