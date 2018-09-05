namespace Invoker.Infrastructure.Interfaces
{
    using MorseCode.ITask;
    using System.Threading.Tasks;

    public interface IInvokerRepeatingMember : IInvokerMember
    {
        new ITask<bool> Invoke(params object[] parameters);
    }
}
