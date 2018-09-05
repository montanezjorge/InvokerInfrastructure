namespace Invoker.Infrastructure.Unity
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UnityContainerWrapper : IContainer
    {
        private readonly IUnityContainer unityContainer;

        public UnityContainerWrapper(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public IContainer RegisterType(string name, Type type, Type implementationType)
        {
            this.unityContainer.RegisterType(
                type, 
                implementationType, 
                name);

            return this;
        }

        public IContainer RegisterTypeWithDependencies(string name, Type type, Type implementationType = null, (string name, Type type)[] constructorDependencies = null, string[] invokerMemberDependencies = null)
        {
            var injectionMembers = new List<InjectionMember>();

            if (constructorDependencies != null)
            {
                injectionMembers.Add(new InjectionConstructor(constructorDependencies.Select(d => new ResolvedParameter(d.type, d.name)).ToArray()));
            }

            if (invokerMemberDependencies != null)
            {
                var members = invokerMemberDependencies.Select(dependency => new ResolvedParameter<IInvokerMember>(dependency)).ToArray();
                injectionMembers.Add(new InjectionProperty("Dependencies", new ResolvedArrayParameter<IInvokerMember>(members)));
            }

            if (implementationType == null)
            {
                this.unityContainer.RegisterType(type, name, injectionMembers.ToArray());
                return this;
            }

            this.unityContainer.RegisterType(type, implementationType, name, injectionMembers.ToArray());

            return this;
        }

        public IContainer MapImplementation(string name, Type type, string implementationName, Type implementationType)
        {
            this.unityContainer.RegisterType(type, new InjectionFactory(container => container.Resolve(implementationType, implementationName)));

            return this;
        }

        public object Resolve(Type type, string name = null)   
        {
            if (name == null)
            {
                return this.unityContainer.Resolve(type);
            }

            return this.unityContainer.Resolve(type, name);
        }

        public T Resolve<T>(string name = null)
        {
            return (T)this.Resolve(typeof(T), name);
        }

    }
}
