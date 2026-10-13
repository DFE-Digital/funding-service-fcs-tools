namespace FCT.Operations.Resend
{
    using System;
    using System.Collections.Generic;
    using NServiceBus;
    using SFA.FCT.CrossDomain.Integration.Common;
    public static class BusFactory<TCommand>
    {
        public static ISendOnlyBus CreateBus(IDictionary<Type, string> typeToEndpointNameMappings)
        {
            var configuration = new BusConfiguration();
            
            configuration.AssembliesToScan(
                AllAssemblies.Matching(typeof(TCommand).Assembly.ManifestModule.Name)
                .And("Microsoft.WindowsAzure.Configuration.dll")
                .And("NServiceBus.Azure.Transports.WindowsAzureServiceBus.dll"));

            configuration.UseTransport<AzureServiceBusTransport>();
            //configuration.UseTransport<MsmqTransport>();
            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.DiscardFailedMessagesInsteadOfSendingToErrorQueue();
            configuration.Conventions()
                 .DefiningCommandsAs(t => t == typeof (TCommand));
               
            configuration.CustomConfigurationSource(new CustomConfigurationProvider(typeToEndpointNameMappings));

            return Bus.CreateSendOnly(configuration);
        }
    }
}
