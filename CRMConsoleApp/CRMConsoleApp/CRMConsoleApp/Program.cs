using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;

namespace CRMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            CrmConnection connection = new CrmConnection("Crm");
            var service = new OrganizationService(connection);

            #region SyncAllocation

            //Sync AllocationRef Appp

            //SyncAllocationRef a = new SyncAllocationRef();
            //a.ProcessUpdate(service);
            // Console.Read();

            #endregion


            //Solutoin Version Check App
            //SolutionVersionView.ShowVersionsByEnv();
            //  ActivateWorkflowBySolution.ActivateWorkflow(service);

            PluginMethodUnitTest ut = new PluginMethodUnitTest(service);

            ut.LeftoutJointExmaple();

            //ut.DeleteAllSubnominalAggregations(service);


            //ut.OneToManyRelationshipTest();
            // ut.CreateNotification(service);

            // ut.FCRPluginValidationTestDataLoad(service);
            //ut.UpdateDataTest(service);
            var userId = ut.RetrieveUserId("Paul Lai");
            //  ut.RetrieveAllRolesForUser(userId);
           // ut.RetrieveUserRolesExceptBaseUser(userId);

          //  ut.DisassociateRolesFromUserExceptBaseRole(userId);

           // ut.AssociateRolesForUser("Contract Adviser", userId);

           // ut.GetUserTeams(userId);


            //#region "Remove following team" for given user

            //List<string> TeamList = new List<string>();
            //TeamList.Add("Contract Advisers Team");
            //TeamList.Add("Contract Managers Team");
            //TeamList.Add("Document management Team");
            //TeamList.Add("FCS Support Team");
            //TeamList.Add("Lead Manager Team");
            //TeamList.Add("User Access Manager Team");
        
            //var removelist = ut.GetTeamIdByUserId(TeamList, userId);
            //ut.RemoveMembersFromTeam(removelist, userId);

            //#endregion


            //#region "Add memeber to certain team"
            //List<string> AddList = new List<string>();
            //TeamList.Add("Contract Advisers Team");

            //foreach (var tname in AddList)
            //{
            //    var tm = ut.GetTeamIdByTeamNames(tname);
            //    ut.AddMembersToTeam(tm, userId);
            //}

            //#endregion
        }




    }
    }
