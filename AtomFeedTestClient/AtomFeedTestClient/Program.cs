namespace AtomFeedTestClient
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Readers;
    using Readers.Cfs;
    using Readers.Fcs;

    class Program
    {
        private static readonly Dictionary<string, Type> FeedReaders = new Dictionary<string, Type>
        {
            { "ALLOCATIONDELIVERYPERFORMANCE", typeof(AllocationDeliveryPerformanceFeedReader) },
            { "ALLCONTRACT", typeof(AllContractFeedReader) },
            { "APPROVALONWARDSCONTRACT", typeof(ApprovalOnwardsContractFeedReader) },
            { "APPROVEDCONTRACT", typeof(ApprovedContractFeedReader) },
            { "DELIVERABLESETTINGCONFIGURATION", typeof(DeliverableSettingConfigurationFeedReader) },
            { "DRAFTCONTRACT", typeof(DraftContractFeedReader) },
            { "FUNDINGCLAIMRECONCILIATION", typeof(FundingClaimReconciliationFeedReader) },
            { "PAYMENTBATCH", typeof(PaymentBatchFeedReader) },
            { "ALLOCATIONNOTIFICATION", typeof(AllocationNotificationFeedReader) }
        };

        static void Main(string[] args)
        {
            if (args.Any())
            {
                string option = ExtractOption(args[0]).ToUpper();

                if (FeedReaders.ContainsKey(option))
                {
                    IFeedReader reader = (IFeedReader)Activator.CreateInstance(FeedReaders[option]);
                    ExecuteFeedReader(reader);
                }
                else
                {
                    RenderHelp();
                }
            }
            else
            {
                RenderHelp();
            }

            if (Debugger.IsAttached)
            {
                Console.Out.WriteLine();
                Console.Out.WriteLine("Press any key to exit");
                Console.ReadKey(false);
            }
        }

        private static string ExtractOption(string arg)
        {
            if (arg.StartsWith("/") || arg.StartsWith("-"))
            {
                return arg.Substring(1);
            }

            return arg;
        }

        private static void RenderHelp()
        {
            Console.Out.WriteLine("Atom feed test client.");
            Console.Out.WriteLine();
            Console.Out.WriteLine("Usage: AtomFeedTestClient FEEDNAME");
            Console.Out.WriteLine();
            Console.Out.WriteLine("Available feeds:");
            FeedReaders.Keys
                .ToList()
                .ForEach(k => Console.Out.WriteLine($"\t{k}"));
        }

        private static void ExecuteFeedReader(IFeedReader reader)
        {
            Console.Out.WriteLine($"Reading feed for {reader.FeedContentDescription} from {reader.BaseAddress}");

            try
            {
                string executionRunUid = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

                var timingMessage = "Reading latest page start    - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-fff");
                WriteLatestPageTiming(executionRunUid, reader.FeedContentDescription, 0, timingMessage);

                reader.Read((pageNumber, pageContent) =>
                {
                    timingMessage = "Reading latest page complete - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-fff");
                    WriteLatestPageTiming(executionRunUid, reader.FeedContentDescription, pageNumber, timingMessage);

                    WriteFeedPageToDisk(executionRunUid, reader.FeedContentDescription, pageNumber, pageContent, reader.ContentTypeFileSuffix);
                    Console.Out.WriteLine(pageNumber == 0 ? "Written latest page to disk " : $"Written page {pageNumber} to disk");

                });
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.InnerException?.Message);
                Console.ResetColor();
            }
        }

        private static void WriteLatestPageTiming(string runUid, string feedContentDescription, int pageNumber, string timingMessage)
        {
            if (pageNumber == 0)
            {
                var fileInfo = new FileInfo($"Output {runUid}\\{feedContentDescription}\\latestPageTiming_{runUid}.txt");
                fileInfo.Directory?.Create();
                File.AppendAllText(fileInfo.FullName, timingMessage + Environment.NewLine);
                Console.WriteLine(timingMessage);
            }
        }

        private static void WriteFeedPageToDisk(string runUid, string feedContentDescription, int pageNumber, string pageContent, string fileExtension)
        {
            string fileName = pageNumber == 0 ? "latest" : $"{pageNumber:D3}";
            FileInfo fileInfo = new FileInfo($"Output {runUid}\\{feedContentDescription}\\{fileName}.{fileExtension}");
            fileInfo.Directory?.Create();
            File.WriteAllText(fileInfo.FullName, pageContent);
        }
    }
}
