namespace Invoker.Infrastructure
{
    public enum OperationStatus
    {
        Queued = 0,
        InProgress = 1,
        Cancelled = 2,
        Success = 3,
        Failed = 4,
    }
}
