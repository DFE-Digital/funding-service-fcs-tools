using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildQuery.Web.Models
{
    public class FctBurndown
    {
        public string Team { get; set; }
       
        public string Iteration { get; set; }
        
        public IEnumerable<BurnDownDataPoint> DataPoints { get; set; }
        
    }
}
