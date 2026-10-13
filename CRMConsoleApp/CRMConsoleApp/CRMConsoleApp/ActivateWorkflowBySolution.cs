using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMConsoleApp
{
    public class ActivateWorkflowBySolution
    {

        public static void ActivateWorkflow(IOrganizationService service)
        {

           var workflowlist = getSolutionEntities("CIBERSFAFCTSolution", service);

            //Publish Workflows
            QueryExpression workflowQuery = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression()
            };

            foreach (Entity workflow in workflowlist.ToList())
            {
                var activateRequest = new SetStateRequest
                {
                    EntityMoniker = new EntityReference
                        (workflow.LogicalName, workflow.Id),
                    State = new OptionSetValue(1),
                    Status = new OptionSetValue(2)
                };
               service.Execute(activateRequest);
            }

        }


        public static IEnumerable<Entity> getSolutionEntities(string SolutionUniqueName, IOrganizationService Service)
        {
            // get solution components for solution unique name
            QueryExpression componentsQuery = new QueryExpression
            {
                EntityName = "solutioncomponent",
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression(),
            };
            LinkEntity solutionLink = new LinkEntity("solutioncomponent", "solution", "solutionid", "solutionid", JoinOperator.Inner);
            solutionLink.LinkCriteria = new FilterExpression();
            solutionLink.LinkCriteria.AddCondition(new ConditionExpression("uniquename", ConditionOperator.Equal, SolutionUniqueName));
            componentsQuery.LinkEntities.Add(solutionLink);
            componentsQuery.Criteria.AddCondition(new ConditionExpression("componenttype", ConditionOperator.Equal, 29));
            EntityCollection ComponentsResult = Service.RetrieveMultiple(componentsQuery);

            //Publish Workflows
            QueryExpression workflowQuery = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression()
            };

            //activate workflow and action
            int [] values = new int[] { 0, 3 };
            ConditionExpression condition1 = new ConditionExpression("statecode", ConditionOperator.Equal, 0);
            ConditionExpression condition2 = new ConditionExpression("category", ConditionOperator.In, values);
            ConditionExpression condition3 = new ConditionExpression("type", ConditionOperator.Equal, 1);
            ConditionExpression condition4 = new ConditionExpression("rendererobjecttypecode", ConditionOperator.Null);
            workflowQuery.Criteria.AddCondition(condition1);
            workflowQuery.Criteria.AddCondition(condition2);
            workflowQuery.Criteria.AddCondition(condition3);
            workflowQuery.Criteria.AddCondition(condition4);
            var workflows = Service.RetrieveMultiple(workflowQuery);

                       //Join entities Id and solution Components Id 
            return workflows.Entities.Join(ComponentsResult.Entities.Select(x => x.Attributes["objectid"]), x => x.Id, y => y, (x, y) => x);
        }


    }



}
