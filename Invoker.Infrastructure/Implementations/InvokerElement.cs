namespace Invoker.Infrastructure
{
    using System;

    public class InvokerElement<TTarget> : IInvokerConfigElement<TTarget>
        where TTarget : class
    {
        public string Name { get; set; }

        public Type Type { get; set; }

        public IInvokerConfigElement<object> Parent { get; set; }

        public IInvokerConfigElement<object>[] Children { get; set; }

        public InvokerElement(string name = null)
        {
            this.Name = name ?? typeof(TTarget).FullName;
            this.Type = typeof(TTarget);
        }

        public InvokerElement(string name = null, IInvokerConfigElement<object> parent = null, params IInvokerConfigElement<object>[] children) : this(name)
        {
            this.Parent = parent;
            this.Children = children;
        }

        public object Clone()
        {
            return new InvokerElement<TTarget>(
                this.Name,
                this.Parent?.Clone() as IInvokerConfigElement<object>,
                this.Children ?? new IInvokerConfigElement<object>[] { });
        }
    }
}
