using Invoker.Infrastructure.Interfaces;
using MorseCode.ITask;
using System;
using System.Threading.Tasks;

namespace Invoker.Infrastructure
{
    public abstract class VoidInvokerMemberBase<TIn> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn>)parameters[0];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(await param1));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task Invoke(TIn param1);
    }

    public abstract class VoidInvokerMemberBase<TIn1, TIn2> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 2)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(await param1, await param2));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task Invoke(
            TIn1 param1,
            TIn2 param2);
    }

    public abstract class VoidInvokerMemberBase<TIn1, TIn2, TIn3> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 3)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3);
    }

    public abstract class VoidInvokerMemberBase<TIn1, TIn2, TIn3, TIn4> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 4)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4);
    }

    public abstract class VoidInvokerMemberBase<TIn1, TIn2, TIn3, TIn4, TIn5> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 5)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];
                var param5 = (ITask<TIn5>)parameters[4];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4,
                    await param5));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4,
            TIn5 param5);
    }

    public abstract class VoidInvokerMemberBase<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 6)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];
                var param5 = (ITask<TIn5>)parameters[4];
                var param6 = (ITask<TIn6>)parameters[5];

                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4,
                    await param5,
                    await param6));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4,
            TIn5 param5,
            TIn6 param6);
    }

    public abstract class VoidInvokerMemberBase<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 7)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];
                var param5 = (ITask<TIn5>)parameters[4];
                var param6 = (ITask<TIn6>)parameters[5];
                var param7 = (ITask<TIn7>)parameters[6];

                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4,
                    await param5,
                    await param6,
                    await param7));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4,
            TIn5 param5,
            TIn6 param6,
            TIn7 param7);
    }

    public abstract class InvokerMemberBase<TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(object[] parameters)
        {
            if (parameters.Length != 0)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke());
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke();
    }

    public abstract class InvokerMemberBase<TIn, TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(params object[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn>)parameters[0];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(await param1));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke(
            TIn param1);
    }

    public abstract class InvokerMemberBase<TIn1, TIn2, TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(params object[] parameters)
        {
            if (parameters.Length != 2)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(await param1, await param2));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke(
            TIn1 param1,
            TIn2 param2);
    }

    public abstract class InvokerMemberBase<TIn1, TIn2, TIn3, TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(params object[] parameters)
        {
            if (parameters.Length != 3)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(await param1, await param2, await param3));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3);
    }

    public abstract class InvokerMemberBase<TIn1, TIn2, TIn3, TIn4, TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(params object[] parameters)
        {
            if (parameters.Length != 4)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];

                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4);
    }

    public abstract class InvokerMemberBase<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(params object[] parameters)
        {
            if (parameters.Length != 5)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];
                var param5 = (ITask<TIn5>)parameters[4];

                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4,
                    await param5));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4,
            TIn5 param5);
    }

    public abstract class InvokerMemberBase<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(params object[] parameters)
        {
            if (parameters.Length != 6)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];
                var param5 = (ITask<TIn5>)parameters[4];
                var param6 = (ITask<TIn6>)parameters[5];

                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4,
                    await param5,
                    await param6));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4,
            TIn5 param5,
            TIn6 param6);
    }

    public abstract class InvokerMemberBase<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> : IInvokerMember
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public object Invoke(params object[] parameters)
        {
            if (parameters.Length != 7)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn1>)parameters[0];
                var param2 = (ITask<TIn2>)parameters[1];
                var param3 = (ITask<TIn3>)parameters[2];
                var param4 = (ITask<TIn4>)parameters[3];
                var param5 = (ITask<TIn5>)parameters[4];
                var param6 = (ITask<TIn6>)parameters[5];
                var param7 = (ITask<TIn7>)parameters[6];

                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(
                    await param1,
                    await param2,
                    await param3,
                    await param4,
                    await param5,
                    await param6,
                    await param7));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<TOut> Invoke(
            TIn1 param1,
            TIn2 param2,
            TIn3 param3,
            TIn4 param4,
            TIn5 param5,
            TIn6 param6,
            TIn7 param7);
    }

    public abstract class InvokerRepeatingMemberBase<TIn> : IInvokerRepeatingMember
        where TIn : class
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public ITask<bool> Invoke(params object[] parameters)
        {
            return (ITask<bool>)(this as IInvokerMember).Invoke(parameters);
        }

        object IInvokerMember.Invoke(params object[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn>)parameters[0];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(await param1));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<bool> Invoke(
            TIn param1);
    }

    public abstract class InvokerConditionalMemberBase<TIn> : IInvokerConditionalMember
        where TIn : class
    {
        public string Name { get; set; }

        public IInvokerMember[] Dependencies { get; set; }

        public ITask<bool> Invoke(params object[] parameters)
        {
            return (ITask<bool>)(this as IInvokerMember).Invoke(parameters);
        }

        object IInvokerMember.Invoke(params object[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new InvokerMisconfigurationException();
            }

            try
            {
                var param1 = (ITask<TIn>)parameters[0];
                return TaskInterfaceFactory.CreateTask(async () => await this.Invoke(await param1));
            }
            catch (InvalidCastException exception)
            {
                throw new InvokerMisconfigurationException(exception.Message, exception);
            }
        }

        protected abstract Task<bool> Invoke(
            TIn param1);
    }
}
