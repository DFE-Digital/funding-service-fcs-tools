namespace BuildQuery.WebApp.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using TfsData.Models;

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

        public IEnumerable<FctFailedTest> FailedTestList { get; internal set; }
    }
}
