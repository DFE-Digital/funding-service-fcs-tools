namespace VelocityCalculator.Tfs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using Model;

    public static class TfsAdapter
    {
        public const string TfsLocation = "https://tfs.sfa.bis.gov.uk/DefaultCollection";

        public static IReadOnlyCollection<BacklogItem> GetBacklogItems(DateTime workStartedSince)
        {
            using (TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(TfsLocation)))
            {
                Query query = new Query(new WorkItemStore(teamProjectCollection), @"
SELECT
    *
FROM
    WorkItems
WHERE
    System.CreatedDate >= @createdDate AND
    System.AreaPath = 'FCT\Dev' AND
    System.State = 'Done' AND
    System.WorkItemType IN ('Bug', 'Product Backlog Item', 'Task')
ORDER BY
    System.Id DESC",
                    new Dictionary<string, object>
                    {
                        { "createdDate", workStartedSince.AddMonths(-6) } // allow some time between creating and starting the story
                    });

                IReadOnlyCollection<WorkItem> allWorkItems =
                    query.RunQuery()
                    .Cast<WorkItem>()
                    .ToList();

                List<BacklogItem> backlogItems =
                    allWorkItems
                    .Where(wi => wi.Type.Name == "Bug" || wi.Type.Name == "Product Backlog Item")
                    .Select(wi => new BacklogItem(
                        number: wi.Id,
                        title: wi.Title,
                        effort: GetEffort(wi),
                        workStartedDate: GetWorkStartedDate(wi, allWorkItems),
                        doneDate: (DateTime)wi.Fields["Closed Date"].Value))
                    .Where(bi => bi.WorkStartedDate >= workStartedSince)
                    .Where(bi => bi.Effort > 0)
                    .OrderByDescending(bi => bi.DoneDate)
                    .ToList();

                return backlogItems;
            }
        }

        private static decimal GetEffort(WorkItem workItem)
        {
            Field effort = workItem.Fields.Cast<Field>().SingleOrDefault(f => f.Name == "Effort");

            return effort?.Value != null ? decimal.Parse(effort.Value.ToString()) : 0;
        }

        private static DateTime GetWorkStartedDate(WorkItem workItem, IReadOnlyCollection<WorkItem> allWorkItems)
        {
            RelatedLink firstChildLink =
                workItem.Links
                    .Cast<Link>()
                    .Where(lnk => lnk.BaseType == BaseLinkType.RelatedLink)
                    .Cast<RelatedLink>()
                    .Where(lnk => lnk.LinkTypeEnd.Name == "Child")
                    .OrderBy(lnk => lnk.RelatedWorkItemId)
                    .FirstOrDefault();

            if (firstChildLink != null)
            {
                WorkItem firstChildTask = allWorkItems.SingleOrDefault(wi => wi.Id == firstChildLink.RelatedWorkItemId);

                if (firstChildTask != null)
                {
                    return firstChildTask.CreatedDate;
                }
            }

            return workItem.CreatedDate;
        }
    }
}
