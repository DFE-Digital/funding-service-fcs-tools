using Microsoft.Xrm.Client;
using System;
using System.Linq;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using System.IO;

namespace PopulateFSPDDisplayOrder
{
    /// <summary>
    /// This program was written to populate funding stream period deliverable records with a display order that was received in a spreadsheet.
    /// The spreadsheet was imported into an entity named [Temp FSPD Display Order], this program iterated over the [Temp FSPD Display Order] records,
    /// found the corresponding [Funding Stream Period Deliverable] record, and updated the display order field value on it with the value from the
    /// [Temp FSPD Display Order] record
    /// </summary>
    class Program
    {
        private static void Main()
        {
            CrmConnection connection = new CrmConnection("Crm");
            OrganizationService service = new OrganizationService(connection);
            CrmOrganizationServiceContext context = new CrmOrganizationServiceContext(connection);

            // Retrieve pertinent data from all [Temp FSPD Display Order] records
            var tempFundingStreamPeriodDeliverablesQuery = from tempFundingStreamPeriodDeliverable in context.CreateQuery("new_tempfspddisplayorder")
                                                           select new
                                                           {
                                                               FundingStreamPeriodDeliverable = (string)tempFundingStreamPeriodDeliverable["new_fundingstreamperioddeliverable"],
                                                               DeliverableCode = tempFundingStreamPeriodDeliverable["new_deliverablecode"],
                                                               DisplayOrder = tempFundingStreamPeriodDeliverable["new_displayorder"]
                                                           };

            StreamWriter file = new StreamWriter("log.txt", true);

            foreach (var tempFundingStreamPeriodDeliverable in tempFundingStreamPeriodDeliverablesQuery)
            {
                var fundingStreamPeriodDeliverableQuery = (from fundingStreamPeriodDeliverable in context.CreateQuery("sfa_fundingstreamperioddeliverable")
                                                           where fundingStreamPeriodDeliverable["sfa_fundingstreamperiodid"] != null &&
                                                                 fundingStreamPeriodDeliverable["sfa_deliverablecode"] == tempFundingStreamPeriodDeliverable.DeliverableCode
                                                           select new
                                                           {
                                                               Id = (Guid)fundingStreamPeriodDeliverable["sfa_fundingstreamperioddeliverableid"],
                                                               FundingStreamPeriodCode = ((EntityReference)fundingStreamPeriodDeliverable["sfa_fundingstreamperiodid"]).Name,
                                                               DeliverableCode = fundingStreamPeriodDeliverable["sfa_deliverablecode"]
                                                           }).ToList();

                foreach (var fundingStreamPeriodDeliverable in fundingStreamPeriodDeliverableQuery)
                {

                    if (fundingStreamPeriodDeliverable.FundingStreamPeriodCode == tempFundingStreamPeriodDeliverable.FundingStreamPeriodDeliverable)
                    {
                        // Update display order on corresponding FSPD record
                        Entity fundingStreamPeriodDeliverableEntity = new Entity("sfa_fundingstreamperioddeliverable");
                        fundingStreamPeriodDeliverableEntity.Id = fundingStreamPeriodDeliverable.Id;
                        fundingStreamPeriodDeliverableEntity["sfa_setting_displayorder"] = tempFundingStreamPeriodDeliverable.DisplayOrder;

                        service.Update(fundingStreamPeriodDeliverableEntity);

                        // Write output to log file & console
                        string message = string.Format("Updated funding stream period deliverable record with funding stream period code: {0} and deliverable code: {1} to display order: {2}", fundingStreamPeriodDeliverable.FundingStreamPeriodCode, fundingStreamPeriodDeliverable.DeliverableCode, tempFundingStreamPeriodDeliverable.DisplayOrder);

                        file.WriteLine(DateTime.Now + " " + message);
                        Console.WriteLine(message);
                    }

                }
            }

            file.Close();

            Console.WriteLine("All funding stream period deliverable records updated");
            Console.WriteLine("Check the log file for details");
            Console.WriteLine("Press any key to close this application");
            Console.ReadKey();
        }
    }
}
