namespace AtomFeedTestClient.Readers
{
    using System;

    public interface IFeedReader
    {
        string BaseAddress { get; }

        string FeedContentDescription { get; }

        string ContentTypeFileSuffix { get; }

        void Read(Action<int, string> writePage);
    }
}
