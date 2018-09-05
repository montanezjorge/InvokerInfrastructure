using Invoker.Infrastructure;
using System;
using System.Threading.Tasks;

namespace TestProject.ClassForTesting
{
    public class IfLogic : InvokerMemberBase<Dto, Dto>
    {
        protected override async Task<Dto> Invoke(Dto param)
        {
            param.Input = null;
            return param;
        }
    }
}
