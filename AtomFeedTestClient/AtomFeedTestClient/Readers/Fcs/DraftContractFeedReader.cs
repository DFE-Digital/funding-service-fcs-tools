namespace AtomFeedTestClient.Readers.Fcs
{
    using System.Configuration;

    public class DraftContractFeedReader : FcsFeedReader
    {
        public override AzureAuthentication AuthenticationCredentials => new AzureAuthentication(
            ConfigurationManager.AppSettings["FCTServices:AADInstance"],
            ConfigurationManager.AppSettings["FCTServices:Tenant"],
            ConfigurationManager.AppSettings["ContractManagementService:ClientId"],
            ConfigurationManager.AppSettings["ContractManagementService:AppKey"],
            ConfigurationManager.AppSettings["FCTServices:ResourceId"]);

        public override string BaseAddress => ConfigurationManager.AppSettings["FCTServicesUrl"];

        public override string MostRecentPageUrl => "/api/contracts/notifications/draft";

        public override string VendorAtomMediaType => "application/vnd.sfa.contract.v1+atom+xml";

        public override string FeedContentDescription => "Draft Contracts";
    }
}
