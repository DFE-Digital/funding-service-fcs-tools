namespace BuildQuery.WebApp.Models
{
    using System;
    using System.Collections.Generic;

    public class MainModel
    {
        private DateTime _lastRefresh;

         public IEnumerable<FctBuildDetail> BuildList { get; set; }
        
        public IEnumerable<FctBuildDetail> KeyBuildList { get; set; }

        public IEnumerable<FctBuildDetail> RunningKeyBuildList { get; set; }


        public IEnumerable<FctBurndown> TeamBurnDowns { get; set; }
       

        public IEnumerable<string> BrokenBuilds { get; set; }
       
        public IEnumerable<FctTask> InProgressTasks { get; set; }
        public string BuildText { get; set; }
        
        public DateTime LastRefresh { get; set; }
       
    }
}
