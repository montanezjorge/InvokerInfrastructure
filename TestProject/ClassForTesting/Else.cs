namespace TestProject.ClassForTesting
{
    using Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class Else : InvokerConditionalMemberBase<Dto>
    {
        protected override async Task<bool> Invoke(Dto param)
        {
            return param.Input?.Length > 0;
        }
    }
}
