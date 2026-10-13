namespace VelocityCalculator.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;

    public class Backlog
    {
        private readonly List<BacklogItem> _items = new List<BacklogItem>();

        public Backlog(IEnumerable<BacklogItem> backlogItems)
        {
            _items.AddRange(backlogItems);
        }

        public IReadOnlyCollection<BacklogItem> Items => _items; 

        public decimal GetAveragePointsPerDay()
        {
            DateTime startDate = _items.OrderBy(bi => bi.WorkStartedDate).First().WorkStartedDate;
            DateTime completedDate = _items.OrderByDescending(bi => bi.DoneDate).First().DoneDate;

            int workingDaysTaken = completedDate.GetWorkingDaysSince(startDate);
            decimal totalEffort = _items.Sum(bi => bi.Effort);

            return Math.Round(totalEffort / workingDaysTaken, 2);
        }

        public decimal GetAverageWorkingDaysPerStory(decimal effort)
        {
            IReadOnlyCollection<BacklogItem> relevantBacklogItems = _items.Where(bi => bi.Effort == effort).ToList();

            decimal totalWorkingDaysTaken = relevantBacklogItems.Sum(bi => bi.WorkingDaysTaken);

            return Math.Round(totalWorkingDaysTaken / relevantBacklogItems.Count(), 1);
        }
    }
}
