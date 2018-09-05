namespace Invoker.Infrastructure
{
    using System;

    public interface IResolver
    {
        object Get(string name, Type type);
    }
}
