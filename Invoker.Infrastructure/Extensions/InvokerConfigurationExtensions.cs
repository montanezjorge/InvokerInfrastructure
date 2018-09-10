namespace Invoker.Infrastructure.Extensions
{
    using global::Invoker.Infrastructure.Interfaces;
    using System.Linq;

    public static class InvokerConfigurationExtensions
    {
        public static IInvokerConfigElement<object> Invokes<TTarget>(this IInvokerConfigElement<object> invokerConfiguration, string name = null)
            where TTarget : class
        {
            var child = new InvokerElement<TTarget>(name ?? typeof(TTarget).Name, parent: invokerConfiguration);
            if (invokerConfiguration.Children == null)
            {
                invokerConfiguration.Children = new IInvokerConfigElement<object>[] { };
            }

            invokerConfiguration.Children = invokerConfiguration.Children.Append(child).ToArray();
            return child;
        }

        public static IInvokerConfigElement<object> InvokesMultiple(this IInvokerConfigElement<object> invokerConfiguration, params IInvokerConfigElement<object>[] children)
        {
            var parentList = children.Select(leaf =>
            {
                var parent = leaf.Clone() as IInvokerConfigElement<object>;
                while (parent.Parent != null)
                {
                    parent = parent.Parent;
                }
                return parent;
            }).ToList();

            invokerConfiguration.Children = parentList.ToArray();
            parentList.ForEach(child => child.Parent = invokerConfiguration);
            return invokerConfiguration;
        }
    }
}
