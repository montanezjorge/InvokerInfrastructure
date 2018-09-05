namespace Invoker.Infrastructure.Interfaces
{
    using MorseCode.ITask;

    public interface IInvokerConditionalMember : IInvokerMember
    {
        new ITask<bool> Invoke(params object[] parameters);
    }
}
