namespace AzureDiagnosticLogReader
{
    using System;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    public class GenericTableEntity : ITableEntity
    {
        public string ETag { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public int Level { get; set; }
        public IDictionary<string, EntityProperty> Properties { get; set; }
        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            this.Properties = properties;
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            return this.Properties;
        }
    }

    public class SimpleEntity : TableEntity
    {
        public int EventId { get; set; }

        public int Level { get; set; }

        public string Message { get; set; }

        public string RoleInstance { get; set; }
    }
}
