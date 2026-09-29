namespace WpfControls.Audit
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Input;

    public class AuditMessage
    {
        private AuditMessage()
        {
        }

        public AuditMessage(
            byte[] messageBytes,
            string messageType,
            DateTime sentTime,
            Guid messageId,
            string originatingEndpoint,
            string processingEndpoint,
            string businessKey,
            byte[] propertiesBytes)
        {
            MessageBytes = messageBytes;
            MessageType = messageType;
            SentTime = sentTime;
            MessageId = messageId;
            OriginatingEndpoint = originatingEndpoint;
            ProcessingEndpoint = processingEndpoint;
            BusinessKey = businessKey;
            PropertiesBytes = propertiesBytes;
        }

        public Guid MessageId { get; private set; }

        /// <summary>
        /// this is a a fully qualified type name
        /// </summary>
        public string MessageType { get; private set; }

        public DateTime SentTime { get; private set; }

        public string OriginatingEndpoint { get; private set; }

        public string ProcessingEndpoint { get; private set; }

        public string BusinessKey { get; private set; }

        public byte[] MessageBytes { get; private set; }

        public byte[] PropertiesBytes { get; private set; }

        public string MessageAsJson
        {
            get
            {
                byte[] unzippedBytes = GetUnZippedBytes(MessageBytes);

                return GetStringFromBytes(unzippedBytes);
            }
        }

        public string MessagePropertiesAsJson
        {
            get
            {
                var strDictionaryItems = GetPropertiesDictionary().Select(e => $"{e.Key}: {e.Value}");

                return string.Join(System.Environment.NewLine, strDictionaryItems);
            }
        }

        public string MessageTypeClassOnly
        {
            get
            {
                var namespaceParts = MessageType.Split('.');
                if (namespaceParts.Length > 0)
                {
                    return MessageType.Split('.').Last();
                }

                return MessageType;
            }
        }

        private IDictionary<string, object> GetPropertiesDictionary()
        {
            var dictionary = ConvertByteArrayToObject<Dictionary<string, object>>(PropertiesBytes);

            return dictionary;
        }

        private static byte[] GetUnZippedBytes(byte[] messageBytes)
        {
            if (messageBytes.IsZipped())
            {
                using (GZipStream bigStream = new GZipStream(new MemoryStream(messageBytes), CompressionMode.Decompress))
                {
                    MemoryStream unZippedStream = new MemoryStream();
                    bigStream.CopyToAsync(unZippedStream).Wait();

                    return unZippedStream.ToArray();
                }
            }

            return messageBytes;
        }

        private static string GetStringFromBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static T ConvertByteArrayToObject<T>(byte[] bytes)
        {
            MemoryStream memorystream = new MemoryStream(bytes);
            BinaryFormatter bfd = new BinaryFormatter();
            T deserializedResult = (T)bfd.Deserialize(memorystream);
            return deserializedResult;
        }
    }
}
