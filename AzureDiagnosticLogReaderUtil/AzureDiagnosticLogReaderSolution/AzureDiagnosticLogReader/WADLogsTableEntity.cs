using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDiagnosticLogReader
{
    public class LogEntity : GenericTableEntity
    {
        
        public string Message
        {
            get { return Properties["Message"].StringValue; }
        }

        public DateTime EventDateTime
        {
            get { return new DateTime(long.Parse(this.PartitionKey.Substring(1))); }
        }

    }
}