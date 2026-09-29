using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Linq;
using System.Net;

namespace FeatureFileParser
{
    internal class TfsHelper
    {
        public static WorkItemStore GetTFSProject(Uri serverUrl, NetworkCredential tfsCredentials)
        {
            var configurationServer = new TfsConfigurationServer(serverUrl, tfsCredentials);

            var defaultCollection = FindDefaultCollection(configurationServer);
            if (defaultCollection == null)
            {
                throw new InvalidOperationException("Could not find default collection");
            }

            var tpc = configurationServer.GetTeamProjectCollection(
                    new Guid(defaultCollection.Resource.Properties["InstanceId"]));

            return (WorkItemStore)tpc.GetService(typeof(WorkItemStore));
        }

        public static  WorkItem GetItem(string projectName, int id, WorkItemStore workItemStore)
        {
            WorkItemCollection workItemCollection = workItemStore.Query(
             " SELECT [System.Id], [System.WorkItemType]," +
             " [System.State], [System.AssignedTo], [System.Title] " +
             " FROM WorkItems " +
             " WHERE [System.TeamProject] = '" + projectName + "' AND [System.Id] = '" + id + "'");

            WorkItem result = null;
            if (workItemCollection.Count > 0)
            {
                result = workItemCollection[0];
            }
            return result;
        }

        private static CatalogNode FindDefaultCollection(TfsConfigurationServer configurationServer)
        {
            var collectionNodes = configurationServer.CatalogNode.QueryChildren(
                            new[] { CatalogResourceTypes.ProjectCollection },
                            false, CatalogQueryOptions.None);

            var defaultCollection = collectionNodes
                .Where(cn => cn.Resource.DisplayName == "DefaultCollection")
                .First();
            return defaultCollection;
        }

    }
}
