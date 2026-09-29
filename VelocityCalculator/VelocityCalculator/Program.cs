namespace VelocityCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Model;
    using Tfs;

    class Program
    {
        static void Main()
        {
            DateTime workStartedSince = new DateTime(2017, 01, 01, 0, 0, 0, DateTimeKind.Utc);

            Console.WriteLine($"Retrieving completed backlog items started since {workStartedSince.ToShortDateString()}..");

            IReadOnlyCollection<BacklogItem> backlogItems = TfsAdapter.GetBacklogItems(workStartedSince);

            Console.WriteLine($"Retrieved {backlogItems.Count} items..");
            Console.WriteLine("Calculating velocities..");

            Backlog backlog = new Backlog(backlogItems);

            RenderBacklogStatistics(backlog, new DateTime(2017, 01, 01, 0, 0, 0, DateTimeKind.Utc));
            RenderBacklogStatistics(backlog, new DateTime(2017, 02, 01, 0, 0, 0, DateTimeKind.Utc));
            RenderBacklogStatistics(backlog, new DateTime(2017, 03, 01, 0, 0, 0, DateTimeKind.Utc));

            //File.WriteAllText("TfsWorkItemsDone.csv", new CsvWriter<BacklogItem>().CreateCsv(backlogItems));

            if (Debugger.IsAttached)
            {
                Console.ReadKey();
            }
        }

        private static void RenderBacklogStatistics(Backlog backlog, DateTime workStartedSince)
        {
            Backlog partBacklog = new Backlog(backlog.Items.Where(bi => bi.WorkStartedDate >= workStartedSince));

            Console.WriteLine();

            Console.WriteLine($"VELOCITY SINCE {workStartedSince.ToShortDateString()}");
            Console.WriteLine("-------------------------");

            Console.WriteLine($"{partBacklog.GetAveragePointsPerDay()} story points per day");
            Console.WriteLine($"{partBacklog.GetAveragePointsPerDay() * 5} story points per week");

            Console.WriteLine();

            if (partBacklog.Items.Any(bi => bi.Effort == 1M))
            {
                Console.WriteLine($"1 SP: {partBacklog.GetAverageWorkingDaysPerStory(1)} working days");
            }
            if (partBacklog.Items.Any(bi => bi.Effort == 2M))
            {
                Console.WriteLine($"2 SP: {partBacklog.GetAverageWorkingDaysPerStory(2)} working days");
            }
            if (partBacklog.Items.Any(bi => bi.Effort == 3M))
            {
                Console.WriteLine($"3 SP: {partBacklog.GetAverageWorkingDaysPerStory(3)} working days");
            }
        }
    }
}
