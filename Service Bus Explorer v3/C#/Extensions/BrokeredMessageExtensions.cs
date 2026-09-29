namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Extensions
{
    using System;
    using System.IO;
    using System.Linq;
    using ServiceBus.Messaging;

    public static class BrokeredMessageExtensions
    {
        public static byte[] GetBytes(this BrokeredMessage message)
        {
            byte[] messageBytes = null;
            try
            {
                messageBytes = message.GetBody<byte[]>();
            }
            catch (Exception)
            {
                // ignored
            }

            // for NSB 7.1.4 the above code is good, after that you need the code below
            if (messageBytes == null)
            {
                var messageBodyStream = message.GetBodyStream();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    messageBodyStream.CopyTo(memoryStream);
                    messageBytes = memoryStream.ToArray();
                    if (messageBytes.Length > 2)
                    {
                        // there is some kind of header at the start (2 bytes) which we don't want
                        messageBytes = messageBytes.Skip(2).ToArray();
                    }
                }
            }

            return messageBytes;
        }
    }
}
