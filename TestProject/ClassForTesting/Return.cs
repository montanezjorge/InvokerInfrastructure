namespace TestProject.ClassForTesting
{
    using Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class Return : VoidInvokerMemberBase<Dto>
    {
        protected override async Task Invoke(Dto param)
        {
            return;
        }
    }
}
