namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.Diagnostics.Contracts;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;

    public class XrmErrorParser
    {
        public static string Parse(Exception exception)
        {
            Contract.Requires(exception != null);

            var message = "System error: " + exception.Message;
            if (exception.InnerException == null) return message;

            var innerXrm = exception.InnerException as FaultException<OrganizationServiceFault>;
            if (innerXrm != null)
            {
                message += ", XRM error: " + innerXrm.Detail.Message;
            }
            else
            {
                message += ", Inner fault: " + exception.InnerException.Message;
            }

            return message;
        }
    }
}
