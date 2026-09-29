namespace ExtractAuditMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBodyExtractor messageExtractor = new MessageBodyExtractor("Audit");
            messageExtractor.GetMessageBodiesForMessageType("PaymentAggregatedEvent");
        }
    }
}
