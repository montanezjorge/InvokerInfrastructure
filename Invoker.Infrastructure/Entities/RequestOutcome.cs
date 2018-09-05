namespace Invoker.Infrastructure
{
    public class RequestOutcome
    {
        public OperationStatus Status { get; set; }

        public OutcomeDescription Description { get; set; }
    }
}
