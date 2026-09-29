namespace BuildQuery.WebApp.Models
{
    using System.Collections.Generic;

    public class FctBurndown
    {
        public string Team { get; set; }
       
        public string Iteration { get; set; }
        
        public IEnumerable<BurnDownDataPoint> DataPoints { get; set; }
        
    }
}
