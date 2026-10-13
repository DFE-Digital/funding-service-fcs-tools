namespace FCT.Operations.Resend
{
    using System;
    using System.Collections.Generic;
    using SFA.FCT.ContractManagementService.Common.Commands;

    class Program
    {
        private static readonly string[] JsonMessages = new[]
        {
            "{\"MasterContractNumber\":\"SFA-15165\",\"ContractNumber\":\"MAIN-9728\",\"RequestSource\":1,\"ContractVersionNumber\":1}"
        };

        static void Main(string[] args)
        {
            IDictionary<Type, string> typeToEndpointNameMappings = new Dictionary<Type, string>
            {
                {typeof (InitiateContractApprovalCommand), "ContractManagementDomain.InitiateContractApproval"}
            };

            MessageSender<InitiateContractApprovalCommand> messageSender = new MessageSender<InitiateContractApprovalCommand>(
                typeToEndpointNameMappings);

            messageSender.SendMessages(JsonMessages);

            Console.WriteLine("Messages Sent.. press any key to exit");
            Console.ReadKey();
        }
    }
}
