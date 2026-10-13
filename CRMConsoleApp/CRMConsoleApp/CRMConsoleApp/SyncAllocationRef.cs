using Microsoft.Xrm.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.IO;
using Microsoft.Xrm.Sdk.Client;

namespace CRMConsoleApp
{
     public class SyncAllocationRef
    {
         static readonly StreamWriter File = new StreamWriter("log.txt", true);
         public SyncAllocationRef()
         {
         }



         public void ProcessUpdate(IOrganizationService service)
         {

           
       
             using (var context = new CrmOrganizationServiceContext(service))
             {
                 var cdCollection =
                     context.CreateQuery("sfa_contractdeliverable")
                         .Where(c => c["sfa_allocationref"] == null && c["sfa_contractallocationid"] != null).ToList();
                 
                 
                 //Console.WriteLine(cdCollection.Count);

                 File.WriteLine(DateTime.Now + "Start to process total " + cdCollection.Count.ToString() + " Contract Deliverable Records");
                 
                 foreach (var t in cdCollection)
                 {
                     t["sfa_allocationref"] = ((EntityReference)t["sfa_contractallocationid"]).Name;
                     context.UpdateObject(t);
                     Console.WriteLine("AlloRef for CD: " + t["sfa_deliverablename"] + "updated to " + t["sfa_allocationref"]);
                 
                 // Write output to log File & console
                 
                 string message =
                     string.Format("Allocation Ref {0} has been populated for Contract deliverable {1} - Guid : {2} ",
                         t["sfa_allocationref"],
                         t["sfa_deliverablename"],
                         t["sfa_contractdeliverableid"]);

                 File.WriteLine(DateTime.Now + " " + message);
                 }

                 context.SaveChanges();
             }

          

             File.Close();

         }
    }
}
