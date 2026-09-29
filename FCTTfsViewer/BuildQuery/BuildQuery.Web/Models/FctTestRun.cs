using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildQuery.Web.Models
{
    public class FctTestRun
    {
        public string Name { get; set; }
        
        public int TotalTests { get; set; }
        
        public int TotalTestsPassed { get; set; }
      
        public int TotalTestsFailed { get; set; }

        public int TotalTestsInconclusive { get; set; }
        
        public int TotalTestsPending { get; set; }
        

        public int TotalTestsInProgress { get; set; }
    
        public int TotalTestsCompleted { get; set; }
      

        public IEnumerable<string> FailedTestNameList { get; set; }

    }
}
