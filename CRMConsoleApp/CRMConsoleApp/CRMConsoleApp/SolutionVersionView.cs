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
            EnvList.Add(new CRMEnvironment { Name="DEV", Connection = @"Url=http://fct-crm-dev-01.cloudapp.net/FCTDevR2; Username=FCTDEV\fctmega; Password=Pr0j4ct!#" });
            EnvList.Add(new CRMEnvironment { Name = "DAT", Connection = @"Url=http://fct-at-crm-01.cloudapp.net/AcceptanceTestDev; Username=FCTDEV\at-crmintegration; Password=Password@1" });
            EnvList.Add(new CRMEnvironment { Name = "DCI", Connection = @"Url=http://fct-ci-crm-01.cloudapp.net/ContinuousIntegrationDev; Username=FCTDEV\ci-crmintegration; Password=Password@1" });
            EnvList.Add(new CRMEnvironment { Name = "AT", Connection = @"Url=http://fct-at-crm-01.cloudapp.net/AcceptanceTest; Username=FCTDEV\at-crmintegration; Password=Password@1" });
            EnvList.Add(new CRMEnvironment { Name = "CI", Connection = @"Url=http://fct-ci-crm-01.cloudapp.net/ContinuousIntegration; Username=FCTDEV\ci-crmintegration; Password=Password@1" });


            // EnvList.Add(new CRMEnvironment { Name = "DOAT", Connection = @"Url=https://fcs-pp-crmw.preprod.fcs.sfa.bis.gov.uk/skillsfundingagencyDOAT; Username=fcspreprod\CRMIntegration; Password=Pa55w0rd!" });


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
