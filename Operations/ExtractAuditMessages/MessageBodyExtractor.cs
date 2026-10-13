namespace ExtractAuditMessages
{
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    public class MessageBodyExtractor
    { 
        private readonly string _queueName;

        public MessageBodyExtractor(string queueName)
        {
            _queueName = queueName;
        }

        public IList<string> GetMessageBodiesForMessageType(string messageType)
        {
            QueueClient queueClient = CreateQueueClient(_queueName);
            long queueCount = CreateNamespaceManager().GetQueue(_queueName).MessageCount;
            IList<string> messageBodies = new List<string>();
            const string nserviceBusMessageTypeKey = "NServiceBus.EnclosedMessageTypes";
            const string iWasCompressedKey = "IWasCompressed";
            for (long i = 0; i < queueCount; i++)
            {
                BrokeredMessage message = queueClient.Peek();
                if (message.Properties.ContainsKey(nserviceBusMessageTypeKey))
                {
                    bool isCompressed = message.Properties.ContainsKey(iWasCompressedKey);
                    string propertyValue = message.Properties[nserviceBusMessageTypeKey] as string;
                    if (propertyValue != null && propertyValue.Contains("Command"))
                    {
                        string body = GetMessageBody(message, isCompressed);
                         
                        messageBodies.Add(body);
                    }
                }
            }

            return messageBodies;
        }

        
        private string GetMessageBody(BrokeredMessage brokeredMessage, bool isCompressed)
        {
            var body = brokeredMessage.GetBody<byte[]>();

            if (isCompressed)
            {
                body = UncompressByteArray(body);

            }
            return Encoding.UTF8.GetString(body);
        }

        private byte[] UncompressByteArray(byte[] compressedBytes)
        {
            using (GZipStream bigStream = new GZipStream(new MemoryStream(compressedBytes), CompressionMode.Decompress))
            {
                MemoryStream bigStreamOut = new MemoryStream();
                bigStream.CopyTo(bigStreamOut);
                return bigStreamOut.ToArray();
            }
        }

        private NamespaceManager CreateNamespaceManager()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString;

            return NamespaceManager.CreateFromConnectionString(connectionString);
        }

        private QueueClient CreateQueueClient(string queueName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString;

            return QueueClient.CreateFromConnectionString(connectionString, queueName);
        }
    }
}
