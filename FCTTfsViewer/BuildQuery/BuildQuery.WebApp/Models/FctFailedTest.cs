using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildQuery.WebApp.Models
{
    public class FctFailedTest
    {
        public string Name {  get;  set; }
        public string ErrorMessage { get; set; }
        public string BuildName { get; internal set; }
        public string TestRunName { get; internal set; }
    }
}