namespace FCT.Operations.Resend
{
    using System;
    using System.Collections.Generic;
    using MoreLinq;
    using Newtonsoft.Json;
    using NServiceBus;

    public class MessageSender<TCommand> : IDisposable
    {
        private readonly IDictionary<Type, string> _typeToEndpointNameMappings;
        private ISendOnlyBus _sendOnlyBus;

        public MessageSender(IDictionary<Type, string> typeToEndpointNameMappings)
        {
            _typeToEndpointNameMappings = typeToEndpointNameMappings;
        }

        public void SendMessages(string[] jsonMessages)
        {
            jsonMessages.ForEach(SendMessage);
        }

        public void Dispose()
        {
            Bus?.Dispose();
        }

        private ISendOnlyBus Bus
        {
            get
            {
                if (_sendOnlyBus == null)
                {
                    _sendOnlyBus = BusFactory<TCommand>.CreateBus(_typeToEndpointNameMappings);
                }

                return _sendOnlyBus;
            }
        }

        private void SendMessage(string jsonMessage)
        {
            TCommand command = JsonConvert.DeserializeObject<TCommand>(jsonMessage);

            Bus.Send(command);
        }
    }
}
