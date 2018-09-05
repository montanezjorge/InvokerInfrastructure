namespace Invoker.Infrastructure
{
    using global::Invoker.Infrastructure.Implementations;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ContainerExtensions
    {
        public static IContainer RegisterInvoker<TRequest, TResponse>(this IContainer container, IInvokerConfigElement<object> invokerConfiguration)
        {
            return RegisterInvoker<TRequest, TResponse>(container, null, invokerConfiguration);
        }

        public static IContainer RegisterInvoker<TRequest>(this IContainer container, IInvokerConfigElement<object> invokerConfiguration)
        {
            return RegisterInvoker<TRequest>(container, null, invokerConfiguration);
        }

        public static IContainer RegisterInvoker<TRequest, TResponse>(this IContainer container, string name, IInvokerConfigElement<object> invokerConfiguration)
        {
            var stack = RegisterDependencies(container, name, invokerConfiguration);
            return RegisterInvoker<TRequest, TResponse>(container, name, stack);
        }

        public static IContainer RegisterInvoker<TRequest>(this IContainer container, string name, IInvokerConfigElement<object> invokerConfiguration)
        {
            var stack = RegisterDependencies(container, name, invokerConfiguration);
            return RegisterInvoker<TRequest>(container, name, stack);
        }

        private static IContainer RegisterInvoker<TRequest, TResponse>(IContainer container, string name, Stack<IInvokerConfigElement<object>> stack)
        {
            var last = stack.Last();

            container.RegisterTypeWithDependencies(name, typeof(Invoker<TRequest, TResponse>), constructorDependencies: new[] { (last.Name, typeof(IInvokerMember)) });
            container.MapImplementation(name, typeof(IInvoker<TRequest, TResponse>), name, typeof(Invoker<TRequest, TResponse>));

            return container.MapImplementation(name, typeof(IInvoker), name, typeof(Invoker<TRequest, TResponse>));
        }

        private static IContainer RegisterInvoker<TRequest>(IContainer container, string name, Stack<IInvokerConfigElement<object>> stack)
        {
            var last = stack.Last();

            container.RegisterTypeWithDependencies(name, typeof(Invoker<TRequest>), constructorDependencies: new[] { (last.Name, typeof(IInvokerMember)) });
            container.MapImplementation(name, typeof(IInvoker<TRequest>), name, typeof(Invoker<TRequest>));

            return container.MapImplementation(name, typeof(IInvoker), name, typeof(Invoker<TRequest>));
        }

        private static Stack<IInvokerConfigElement<object>> RegisterDependencies(IContainer container, string name, IInvokerConfigElement<object> invokerConfiguration)
        {
            var root = FindRoot(invokerConfiguration);
            var stack = DepthFirstTraversal(root);

            foreach (var invokerConfigElement in stack)
            {
                RegisterInvokerMember(container, invokerConfigElement);
            }

            return stack;
        }

        private static void RegisterInvokerMember(IContainer container, IInvokerConfigElement<object> invokerConfigElement)
        {
            if (invokerConfigElement.Children?.Count() > 0)
            {
                RegisterSubRoot(container, invokerConfigElement);
            }
            else
            {
                RegisterLeaf(container, invokerConfigElement);
            }
        }

        private static void RegisterSubRoot(IContainer container, IInvokerConfigElement<object> invokerConfigElement)
        {
            container.RegisterTypeWithDependencies(
                invokerConfigElement.Name, 
                typeof(IInvokerMember), 
                invokerConfigElement.Type,
                invokerMemberDependencies: invokerConfigElement.Children.Select(c => c.Name).ToArray());
        }

        private static void RegisterLeaf(IContainer container, IInvokerConfigElement<object> invokerConfigElement)
        {
            container.RegisterType(invokerConfigElement.Name, typeof(IInvokerMember), invokerConfigElement.Type);
        }

        private static Stack<IInvokerConfigElement<object>> DepthFirstTraversal(IInvokerConfigElement<object> invokerConfigElement)
        {
            var nodes = new List<IInvokerConfigElement<object>>() { invokerConfigElement };

            var stack = new Stack<IInvokerConfigElement<object>>();
            stack.Push(invokerConfigElement);

            while (nodes.Count != 0)
            {
                var node = nodes.FirstOrDefault();
                nodes.Remove(node);
                if (node.Children != null && node.Children.Any())
                {
                    node.Children.ToList().ForEach(child => stack.Push(child));
                    nodes.InsertRange(0, node.Children);
                }
            }

            return stack;
        }

        private static bool IsInvoker(Type type)
        {
            return type.IsGenericType
                && (type.GetGenericTypeDefinition() == typeof(IInvoker<,>) || type.GetGenericTypeDefinition() == typeof(Invoker<,>));
        }

        private static IInvokerConfigElement<object> FindRoot(IInvokerConfigElement<object> invokerConfiguration)
        {
            var root = invokerConfiguration;
            while (root.Parent != null)
            {
                root = root.Parent;
            }

            return root;
        }
    }
}
