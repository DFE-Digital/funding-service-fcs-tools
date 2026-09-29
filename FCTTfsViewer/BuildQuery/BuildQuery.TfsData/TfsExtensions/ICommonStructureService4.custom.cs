using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.TfsExtensions
{
    using System.Xml;

    public static class ICommonStructureService4Extensions
    {

        public static IEnumerable<ScheduleInfo> GetIterationDates(this ICommonStructureService4 css, string projectUri)
        {
            NodeInfo[] structures = css.ListStructures(projectUri);
            NodeInfo iterations = structures.FirstOrDefault(n => n.StructureType.Equals("ProjectLifecycle"));
            List<ScheduleInfo> schedule = null;

            if (iterations != null)
            {
                string projectName = css.GetProject(projectUri).Name;

                XmlElement iterationsTree = css.GetNodesXml(new[] { iterations.Uri }, true);
                GetIterationDates(iterationsTree.ChildNodes[0], projectName, ref schedule);
            }

            return schedule;
        }

        private static void GetIterationDates(XmlNode node, string projectName, ref List<ScheduleInfo> schedule)
        {
            if (schedule == null)
                schedule = new List<ScheduleInfo>();

            if (node != null)
            {
                string iterationPath = node.Attributes["Path"].Value;
                if (!string.IsNullOrEmpty(iterationPath))
                {
                    // Attempt to read the start and end dates if they exist.
                    string strStartDate = (node.Attributes["StartDate"] != null)
                        ? node.Attributes["StartDate"].Value
                        : null;
                    string strEndDate = (node.Attributes["FinishDate"] != null)
                        ? node.Attributes["FinishDate"].Value
                        : null;

                    DateTime? startDate = null, endDate = null;
                    DateTime startDate1, endDate1;

                    if (!string.IsNullOrEmpty(strStartDate) && !string.IsNullOrEmpty(strEndDate))
                    {
                        bool datesValid = true;

                        // Both dates should be valid.
                        datesValid &= DateTime.TryParse(strStartDate, out startDate1);
                        datesValid &= DateTime.TryParse(strEndDate, out endDate1);

                        // Clear the dates unless both are valid.
                        if (!datesValid)
                        {
                            startDate = null;
                            endDate = null;
                        }
                        else
                        {
                            startDate = startDate1 == DateTime.MinValue ? (DateTime?)null:startDate1;
                            endDate = endDate1 == DateTime.MinValue ? (DateTime?)null : endDate1; 
                        }
                    }

                    schedule.Add(new ScheduleInfo
                    {
                        Path = iterationPath.Replace(string.Concat("\\", projectName, "\\Iteration"), projectName),
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

                // Visit any child nodes (sub-iterations).
                if (node.FirstChild != null)
                {
                    // The first child node is the <Children> tag, which we'll skip.
                    for (int nChild = 0; nChild < node.ChildNodes[0].ChildNodes.Count; nChild++)
                        GetIterationDates(node.ChildNodes[0].ChildNodes[nChild], projectName, ref schedule);
                }
            }
        }

        public class ScheduleInfo
        {
            public string Path { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }
    }
}
