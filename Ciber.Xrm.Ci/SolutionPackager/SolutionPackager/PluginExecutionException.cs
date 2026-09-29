namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class PluginExecutionException : Exception
    {
        internal string PluginName { get; set; }

        public PluginExecutionException()
        {
        }

        public PluginExecutionException(string message)
            : base(message)
        {
        }

        public PluginExecutionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PluginName", PluginName);
            base.GetObjectData(info, context);
        }
    }
}
