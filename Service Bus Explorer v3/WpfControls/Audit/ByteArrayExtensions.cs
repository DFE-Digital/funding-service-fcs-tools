namespace WpfControls.Audit
{ 
    using System.Linq;
    public static class ByteArrayExtensions
    {
        public static bool IsZipped(this byte[] data)
        {
            byte[] gzipHeaderBytes = new byte[] { 0x1f, 0x8b, 8, 0, 0, 0, 0, 0, 4, 0 };

            if (data != null && data.Length >= gzipHeaderBytes.Length)
            {
                var header = data.Take(gzipHeaderBytes.Length);
                return header.SequenceEqual(gzipHeaderBytes);
            }

            return false;
        }
    }
}
