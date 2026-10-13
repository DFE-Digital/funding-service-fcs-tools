using System;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Samples;

namespace CRMConsoleApp
{
    public class Import_File_IntegrationTest
    {
        private DateTime _executionDate;

        /// <summary>
        /// Imports records to Microsoft Dynamics CRM from the specified .csv file.
        /// </summary>
        public void ImportRecords(IOrganizationService _serviceProxy)
    {
        // Create an import map.
        ImportMap importMap = new ImportMap()
        {
            Name = "Import Map " + DateTime.Now.Ticks.ToString(),
            Source = "Import Accounts.csv",
            Description = "Description of data being imported",
            EntitiesPerFile =
                new OptionSetValue((int)ImportMapEntitiesPerFile.SingleEntityPerFile),
            EntityState = EntityState.Created
        };
        Guid importMapId = _serviceProxy.Create(importMap);

        // Create column mappings.

        #region Column One Mappings
        // Create a column mapping for a 'text' type field.
        ColumnMapping colMapping1 = new ColumnMapping()
        {
            // Set source properties.
            SourceAttributeName = "src_name",
            SourceEntityName = "Account_1",

            // Set target properties.
            TargetAttributeName = "name",
            TargetEntityName = Account.EntityLogicalName,

            // Relate this column mapping with the data map.
            ImportMapId =
                new EntityReference(ImportMap.EntityLogicalName, importMapId),

            // Force this column to be processed.
            ProcessCode =
                new OptionSetValue((int)ColumnMappingProcessCode.Process)
        };

        // Create the mapping.
        Guid colMappingId1 = _serviceProxy.Create(colMapping1);
        #endregion

        #region Column Two Mappings
        // Create a column mapping for a 'lookup' type field.
        ColumnMapping colMapping2 = new ColumnMapping()
        {
            // Set source properties.
            SourceAttributeName = "src_parent",
            SourceEntityName = "Account_1",

            // Set target properties.
            TargetAttributeName = "parentaccountid",
            TargetEntityName = Account.EntityLogicalName,

            // Relate this column mapping with the data map.
            ImportMapId =
                new EntityReference(ImportMap.EntityLogicalName, importMapId),

            // Force this column to be processed.
            ProcessCode =
                new OptionSetValue((int)ColumnMappingProcessCode.Process),
        };

        // Create the mapping.
        Guid colMappingId2 = _serviceProxy.Create(colMapping2);

        // Because we created a column mapping of type lookup, we need to specify lookup details in a lookupmapping.
        // One lookupmapping will be for the parent account, and the other for the current record.
        // This lookupmapping is important because without it the current record
        // cannot be used as the parent of another record.

        // Create a lookup mapping to the parent account.  
        LookUpMapping parentLookupMapping = new LookUpMapping()
        {
            // Relate this mapping with its parent column mapping.
            ColumnMappingId =
                new EntityReference(ColumnMapping.EntityLogicalName, colMappingId2),

            // Force this column to be processed.
            ProcessCode =
                new OptionSetValue((int)LookUpMappingProcessCode.Process),

            // Set the lookup for an account entity by its name attribute.
            LookUpEntityName = Account.EntityLogicalName,
            LookUpAttributeName = "name",
            LookUpSourceCode =
                new OptionSetValue((int)LookUpMappingLookUpSourceCode.System)
        };

        // Create the lookup mapping.
        Guid parentLookupMappingId = _serviceProxy.Create(parentLookupMapping);

        // Create a lookup on the current record's "src_name" so that this record can
        // be used as the parent account for another record being imported.
        // Without this lookup, no record using this account as its parent will be imported.
        LookUpMapping currentLookUpMapping = new LookUpMapping()
        {
            // Relate this lookup with its parent column mapping.
            ColumnMappingId =
                new EntityReference(ColumnMapping.EntityLogicalName, colMappingId2),

            // Force this column to be processed.
            ProcessCode =
                new OptionSetValue((int)LookUpMappingProcessCode.Process),

            // Set the lookup for the current record by its src_name attribute.
            LookUpAttributeName = "src_name",
            LookUpEntityName = "Account_1",
            LookUpSourceCode =
                new OptionSetValue((int)LookUpMappingLookUpSourceCode.Source)
        };

        // Create the lookup mapping
        Guid currentLookupMappingId = _serviceProxy.Create(currentLookUpMapping);
        #endregion

        #region Column Three Mappings
        // Create a column mapping for a 'picklist' type field
        ColumnMapping colMapping3 = new ColumnMapping()
        {
            // Set source properties
            SourceAttributeName = "src_addresstype",
            SourceEntityName = "Account_1",

            // Set target properties
            TargetAttributeName = "address1_addresstypecode",
            TargetEntityName = Account.EntityLogicalName,

            // Relate this column mapping with its parent data map
            ImportMapId =
                new EntityReference(ImportMap.EntityLogicalName, importMapId),

            // Force this column to be processed
            ProcessCode =
                new OptionSetValue((int)ColumnMappingProcessCode.Process)
        };

        // Create the mapping
        Guid colMappingId3 = _serviceProxy.Create(colMapping3);

        // Because we created a column mapping of type picklist, we need to specify picklist details in a picklistMapping
        PickListMapping pickListMapping1 = new PickListMapping()
        {
            SourceValue = "bill",
            TargetValue = 1,

            // Relate this column mapping with its column mapping data map
            ColumnMappingId =
                new EntityReference(ColumnMapping.EntityLogicalName, colMappingId3),

            // Force this column to be processed
            ProcessCode =
                new OptionSetValue((int)PickListMappingProcessCode.Process)
        };

        // Create the mapping
        Guid picklistMappingId1 = _serviceProxy.Create(pickListMapping1);

        // Need a picklist mapping for every address type code expected
        PickListMapping pickListMapping2 = new PickListMapping()
        {
            SourceValue = "ship",
            TargetValue = 2,

            // Relate this column mapping with its column mapping data map
            ColumnMappingId =
                new EntityReference(ColumnMapping.EntityLogicalName, colMappingId3),

            // Force this column to be processed
            ProcessCode =
                new OptionSetValue((int)PickListMappingProcessCode.Process)
        };

        // Create the mapping
        Guid picklistMappingId2 = _serviceProxy.Create(pickListMapping2);
        #endregion

        // Create Import
        Import import = new Import()
        {
            // IsImport is obsolete; use ModeCode to declare Create or Update.
            ModeCode = new OptionSetValue((int)ImportModeCode.Create),
            Name = "Importing data"
        };

         //  ImportFileFileTypeCode.XMLSpreadsheet2003

        Guid importId = _serviceProxy.Create(import);

        // Create Import File.
        ImportFile importFile = new ImportFile()
        {
            Content = BulkImportHelper.ReadCsvFile("Import Accounts.csv"), // Read contents from disk.
            Name = "Account record import",
            IsFirstRowHeader = true,
            ImportMapId = new EntityReference(ImportMap.EntityLogicalName, importMapId),
            UseSystemMap = false,
            Source = "Import Accounts.csv",
            SourceEntityName = "Account_1",
            TargetEntityName = Account.EntityLogicalName,
            ImportId = new EntityReference(Import.EntityLogicalName, importId),
            EnableDuplicateDetection = false,
            FieldDelimiterCode =
                new OptionSetValue((int)ImportFileFieldDelimiterCode.Comma),
            DataDelimiterCode =
                new OptionSetValue((int)ImportFileDataDelimiterCode.DoubleQuote),
            ProcessCode =
                new OptionSetValue((int)ImportFileProcessCode.Process)

           
        };

        // Get the current user to set as record owner.
        WhoAmIRequest systemUserRequest = new WhoAmIRequest();
        WhoAmIResponse systemUserResponse =
            (WhoAmIResponse)_serviceProxy.Execute(systemUserRequest);

        // Set the owner ID.				
        importFile.RecordsOwnerId =
            new EntityReference(SystemUser.EntityLogicalName, systemUserResponse.UserId);

     

        Guid importFileId = _serviceProxy.Create(importFile);

        // Retrieve the header columns used in the import file.
        GetHeaderColumnsImportFileRequest headerColumnsRequest = new GetHeaderColumnsImportFileRequest()
        {
            ImportFileId = importFileId
        };
        GetHeaderColumnsImportFileResponse headerColumnsResponse =
            (GetHeaderColumnsImportFileResponse)_serviceProxy.Execute(headerColumnsRequest);

        // Output the header columns.
        int columnNum = 1;
        foreach (string headerName in headerColumnsResponse.Columns)
        {
            Console.WriteLine("Column[" + columnNum.ToString() + "] = " + headerName);
            columnNum++;
        }

        // Parse the import file.
        ParseImportRequest parseImportRequest = new ParseImportRequest()
        {
            ImportId = importId
        };
        ParseImportResponse parseImportResponse =
            (ParseImportResponse)_serviceProxy.Execute(parseImportRequest);
        Console.WriteLine("Waiting for Parse async job to complete");
        BulkImportHelper.WaitForAsyncJobCompletion(_serviceProxy, parseImportResponse.AsyncOperationId);
        BulkImportHelper.ReportErrors(_serviceProxy, importFileId);

        // Retrieve the first two distinct values for column 1 from the parse table.
        // NOTE: You must create the parse table first using the ParseImport message.
        // The parse table is not accessible after ImportRecordsImportResponse is called.
        GetDistinctValuesImportFileRequest distinctValuesRequest = new GetDistinctValuesImportFileRequest()
        {
            columnNumber = 1,
            ImportFileId = importFileId,
            pageNumber = 1,
            recordsPerPage = 2,
        };
        GetDistinctValuesImportFileResponse distinctValuesResponse =
            (GetDistinctValuesImportFileResponse)_serviceProxy.Execute(distinctValuesRequest);

        // Output the distinct values.  In this case: (column 1, row 1) and (column 1, row 2).
        int cellNum = 1;
        foreach (string cellValue in distinctValuesResponse.Values)
        {
            Console.WriteLine("(1, " + cellNum.ToString() + "): " + cellValue);
            Console.WriteLine(cellValue);
            cellNum++;
        }

        // Retrieve data from the parse table.
        // NOTE: You must create the parse table first using the ParseImport message.
        // The parse table is not accessible after ImportRecordsImportResponse is called.
        RetrieveParsedDataImportFileRequest parsedDataRequest = new RetrieveParsedDataImportFileRequest()
        {
            ImportFileId = importFileId,
            PagingInfo = new PagingInfo()
            {
                // Specify the number of entity instances returned per page.
                Count = 2,
                // Specify the number of pages returned from the query.
                PageNumber = 1,
                // Specify a total number of entity instances returned.
                PagingCookie = "1"
            }
        };

        RetrieveParsedDataImportFileResponse parsedDataResponse =
            (RetrieveParsedDataImportFileResponse)_serviceProxy.Execute(parsedDataRequest);

        // Output the first two rows retrieved.
        int rowCount = 1;
        foreach (string[] rows in parsedDataResponse.Values)
        {
            int colCount = 1;
            foreach (string column in rows)
            {
                Console.WriteLine("(" + rowCount.ToString() + "," + colCount.ToString() + ") = " + column);
                colCount++;
            }
            rowCount++;
        }

        // Transform the import
        TransformImportRequest transformImportRequest = new TransformImportRequest()
        {
            ImportId = importId
        };
        TransformImportResponse transformImportResponse =
            (TransformImportResponse)_serviceProxy.Execute(transformImportRequest);
        Console.WriteLine("Waiting for Transform async job to complete");
        BulkImportHelper.WaitForAsyncJobCompletion(_serviceProxy, transformImportResponse.AsyncOperationId);
        BulkImportHelper.ReportErrors(_serviceProxy, importFileId);

        // Upload the records.
        ImportRecordsImportRequest importRequest = new ImportRecordsImportRequest()
        {
            ImportId = importId
        };
        ImportRecordsImportResponse importResponse =
            (ImportRecordsImportResponse)_serviceProxy.Execute(importRequest);
        Console.WriteLine("Waiting for ImportRecords async job to complete");
        BulkImportHelper.WaitForAsyncJobCompletion(_serviceProxy, importResponse.AsyncOperationId);
        BulkImportHelper.ReportErrors(_serviceProxy, importFileId);
    }

