namespace Invoker.Infrastructure
{
    using System;

    public interface IContainer
    {
        IContainer RegisterType(string name, Type type, Type implementationType);

        IContainer RegisterTypeWithDependencies(
            string name, 
            Type type, 
            Type implementationType = null, 
            (string name, Type type)[] constructorDependencies = null, 
            string[] invokerMemberDependencies = null);

        IContainer MapImplementation(string name, Type type, string implementationName, Type implementationType);

        object Resolve(Type type, string name = null);

        T Resolve<T>(string name = null);
    }
}
