using Microsoft.Xrm.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.IO;

using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Client.Services;

namespace CRMConsoleApp
{
    public class SolutionVersionView
    {
        public static List<CRMEnvironment> EnvList;

        public static void ShowVersionsByEnv()
        {
            EnvList = new List<CRMEnvironment>();
            EnvList.Add(new CRMEnvironment { Name="DEV", Connection = "" });
            EnvList.Add(new CRMEnvironment { Name = "DAT", Connection = "" });
            EnvList.Add(new CRMEnvironment { Name = "DCI", Connection = "" });
            EnvList.Add(new CRMEnvironment { Name = "AT", Connection = "" });
            EnvList.Add(new CRMEnvironment { Name = "CI", Connection = "" });


            // EnvList.Add(new CRMEnvironment { Name = "DOAT", Connection = "" });


            foreach (var env in EnvList)
            {
                GetVersion(env);

            }

            Console.ReadLine();


        }

        public static void GetVersion(CRMEnvironment env)
        {
            // Retrieve a solution
            String solutionUniqueName = "CIBERSFAFCTSolution";

            CrmConnection connection = CrmConnection.Parse(env.Connection);

            var _serviceProxy = new OrganizationService(connection);

            QueryExpression querySampleSolution = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet(new string[] { "publisherid", "installedon", "version", "versionnumber", "friendlyname" }),
                Criteria = new FilterExpression()
            };

            querySampleSolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solutionUniqueName);
            Entity targetSolution = (Entity)_serviceProxy.RetrieveMultiple(querySampleSolution).Entities[0];
            Console.WriteLine(string.Format("Env : {0} - Version : {1} - SolutionId : {2} ", env.Name, targetSolution["version"].ToString(),targetSolution["solutionid"].ToString()));
           
        }


    }




    public class CRMEnvironment
    {
        public string Name { get; set; }
        public string Connection { get; set; }

        public string Version { get; set; }

    }
}