    ///// <summary>
    ///// Deletes any entity records that were created for this sample.
    ///// <param name="prompt">Indicates whether to prompt the user 
    ///// to delete the records created in this sample.</param>
    ///// </summary>
    //public void DeleteRequiredRecords(bool prompt)
    //{
    //    bool toBeDeleted = true;

    //    if (prompt)
    //    {
    //        // Ask the user if the created entities should be deleted.
    //        Console.Write("\nDo you want these entity records deleted? (y/n) [y]: ");
    //        String answer = Console.ReadLine();
    //        if (answer.StartsWith("y") ||
    //            answer.StartsWith("Y") ||
    //            answer == String.Empty)
    //        {
    //            toBeDeleted = true;
    //        }
    //        else
    //        {
    //            toBeDeleted = false;
    //        }
    //    }

    //    if (toBeDeleted)
    //    {
    //        // Retrieve all account records created in this sample.
    //        QueryExpression query = new QueryExpression()
    //        {
    //            EntityName = Account.EntityLogicalName,
    //            Criteria = new FilterExpression()
    //            {
    //                Conditions =
    //                    {
    //                        new ConditionExpression("createdon", ConditionOperator.OnOrAfter, _executionDate),
    //                    }
    //            },
    //            ColumnSet = new ColumnSet(false)
    //        };
    //        var accountsCreated = _serviceProxy.RetrieveMultiple(query).Entities;

    //        // Delete all records created in this sample.
    //        foreach (var account in accountsCreated)
    //        {
    //            _serviceProxy.Delete(Account.EntityLogicalName, account.Id);
    //        }

    //        Console.WriteLine("Entity record(s) have been deleted.");
    //    }
    //}
  
}
}


 
