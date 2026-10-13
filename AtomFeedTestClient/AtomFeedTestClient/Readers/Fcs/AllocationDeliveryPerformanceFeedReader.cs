namespace AtomFeedTestClient.Readers.Fcs
{
    using System.Configuration;

    public class AllocationDeliveryPerformanceFeedReader : FcsFeedReader
    {
        public override AzureAuthentication AuthenticationCredentials => new AzureAuthentication(
            ConfigurationManager.AppSettings["FCTServices:AADInstance"],
            ConfigurationManager.AppSettings["FCTServices:Tenant"],
            ConfigurationManager.AppSettings["ContractManagementService:ClientId"],
            ConfigurationManager.AppSettings["ContractManagementService:AppKey"],
            ConfigurationManager.AppSettings["FCTServices:ResourceId"]);

        public override string BaseAddress => ConfigurationManager.AppSettings["FCTServicesUrl"];

        public override string MostRecentPageUrl => "/api/allocation-delivery/monitoring/notifications/all";

        public override string VendorAtomMediaType => "application/vnd.sfa.allocation-delivery.allocation-delivery-performance.v1+atom+xml";

        public override string FeedContentDescription => "Allocation Delivery Performance";
    }
}
