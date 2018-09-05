namespace Invoker.Infrastructure
{
    using System;

    public interface IRequest<out TRequest>
    {
        Id RequestId { get; }
        TRequest RequestContract { get; }

        DateTime RequestTime { get; }
    }
}
