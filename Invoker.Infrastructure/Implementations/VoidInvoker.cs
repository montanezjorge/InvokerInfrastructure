namespace Invoker.Infrastructure.Implementations
{
    using MorseCode.ITask;

    public class Invoker<TRequest> : Invoker, IInvoker<TRequest>
    {
        public Invoker(IInvokerMember root) : base(root)
        {
        }

        public override object Invoke(params object[] parameters)
        {
            return this.Invoke((ITask<TRequest>)parameters[0]);
        }

        public ITask Invoke(ITask<TRequest> request)
        {
            return TaskInterfaceFactory.CreateTask(async () => await (await this.RecursiveInvoke(this.rootInvokerMember, request) as ITask));
        }
    }
}
