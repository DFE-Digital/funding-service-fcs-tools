using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SummarisedActuals.Client.DedsSearchService;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SummarisedActuals.Client
{
    public class Client
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _searchEndpointConfiguration = ConfigurationManager.AppSettings["SearchEndpointConfigurationName"];
        private readonly string _summarisedActualsDataSetCode = ConfigurationManager.AppSettings["SummarisedActualsDataSetCode"];
        
        private int _pageNumberOut;
        private int _pageSizeOut;
        private int _optionOut;

        private QueryDescriptor _getClosedCollectionEvents;
        private QueryDescriptor _getSummarisedActualsCount;
        private QueryDescriptor _getSummarisedActuals;

        private IList<QueryResults> _results;

        public void Execute()
        {
            GetQueries();

            GetQueryOptionsText();
           
            string option = Console.ReadLine(); 
            
            if (int.TryParse(option, out _optionOut))
            {
                switch (_optionOut)
                {
                    case 1:
                        GetClosedCollectionEvents();
                        break;
                    case 2:
                        GetSummarisedActualsCount();
                        break;
                    case 3:
                        GetSummarisedActuals();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        private void GetQueries()
        {
            using (var client = new DedsSearchServiceClient(_searchEndpointConfiguration))
            {
                var dataSetVersionDescriptor = client.GetLatestPublishedDataSetVersion(_summarisedActualsDataSetCode);

                var queryDescriptors = client.DiscoverQueries(new DiscoverQueriesCriteria() { DataSetVersionId = dataSetVersionDescriptor.Id });

                _getClosedCollectionEvents = queryDescriptors.First(qd => qd.Code == "GetClosedCollectionEvents");
                _getSummarisedActualsCount = queryDescriptors.First(qd => qd.Code == "GetSummarisedActualsCount");
                _getSummarisedActuals = queryDescriptors.First(qd => qd.Code == "GetSummarisedActuals");
            }
        }
        
        private void ExecuteQuery(QueryDescriptor queryDescriptor, QueryExecution queryExecution)
        {
            Logger.Info("Process Started");

            using (var client = new DedsSearchServiceClient(_searchEndpointConfiguration))
            {
               _results = client.ExecuteQuery((Guid)queryDescriptor.Id, queryExecution);
            }
        }

        #region Queries

        public void GetClosedCollectionEvents()
        {
            List<FilterValue> filterValues = GetQueryFilterValues(_getClosedCollectionEvents);

            var queryExecution = new QueryExecution
            {
                FilterValues = filterValues.Where(x => !string.IsNullOrEmpty(x.FieldValue)).ToArray(),
                SortValues = new SortValue[0]
            };
            
            ExecuteQuery(_getClosedCollectionEvents, queryExecution);
            
            OutputQueryResults();

            FinishQuery();
        }

        public void GetSummarisedActualsCount()
        {
            var filterValues = GetQueryFilterValues(_getSummarisedActualsCount);

            var queryExecution = new QueryExecution
            {
                FilterValues = filterValues.Where(x => !string.IsNullOrEmpty(x.FieldValue)).ToArray(),
                SortValues = new SortValue[0],
            };

            ExecuteQuery(_getSummarisedActualsCount, queryExecution);
               
            OutputQueryResults();

            FinishQuery();
        }

        public void GetSummarisedActuals()
        {
            var filterValues = GetQueryFilterValues(_getSummarisedActuals);

            GetPageNumber();
            GetPageSize();

            var queryExecution = new QueryExecution
            {
                FilterValues = filterValues.Where(x => !string.IsNullOrEmpty(x.FieldValue)).ToArray(),
                SortValues = new SortValue[0],
                PageSize = _pageSizeOut,
                PageNumber = _pageNumberOut,
            };

            ExecuteQuery(_getSummarisedActuals, queryExecution);
            
            OutputQueryResults();

            FinishQuery();
        }

        #endregion

        #region Command Line

        private void GetQueryOptionsText()
        {
            Console.WriteLine("1 - GetClosedCollectionEvents - Query Id : {0}", _getClosedCollectionEvents.Id);
            Console.WriteLine("2 - GetSummarisedActualsCount - Query Id : {0}", _getSummarisedActualsCount.Id);
            Console.WriteLine("3 - GetSummarisedActuals - Query Id : {0}", _getSummarisedActuals.Id);
            Console.WriteLine("Choose option by enterting 1 to 3 and press Enter");
        }

        private void GetPageNumber()
        {
            while (true)
            {
                Console.WriteLine("Page Number : ");
                string pageNumber = Console.ReadLine();

                if (!int.TryParse(pageNumber, out _pageNumberOut))
                {
                    continue;
                }
                break;
            }
        }

        private void GetPageSize()
        {
            while (true)
            {
                Console.WriteLine("Page Size : ");
                string pageSize = Console.ReadLine();

                if (!int.TryParse(pageSize, out _pageSizeOut))
                {
                    continue;
                }
                break;
            }
        }

        private List<FilterValue> GetQueryFilterValues(QueryDescriptor queryDescriptor)
        {
            var queryFilterValues = new Dictionary<string, string>();

            foreach (var filter in queryDescriptor.FilterDescriptors)
            {
                Console.WriteLine("Enter {0} - {1}", filter.FieldName, (bool)filter.IsRequired ? "Required" : "Optional");
                queryFilterValues.Add(filter.FieldName, Console.ReadLine());
            }

            var filterValues = new List<FilterValue>();

            filterValues.AddRange(queryFilterValues.Select(queryFilterValue => new FilterValue
            {
                FieldName = queryFilterValue.Key,
                FieldValue = queryFilterValue.Value
            }));

            return filterValues;
        }

        private void OutputQueryResults()
        {
            foreach (var result in _results[0].Results)
            {
                var fieldscount = _results[0].FieldNames.Length;
                for (var i = 0; i < fieldscount; i++)
                {
                    Logger.Info(string.Format("{0}:{1}", _results[0].FieldNames[i], result[i]));
                }

                Logger.Info("========================================================");
            }
        }

        private void FinishQuery()
        {
            Logger.Info("Process Completed");
            Console.WriteLine("Press any key to start a new query");
            Console.ReadLine();
        }

        #endregion
    }
}
