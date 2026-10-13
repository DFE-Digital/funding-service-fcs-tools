using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildQuery.WebApp.Models
{
    public class FctTask
    {
        public string Name {  get;  set; }
        public string StoryName { get; set; }
        public string Assigned { get; internal set; }
        public DateTime FirstInProgressDate { get; internal set; }
    }
}