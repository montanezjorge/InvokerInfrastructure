namespace Invoker.Infrastructure
{
    using System;

    public interface IResponse<out TResponse>
    {
        Id CorrelatedRequestId { get; }

        RequestOutcome Outcome {get;}

        DateTime ResponseTime { get; }

        TResponse ResponseContract { get; }
    }
}
