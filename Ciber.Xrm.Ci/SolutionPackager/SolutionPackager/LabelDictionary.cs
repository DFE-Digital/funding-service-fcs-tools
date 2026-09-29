namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class LabelDictionary : Dictionary<int, Label>
    {
        private LabelDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
