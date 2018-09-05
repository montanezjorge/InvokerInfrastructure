namespace Invoker.Infrastructure
{
    using System;

    public class InputLoader : IInvokerMember
    {
        public string Name { get => typeof(InputLoader).Name; set => throw new NotSupportedException(); }
        public IInvokerMember[] Dependencies { get => new IInvokerMember[] { }; set => throw new NotSupportedException(); }

        public object Invoke(object[] parameters)
        {
            return parameters[0];
        }
    }
}
