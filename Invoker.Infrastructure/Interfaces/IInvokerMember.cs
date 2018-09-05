namespace Invoker.Infrastructure
{
    public interface IInvokerMember
    {
        string Name { get; set; }

        IInvokerMember[] Dependencies { get; set; }

        object Invoke(params object[] parameters);
    }
}
