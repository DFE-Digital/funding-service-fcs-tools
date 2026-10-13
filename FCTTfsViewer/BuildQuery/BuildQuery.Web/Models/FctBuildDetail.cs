using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildQuery.Web.Models
{
    public class FctBuildDetail
    {
        public string Status { get; set; }
        public string TestStatus { get; set; }
        public string DefinitionName { get; set; }
        public int Warnings { get; set; }
        public string RequestedFor
        {
            get; set;
        }
        public string LabelName { get; set; }
        public string LastGoodLabelName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public IEnumerable<FctTestRun> TestRunList { get; set; }

    }
}
