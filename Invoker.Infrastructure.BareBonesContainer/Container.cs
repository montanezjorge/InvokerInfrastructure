namespace Invoker.Infrastructure.BareBonesContainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Container : IContainer
    {
        private Dictionary<(string name, Type type), (Type impl, object obj)> registrations = new Dictionary<(string name, Type type), (Type impl, object obj)>();


        public IContainer RegisterType(string name, Type type, Type implementationType)
        {
            registrations.Add((name, type), (implementationType, null));

            return this;
        }

        private object Instantiate(string name, Type type, Type implementationType = null, (string name, Type type)[] constructorDependencies = null)
        {
            var parameters = constructorDependencies?.Select(x => this.Resolve(x.type, x.name))?.ToArray();
            var obj = Activator.CreateInstance(implementationType ?? type, parameters ?? new object[0]);
            if (registrations.ContainsKey((name, type)))
            {
                registrations.Remove((name, type));
            }
            registrations.Add((name, type), (obj.GetType(), obj));
            return obj;
        }

        public IContainer RegisterTypeWithDependencies(string name, Type type, Type implementationType = null, (string name, Type type)[] constructorDependencies = null, string[] invokerMemberDependencies = null)
        {
            Func<object> factory = null;
            Func<object> dependenciesResolutionFactory = () => null;

            factory = () => this.Instantiate(name, type, implementationType, constructorDependencies);

            if (invokerMemberDependencies != null)
            {
                dependenciesResolutionFactory = () => 
                {
                    var parent = this.Resolve<IInvokerMember>(name);
                    parent.Dependencies = invokerMemberDependencies.Select(x => this.Resolve<IInvokerMember>(x)).ToArray();
                    return parent;
                };

                factory = () =>
                {
                    this.Instantiate(name, type, implementationType, constructorDependencies);
                    return dependenciesResolutionFactory();
                };
            }

            if (implementationType == null)
            {
                registrations.Add((name, type), (type, factory));
                return this;
            }

            registrations.Add((name, type), (implementationType, factory));

            return this;
        }

        public IContainer MapImplementation(string name, Type type, string implementationName, Type implementationType)
        {
            Func<object> factory = () => this.Resolve(implementationType, implementationName);
            registrations.Add((name, type), (implementationType, factory));

            return this;
        }

        public object Resolve(Type type, string name = null)
        {
            KeyValuePair<(string name, Type type), (Type impl, object obj)> result;

            if (name == null)
            {
                result = registrations.FirstOrDefault(x => x.Key.type == type);
            }
            else
            {
                result = registrations.FirstOrDefault(x => x.Key.name == name && x.Key.type == type);
            }

            if (result.Equals(default(KeyValuePair<(string name, Type type), (Type impl, object obj)>)))
            {
                var parametersInfo = type.GetConstructors().First().GetParameters();
                var parameters = parametersInfo.Select(x => this.Resolve(x.ParameterType)).ToArray();
                return Activator.CreateInstance(type, parameters);
            }
            else if (result.Value.obj == null)
            {
                var obj = Activator.CreateInstance(result.Value.impl);
                result = new KeyValuePair<(string name, Type type), (Type impl, object obj)>(result.Key, (result.Value.impl, obj));
            }
            else if (result.Value.obj is Func<object>)
            {
                var factory = result.Value.obj as Func<object>;
                return factory();
            }

            return result.Value.obj;
        }

        public T Resolve<T>(string name = null)
        {
            var obj = this.Resolve(typeof(T), name);
            return (T)obj;
        }

    }
}
