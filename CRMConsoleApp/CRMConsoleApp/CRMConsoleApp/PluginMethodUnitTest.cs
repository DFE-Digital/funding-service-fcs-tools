using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMConsoleApp
{
    public class PluginMethodUnitTest
    {

        private const string Contract = "sfa_contract";
        private const string Status = "sfa_status";
        private const string SubStatusNameField = "sfa_name";
        private const string Transition = "sfa_transition";
        private const string TransitionName = "sfa_name";
        private const string NextActionName = "sfa_nextaction";
        private const string SubStatus = "sfa_substatus";
        private const string FTFP_FUNDINGTYPE = "sfa_fundingtypeid";
        private const string FTFP_FUNDINGPERIOD = "sfa_fundingperiodid";
        private const string FTFP_APPROVALTYPE = "sfa_approvaltype";
        private const string CONT_FUNDINGTYPE = "sfa_fundingtype";
        private const string CONT_FUNDINGPERIOD = "sfa_periodid";
        private const string FTFPEntityName = "sfa_fundingtypefundingperiod";
        private const int FTFP_APPROVALTYPE_MANUAL = 229660000;
        private const string INITIATE_MANUAL_PUBLISH_TO_PROVIDER = "Initiate Manual Publish To Provider";

        private string[] givenRoles = new string[] { "System Administrator", "System Customizer" };


        public IOrganizationService myService { get; set; }

        public PluginMethodUnitTest(IOrganizationService service)
        {
            #region IsUserInRole Test
            //var nextActionId = new Guid("{0666AE82-0712-E611-9414-000D3AB03A58}");
            //var contract = service.Retrieve(Contract, new Guid("D649F257-86CE-E511-940E-000D3AB03A58"),
            //    new ColumnSet(SubStatus, CONT_FUNDINGTYPE, CONT_FUNDINGPERIOD));

            //if (nextActionId != Guid.Empty)
            //{
            //    var nextAction = service.Retrieve(Transition, nextActionId, new ColumnSet(TransitionName));

            //    if (contract != null)
            //    {
            //        ApprovalType_NextActionValidation(nextAction, service, contract);

            //    }
            //}


            //var userId = new Guid("{4C8F6610-8BFD-E411-9403-000D3AB03A58}");

            //if (!IsUserInRoles(userId, service,givenRoles))
            //{

            //    Console.WriteLine("User is NOT in Role");
            //}
            //else
            //{
            //    Console.WriteLine("User is in Role");

            //}

            #endregion

            //DisposeExsitingFCR(service);

            //  InitiateBatchCreation(service);

            //BatchUpdateFCR(service);

            myService = service;
        }


        private void ApprovalType_NextActionValidation(Entity nextAction, IOrganizationService service, Entity contract)
        {
            var nextActiontxt = nextAction.GetAttributeValue<string>(TransitionName);

            if (nextActiontxt == INITIATE_MANUAL_PUBLISH_TO_PROVIDER)
            {
                if (contract.Contains(CONT_FUNDINGPERIOD) && contract.Contains(CONT_FUNDINGTYPE))
                {
                    var fundingType = contract.GetAttributeValue<EntityReference>(CONT_FUNDINGTYPE).Id;
                    var fundingPeriod = contract.GetAttributeValue<EntityReference>(CONT_FUNDINGPERIOD).Id;

                    QueryExpression query = new QueryExpression
                    {
                        EntityName = FTFPEntityName,
                        ColumnSet = new ColumnSet(new string[] { FTFP_APPROVALTYPE }),
                        Criteria = new FilterExpression()
                    };

                    query.Criteria.AddCondition(FTFP_FUNDINGPERIOD, ConditionOperator.Equal, fundingPeriod);
                    query.Criteria.AddCondition(FTFP_FUNDINGTYPE, ConditionOperator.Equal, fundingType);

                    var result = (EntityCollection)service.RetrieveMultiple(query);

                    if (result.Entities.Count > 0)
                    {
                        if (result[0].Contains(FTFP_APPROVALTYPE))
                        {
                            if (result[0].GetAttributeValue<OptionSetValue>(FTFP_APPROVALTYPE).Value == FTFP_APPROVALTYPE_MANUAL)
                            {
                               Console.WriteLine("This contract has been restricted to set next action to INITATE MANUAL PUBLISH TO PROVIDER.");
                                Console.Read();

                            }
                        }

                    }
                }


            }
        }
        
       


        private Boolean IsUserInRoles(Guid userId, IOrganizationService service, string[] _givenRoles)
        {
            Boolean isUserInRole = false;

            foreach (string _givenRole in _givenRoles)
            {

                // Find a role.
                QueryExpression query = new QueryExpression
                {
                    EntityName = "role",
                    ColumnSet = new ColumnSet("roleid"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                {

                    new ConditionExpression
                    {
                        AttributeName = "name",
                        Operator = ConditionOperator.Equal,
                        Values = {_givenRole}
                    }
                }
                    }
                };

                EntityCollection givenRoles = service.RetrieveMultiple(query);


                if (givenRoles.Entities.Count > 0)
                {
                    var givenRole = givenRoles.Entities[0];

                   // tracingService.Trace(_givenRole + " - Role Id :" + givenRole.Id.ToString());


                    LinkEntity systemUserLink = new LinkEntity()
                    {
                        LinkFromEntityName = "systemuserroles",
                        LinkFromAttributeName = "systemuserid",
                        LinkToEntityName = "systemuser",
                        LinkToAttributeName = "systemuserid",
                        LinkCriteria =
                {
                    Conditions =
                    {
                        new ConditionExpression(
                            "systemuserid", ConditionOperator.Equal, userId)
                    }
                }
                    };

                    // Build the query.
                    QueryExpression linkQuery = new QueryExpression()
                    {
                        EntityName = "role",
                        ColumnSet = new ColumnSet("roleid"),
                        LinkEntities =
                {
                    new LinkEntity()
                    {
                        LinkFromEntityName = "role",
                        LinkFromAttributeName = "roleid",
                        LinkToEntityName = "systemuserroles",
                        LinkToAttributeName = "roleid",
                        LinkEntities = {systemUserLink}
                    }
                },
                        Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("roleid", ConditionOperator.Equal, givenRole.Id)
                    }
                }
                    };

                    // Retrieve matching roles.
                    EntityCollection matchEntities = service.RetrieveMultiple(linkQuery);

                    // if an entity is returned then the user is a member
                    // of the role
                    isUserInRole = (matchEntities.Entities.Count > 0);

                    if (isUserInRole)
                    {
                        return isUserInRole;
                    }
                }

            }

            return isUserInRole;


        }
        
        private void InitiateBatchCreation(IOrganizationService service)
        {       

            Random rnd = new Random();
            for (int i = 1 ; i <= 200; i++ )
            {
                decimal amount = rnd.Next(-10000, 10000);
                var fcr = new Entity("sfa_fundingclaimreconciliation");
                fcr["sfa_contractallocationnumber"] = "ASC-" + (i).ToString().PadLeft(3, '0');
                fcr["sfa_contractnumber"] = "Main-" + (i).ToString().PadLeft(3, '0');
                fcr["sfa_fundingclaimcollection"] = "1516AY Year-End";
                fcr["sfa_providername"] = "Testing College";
                fcr["sfa_proposedreconciliation"] = amount;
                fcr["sfa_reconciliationamount"] = amount;
                fcr["sfa_ukprn"] = rnd.Next(1, 10000).ToString().PadLeft(8, '0');
                fcr["sfa_statuscode"] = (i < 50) ? new OptionSetValue(229660001) : new OptionSetValue(229660000);
                fcr["sfa_name"] = "Funding Claim Reconciliation Test " + i.ToString();

                service.Create(fcr);
              
            }

            Console.WriteLine("200 FCRs have been created successfully");
        }




        public void UpdateDataTest(IOrganizationService service)
        {

            using (var orgContext = new OrganizationServiceContext(service))
            {
                //var query = from fa in orgContext.CreateQuery("sfa_fcrallocation")
                //            where (Guid)fa["sfa_fundingclaimreconciliationid"] == new Guid("{{43348F6B-EE57-E611-80EA-000D3AB031FE}}")
                //            select fa;

                //foreach (var t in query.ToList())
                //{

                //}

                var fcra = new Entity("sfa_fcrallocation");
                fcra.Id =new Guid("{0272130A-F057-E611-80EA-000D3AB031FE}");
                fcra["sfa_proposedreconciliationvalue"] = 500m;
                fcra["sfa_reconciliationvalue"] = 350m;
                service.Update(fcra);

            }
        
        }

        public void FCRPluginValidationTestDataLoad(IOrganizationService service)
        {
            //create a fcr

            var fcr = new Entity("sfa_fundingclaimreconciliation");
            fcr["sfa_name"] = "Test FCR Record";
           // fcr["sfa_statuscode"] = new OptionSetValue(229660001);
            Guid fcrId = service.Create(fcr);

            //create a fcrallocation
            var fcra = new Entity("sfa_fcrallocation");
            fcra["sfa_name"] = "Test FCR Allocation Record";
            fcra["sfa_fundingclaimreconciliationid"] = new EntityReference("sfa_fundingclaimreconciliation", fcrId);
            Guid fcrAllocationId =service.Create(fcra);


        }


        private void DisposeExsitingFCR(IOrganizationService service)
        {
            using (var context = new CrmOrganizationServiceContext(service))
            {
                var cdCollection =
                   context.CreateQuery("sfa_fundingclaimreconciliation").ToList();

                foreach (var t in cdCollection)
                {
                    service.Delete("sfa_fundingclaimreconciliation", new Guid(t["sfa_fundingclaimreconciliationid"].ToString()));
                }
            }
        }


        private void BatchUpdateFCR(IOrganizationService service)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            using (var context = new CrmOrganizationServiceContext(service))
            {
                var cdCollection =
                   context.CreateQuery("sfa_fundingclaimreconciliation").ToList();

                foreach (var t in cdCollection)
                {
                    var fcr = new Entity("sfa_fundingclaimreconciliation");
                    fcr["sfa_providername"] = "Testing College " + DateTime.Now.ToShortTimeString();
                    fcr["sfa_fundingclaimreconciliationid"] = t["sfa_fundingclaimreconciliationid"];
                     service.Update(fcr);
                }

              
            }
            watch.Stop();

            Console.WriteLine("Total Update Time : " + watch.ElapsedMilliseconds.ToString());
        }


        public void DeleteAllSubnominalAggregations(IOrganizationService _crmService)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //var watch = System.Diagnostics.Stopwatch.StartNew();

            using (var xrmContext = new CrmOrganizationServiceContext(_crmService))
            {


               
                //var subnominals = xrmContext.CreateQuery("sfa_subnominalaggregation").Where(c => (string)c["sfa_subnominalaggregatekey"]== "2303900_ALLC-521_Aug-15").ToList();

                var subnominals = xrmContext.CreateQuery("sfa_subnominalaggregation").Take(5).ToList();

                var multipleRequest = new ExecuteMultipleRequest()
                {
                    // Assign settings that define execution behavior: continue on error, return responses. 
                    Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = true,
                        ReturnResponses = false,
                        
                    },

                    
                    // Create an empty organization request collection.
                    Requests = new OrganizationRequestCollection()
                };

                foreach (var entityRef in subnominals)
                {
                    DeleteRequest deleteRequest = new DeleteRequest { Target = entityRef.ToEntityReference() };
                    multipleRequest.Requests.Add(deleteRequest);
                }

                watch.Restart();

                // Execute all the requests in the request collection using a single web method call.
                ExecuteMultipleResponse multipleResponse = (ExecuteMultipleResponse)_crmService.Execute(multipleRequest);
                watch.Stop();
            }

          

            Console.WriteLine("Total Deletion Time : " + watch.ElapsedMilliseconds.ToString());
            Console.ReadLine();
        }


        public void CreateNotification(IOrganizationService _crmService)
        {
            //in your case it should using 
            Entity notification = new Entity("sfa_notification");
            //type should be using sfa_notificationtype.ClaimReconciliationAllocationAmended  (229660007);
            notification["sfa_notificationtype"] = new OptionSetValue(229660007);
            //sfa_name should be notificationtype + contractnumber + version number  
            notification["sfa_name"] = "Claim Reconciliation Allocation Amended for 1234";
            //the guid will be the teamid for "Claim Editor Team" which need to be retreived
            notification["ownerid"] = new EntityReference("team", new Guid("FBF97217-871E-E611-9414-000D3AB03A58"));
            notification["sfa_notification"] = "This is a test notification for Claim Reconciliation Allocation Amended";


            _crmService.Create(notification);

        }



        public void OneToManyRelationshipTest()
        {
            Entity account = new Entity("account");
            account["contact_customer_accounts"] = GetContactList().ToArray();
            account["name"] = "1TOManyAccountTest";

            myService.Create(account);
        }


        public IEnumerable<Entity> GetContactList()
        {
            var ContactList = new List<Entity>();

            for (int i = 0; i < 3; i++)
            {
                Entity contact = new Entity("contact");
                contact["fullname"] = $"New Contact_{i}";
                ContactList.Add(contact);

               // GetContactList().Where();

            }

            return ContactList;


        }



        public void RetrieveAllRolesForUser(Guid userId)
        {
            using (var orgContext = new OrganizationServiceContext(myService))
            {
                var query = from fa in orgContext.CreateQuery("systemuserroles")
                            where fa.GetAttributeValue<EntityReference>("systemuserid").Id == userId
                            select fa;

                var result = query.ToList();
            }

           }


        public void RetrieveUserRolesExceptBaseUser(Guid userId)
        {
            using (var orgContext = new OrganizationServiceContext(myService))
            {
                var query = from s in orgContext.CreateQuery("systemuserroles")
                            join r in orgContext.CreateQuery("role")
                            on s["roleid"] equals r["roleid"]
                            where s.GetAttributeValue<Guid>("systemuserid") == userId
                            && r.GetAttributeValue<string>("name") != "Base Role"
                            select r;
                               
            }

        }

        public void AssociateRolesForUser(string _givenRole, Guid userId)
        {

            // Find the role.
            QueryExpression query = new QueryExpression
            {
                EntityName = Role.EntityLogicalName,
                ColumnSet = new ColumnSet("roleid"),
                Criteria = new FilterExpression
                {
                    Conditions =
                {

                    new ConditionExpression
                    {
                        AttributeName = "name",
                        Operator = ConditionOperator.Equal,
                        Values = {_givenRole}
                    }
                }
                }
            };

            // Get the role.
            EntityCollection roles = myService.RetrieveMultiple(query);
            if (roles.Entities.Count > 0)
            {
                Role targetRole = myService.RetrieveMultiple(query).Entities[0].ToEntity<Role>();
                var _roleId = targetRole.Id;

                // Associate the user with the role.
                if (_roleId != Guid.Empty && userId != Guid.Empty)
               {
                   myService.Associate(
                                "systemuser",
                                userId,
                                new Relationship("systemuserroles_association"),
                                new EntityReferenceCollection() { new EntityReference("role", _roleId) });                  
                }
            }

        }

        public void DisassociateRolesFromUserExceptBaseRole(Guid userId)
        {
            using (var orgContext = new OrganizationServiceContext(myService))
            {
                var query = from s in orgContext.CreateQuery("systemuserroles")
                            join r in orgContext.CreateQuery("role")
                            on s["roleid"] equals r["roleid"]
                            where s.GetAttributeValue<Guid>("systemuserid") == userId
                            && r.GetAttributeValue<string>("name") != "Base Role"
                            select r;

                foreach (var rl in query.ToList())
                {
                    myService.Disassociate(
                         "systemuser",
                         userId,
                         new Relationship("systemuserroles_association"),
                         new EntityReferenceCollection() { new EntityReference("role", rl.GetAttributeValue<Guid>("roleid")) });

                }
            }
        }



        public Guid RetrieveUserId(string userfullname)
        {
            Guid result = Guid.Empty;
            using (var orgContext = new OrganizationServiceContext(myService))
            {
                var query = from fa in orgContext.CreateQuery("systemuser")
                            where fa.GetAttributeValue<string>("fullname") == userfullname
                            select fa;

                result = query.FirstOrDefault().GetAttributeValue<Guid>("systemuserid");

                return result;
            }

        }

   public EntityCollection GetUserTeams(Guid userId)
        {
            QueryExpression teamQuery = new QueryExpression("team");
            ColumnSet teamColumnSet = new ColumnSet("name");

            teamQuery.ColumnSet = teamColumnSet;
            teamQuery.Criteria = new FilterExpression();
            teamQuery.Criteria.FilterOperator = LogicalOperator.And;
            teamQuery.AddLink("teammembership", "teamid", "teamid").AddLink("systemuser", "systemuserid", "systemuserid").LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, userId);

            EntityCollection teamDetail = myService.RetrieveMultiple(teamQuery);

            return teamDetail;

        }

        public void RemoveMembersFromTeam(List<Entity> teams, Guid membersId)
        {
            foreach (var t in teams)
            {

                // Create the AddMembersTeamRequest object.
                RemoveMembersTeamRequest addRequest = new RemoveMembersTeamRequest();

                // Set the AddMembersTeamRequest TeamID property to the object ID of 
                // an existing team.
                addRequest.TeamId = t.GetAttributeValue<Guid>("teamid");

                // Set the AddMembersTeamRequest MemberIds property to an 
                // array of GUIDs that contains the object IDs of one or more system users.
                addRequest.MemberIds = new Guid[] { membersId };

                // Execute the request.
                myService.Execute(addRequest);
            }

        }

        public void AddMembersToTeam(Entity team, Guid membersId)
        {
          
                // Create the AddMembersTeamRequest object.
                AddMembersTeamRequest addRequest = new AddMembersTeamRequest();

                // Set the AddMembersTeamRequest TeamID property to the object ID of 
                // an existing team.
                addRequest.TeamId = team.GetAttributeValue<Guid>("teamid");
                // Set the AddMembersTeamRequest MemberIds property to an 
                // array of GUIDs that contains the object IDs of one or more system users.
                addRequest.MemberIds = new Guid[] { membersId };

                // Execute the request.
                myService.Execute(addRequest);
            
        }
     
        public List<Entity> GetTeamIdByUserId(List<string> TeamName, Guid userId)
        {
            //get team with
            List<Entity> result = new List<Entity>();
            using (var orgContext = new OrganizationServiceContext(myService))
            {
                var query = from t in orgContext.CreateQuery("team")
                            join tm in orgContext.CreateQuery("teammembership")
                            on t["teamid"] equals tm["teamid"]
                            where (t.GetAttributeValue<string>("name") == TeamName[0] 
                            || t.GetAttributeValue<string>("name") == TeamName[1]
                            || t.GetAttributeValue<string>("name") == TeamName[2]
                            || t.GetAttributeValue<string>("name") == TeamName[3]
                            || t.GetAttributeValue<string>("name") == TeamName[4]
                            || t.GetAttributeValue<string>("name") == TeamName[5])
                            && tm.GetAttributeValue<Guid>("systemuserid") == userId
                            select t;

                result = query.ToList();

                return result;
            }

        }

        public Entity GetTeamIdByTeamNames(string TeamName)
        {
            //get team with
            Entity result = new Entity();
            using (var orgContext = new OrganizationServiceContext(myService))
            {
                var query = from t in orgContext.CreateQuery("team")
                            where (t.GetAttributeValue<string>("name") == TeamName)
                        select t;

                result = query.ToList().FirstOrDefault();

                return result;
            }

        }


        public void LeftoutJointExmaple()
        {

            string fetch2 = @"<fetch version = '1.0' output-format = 'xml-platform' mapping = 'logical' distinct = 'true'>
                   <entity name = 'sfa_subnominalaggregation'>  
                        <all-attributes/>                     
                             <link-entity name = 'sfa_contractdeliverableperiod' from='sfa_reconciliationsubnominal' to='sfa_subnominalaggregationid' alias = 'a1' link-type='outer' >
                             <attribute name = 'sfa_reconciliationsubnominal' />
                            </link-entity>
                           <link-entity name = 'sfa_contractdeliverableperiod' from='sfa_profilesubnominal' to= 'sfa_subnominalaggregationid' alias = 'a2' link-type='outer' >
                             <attribute name = 'sfa_reconciliationsubnominal' />
                           </link-entity>
                              <link-entity name = 'sfa_contractdeliverableperiod' from='sfa_cappingsubnominal' to='sfa_subnominalaggregationid' alias = 'a3' link-type='outer' >
                             <attribute name = 'sfa_reconciliationsubnominal' />
                           </link-entity>
                             <filter type = 'and'>
                                <condition entityname = 'a1' attribute ='sfa_reconciliationsubnominal' operator= 'null' />
                                <condition entityname = 'a2' attribute ='sfa_profilesubnominal' operator= 'null' />
                                <condition entityname = 'a3' attribute ='sfa_cappingsubnominal' operator= 'null' />
                              </filter>
                               </entity>
                             </fetch>";


            EntityCollection result = this.myService.RetrieveMultiple(new FetchExpression(fetch2));

               foreach (var c in result.Entities)
               { System.Console.WriteLine(c.Attributes["sfa_name"]);

                }

        }
        

    }
}
