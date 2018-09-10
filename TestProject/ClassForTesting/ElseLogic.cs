namespace TestProject.ClassForTesting
{
    using Invoker.Infrastructure;
    using System;
    using System.Threading.Tasks;

    public class ElseLogic : InvokerMemberBase<Dto, Dto>
    {
        protected override async Task<Dto> Invoke(Dto param)
        {
            Console.Write(param.Input[0]);
            param.Input = param.Input.Substring(1);

            return param;
        }
    }
}
