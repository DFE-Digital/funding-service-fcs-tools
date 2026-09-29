using System;
namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Extensions
{
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;

    public static class ByteArrayExtensions
    {
        public static bool IsZipped(this byte[] data)
        {
            byte[] gzipHeaderBytes = new byte[] { 0x1f, 0x8b, 8, 0, 0, 0, 0, 0, 4, 0 };
            byte[] gzipHeaderBytesAlt = new byte[] { 0x1f, 0x8b, 8, 0, 0, 0, 0, 0, 0, 10 }; // GZipStream from .net core has a different header

            if (data != null && data.Length >= gzipHeaderBytes.Length)
            {
                var header = data.Take(gzipHeaderBytes.Length);
                return header.SequenceEqual(gzipHeaderBytes) || header.SequenceEqual(gzipHeaderBytesAlt);
            }

            return false;
        }

        public static bool IsStringInBytes(this byte[] bytes)
        {
            return bytes[0] == 0x40 && bytes[1] == 0x0C && bytes[14] == 0x08 && bytes[15] == 0x33;
        }

        public static string DecompressBytesThenToString(this byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(bytes, 0);
                ms.Write(bytes, 0, bytes.Length);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                int length;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    length = zip.Read(buffer, 0, buffer.Length);
                }

                var data = new byte[length];
                Array.Copy(buffer, data, length);
                return Encoding.UTF8.GetString(data);
            }
        }
    }
}
