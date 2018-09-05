namespace Invoker.Infrastructure
{
    using global::Invoker.Infrastructure.Interfaces;
    using MorseCode.ITask;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class Invoker : IInvoker
    {
        protected readonly IInvokerMember rootInvokerMember;

        public Invoker(IInvokerMember root)
        {
            this.rootInvokerMember = root;
        }

        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public abstract object Invoke(params object[] parameters);

        protected async Task<object> RecursiveInvoke(IInvokerMember member, object request)
        {
            var memberType = member.GetType();
            var result = null as object;
            var dependencies = member.Dependencies;

            if (member is IInvokerRepeatingMember)
            {
                var loopConditional = await this.InvokeMember(member, request) as ITask<bool>;
                while (await loopConditional)
                {
                    result = await this.DependenciesInvoke(member, dependencies, request);
                    loopConditional = await this.InvokeMember(member, request) as ITask<bool>;
                }

                return result;
            }
            if (member is IInvokerConditionalMember)
            {
                var conditional = await this.InvokeMember(member, request) as ITask<bool>;
                if (await conditional)
                {
                    return await this.DependenciesInvoke(member, dependencies, request);
                }
                else
                {
                    return request;
                }
            }

            result = await this.InvokeMember(member, request);

            if (dependencies == null || dependencies.Count() == 0)
            {
                return result;
            }

            return await this.DependenciesInvoke(member, dependencies, result);
        }

        protected async Task<object> DependenciesInvoke(IInvokerMember member, IInvokerMember[] dependencies, object request)
        {
            var tasks = new List<Task<object>>();

            foreach (var dependency in dependencies)
            {
                tasks.Add(this.RecursiveInvoke(dependency, request));
            }

            var result = await Task.WhenAll(tasks);

            var task = result.FirstOrDefault(x => (x as ITask)?.AsTask()?.IsFaulted == true) as ITask;

            if (task != null)
            {
                throw task.AsTask().Exception;
            }

            return result.LastOrDefault();
        }

        protected async Task<object> InvokeMember(IInvokerMember member, params object[] parameters)
        {
            return member.Invoke(parameters);
        }
    }
}
