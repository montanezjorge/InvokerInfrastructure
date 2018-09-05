namespace Invoker.Infrastructure
{
    using MorseCode.ITask;

    public class Invoker<TRequest, TResponse> : Invoker, IInvoker<TRequest, TResponse>
    {
        public Invoker(IInvokerMember root) : base(root)
        {
        }

        public override object Invoke(params object[] parameters)
        {
            return this.Invoke((ITask<TRequest>)parameters[0]);
        }

        public ITask<TResponse> Invoke(ITask<TRequest> request)
        {
            return TaskInterfaceFactory.CreateTask(async () => (TResponse)await (await this.RecursiveInvoke(this.rootInvokerMember, request) as ITask<object>));
        }
    }
}
