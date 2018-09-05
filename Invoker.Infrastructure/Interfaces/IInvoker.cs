namespace Invoker.Infrastructure
{
    using MorseCode.ITask;

    public interface IInvoker : IInvokerMember
    {
    }

    public interface IInvoker<in TRequest, out TResponse> : IInvoker
    {
        ITask<TResponse> Invoke(ITask<TRequest> request);
    }

    public interface IInvoker<in TRequest> : IInvoker
    {
        ITask Invoke(ITask<TRequest> request);
    }
}
