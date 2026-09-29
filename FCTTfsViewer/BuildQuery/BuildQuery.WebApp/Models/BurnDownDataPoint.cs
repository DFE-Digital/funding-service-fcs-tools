namespace BuildQuery.WebApp.Models
{
    using System;

    public class BurnDownDataPoint
    {
        public DateTime Date { get; set; }
        
        public int Index { get; set; }
        
        public double? RemainingWorkHours { get; set; }
        
        public double? IdealTrendHours { get; set; }
        
        public double ActualTrendHours { get; set; }
        
        public double? RemainingWorkPoints { get; set; }
       
        public double? IdealTrendPoints { get; set; }
        
        public double ActualTrendPoints { get; set; }
        
    }
}
