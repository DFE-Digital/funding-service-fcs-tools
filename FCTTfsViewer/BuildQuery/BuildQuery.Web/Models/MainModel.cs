using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildQuery.Web.Models
{
    public class MainModel
    {
        private DateTime _lastRefresh;

         public IEnumerable<FctBuildDetail> BuildList { get; set; }
        
        public IEnumerable<FctBuildDetail> KeyBuildList { get; set; }
       

        public IEnumerable<FctBurndown> TeamBurnDowns { get; set; }
       

        public IEnumerable<string> BrokenBuilds { get; set; }
       
        public string BuildText { get; set; }
        
        public DateTime LastRefresh { get; set; }
       
    }
}
