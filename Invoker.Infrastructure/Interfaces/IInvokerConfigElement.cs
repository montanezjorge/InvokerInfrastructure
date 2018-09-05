namespace Invoker.Infrastructure
{
    using System;

    public interface IInvokerConfigElement<out TTarget> : ICloneable
        where TTarget : class
    {
        string Name { get; set; }

        Type Type { get; set; }

        IInvokerConfigElement<object> Parent { get; set; }

        IInvokerConfigElement<object>[] Children { get; set; }
    }
}
