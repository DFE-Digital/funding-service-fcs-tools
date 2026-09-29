using Microsoft.Xrm.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Client.Services;
using System.IO;
using System.Globalization;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;

namespace DeactivateDuplicateSubnominals
{
    using System.Configuration;

    /// <summary>
    /// ***** WARNING: RUNNING THIS PROGRAM WILL DEACTIVATE SUBNOMINAL AGGREGATION RECORDS *****
    /// This program was written to deactivate duplicate subnominal aggregation records.
    /// Duplicate subnominal aggregation records are defined as subnominal aggregation records that have the same subnominal aggregate key.
    /// Where duplicate records are found this program will deactivate the records with the earliest modified date
    /// It is intended to be run once
    /// </summary>
    class Program
    {
        static readonly List<SubnominalAggregation> DeactivatedSubnominalAggregations = new List<SubnominalAggregation>();

        private static void Main()
        {
            Console.WriteLine($"Deactivating duplicated subnominal aggregations in CRM with connection: {ConfigurationManager.ConnectionStrings["Crm"].ConnectionString}...");

            CrmConnection connection = new CrmConnection("Crm");
            CrmOrganizationServiceContext context = new CrmOrganizationServiceContext(connection);

            // Retrieve all active subnominal aggregation records and group by subnominal aggregate key
            IOrderedEnumerable<IGrouping<string, SubnominalAggregation>> subnominalAggregateGroups = (from subnominalAggregation in context.CreateQuery("sfa_subnominalaggregation")
                                                                                                      where ((OptionSetValue)subnominalAggregation["statuscode"]).Value == 1
                                                                                                      select new SubnominalAggregation
                                                                                                      {
                                                                                                          SubnominalAggregateKeyWithPaymentType = ConstructSubnominalAggregateKeyWithPaymentType(subnominalAggregation),
                                                                                                          ModifiedOn = (DateTime)subnominalAggregation["modifiedon"],
                                                                                                          Id = (Guid)subnominalAggregation["sfa_subnominalaggregationid"]
                                                                                                      }).ToList()
                                                                                                        .GroupBy(sa => sa.SubnominalAggregateKeyWithPaymentType)
                                                                                                        .OrderBy(sa => sa.Key);

            foreach (IGrouping<string, SubnominalAggregation> subnominalAggregateGroup in subnominalAggregateGroups)
            {
                // If there are duplicate subnominal aggregation records deactivate all except the most recently modified record
                if (subnominalAggregateGroup.Count() > 1)
                {
                    List<SubnominalAggregation> orderedSubnominals = subnominalAggregateGroup.OrderByDescending(sa => sa.ModifiedOn).ToList();
                    orderedSubnominals.RemoveAt(0);
                    orderedSubnominals.ForEach(DeactivateSubnominalAggregation);
                }
            }

            Console.WriteLine("Writing CSV...");
            new CsvWriter<SubnominalAggregation>($"deactivated_subnominalaggregation_entities_{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.csv")
                .SaveItems(DeactivatedSubnominalAggregations);

            Console.WriteLine("All duplicate subnominal aggregation records output to console and CSV File");
            Console.WriteLine("Check the CSV File for details");
            Console.WriteLine("Press any key to close this application");
            Console.ReadKey(false);
        }

        private static string ConstructSubnominalAggregateKeyWithPaymentType(Entity subnominalAggregation)
        {
            Dictionary<OptionSetValue, string> paymentTypeDictionary = new Dictionary<OptionSetValue, string>
            {
                { new OptionSetValue(229660000), "PROFILE" },
                { new OptionSetValue(229660001), "RECONCILIATION" },
                { new OptionSetValue(229660002), "CAPPING" }
            };

            string subnominalAggregateKey = (string)subnominalAggregation["sfa_subnominalaggregatekey"];
            string paymentTypeString = paymentTypeDictionary[(OptionSetValue)subnominalAggregation["sfa_paymenttype"]];

            return $"{subnominalAggregateKey}_{paymentTypeString}";
        }

        private static void DeactivateSubnominalAggregation(SubnominalAggregation subnominalAggregation)
        {
            CrmConnection connection = new CrmConnection("Crm");
            OrganizationService service = new OrganizationService(connection);

            SetStateRequest setStateRequest = new SetStateRequest()
            {
                EntityMoniker = new EntityReference
                {
                    Id = subnominalAggregation.Id,
                    LogicalName = "sfa_subnominalaggregation",
                },
                State = new OptionSetValue(1),
                Status = new OptionSetValue(2)
            };

            service.Execute(setStateRequest);

            DeactivatedSubnominalAggregations.Add(subnominalAggregation);

            Console.WriteLine($"Deactivated subnominal aggregation with aggregation key {subnominalAggregation.SubnominalAggregateKeyWithPaymentType} and modified date {subnominalAggregation.ModifiedOn.ToString("f", new CultureInfo("en-GB"))}");
        }
    }

    class SubnominalAggregation
    {
        public string SubnominalAggregateKeyWithPaymentType { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid Id { get; set; }
    }
}
