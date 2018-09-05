namespace TestProject.ClassForTesting
{
    using Invoker.Infrastructure;
    using Invoker.Infrastructure.Interfaces;
    using System.Threading.Tasks;

    public class Initializer : InvokerMemberBase<string, Dto>
    {
        protected override async Task<Dto> Invoke(string param)
        {
            return new Dto
            {
                Input = param,
            };
        }
    }
}
