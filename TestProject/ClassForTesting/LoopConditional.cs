namespace TestProject.ClassForTesting
{
    using Invoker.Infrastructure;
    using Invoker.Infrastructure.Interfaces;
    using System.Threading.Tasks;

    public class LoopConditional : InvokerRepeatingMemberBase<Dto>, IInvokerRepeatingMember
    {
        protected override async Task<bool> Invoke(Dto param)
        {
            return param.Input != null;
        }
    }
}
