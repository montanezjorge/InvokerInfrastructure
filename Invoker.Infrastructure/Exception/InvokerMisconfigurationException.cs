namespace Invoker.Infrastructure
{
    using System;

    public class InvokerMisconfigurationException : InvokerException
    {
        public InvokerMisconfigurationException() : base(string.Empty)
        {
        }

        public InvokerMisconfigurationException(Guid outcomeId) : base(outcomeId)
        {
        }

        public InvokerMisconfigurationException(string message) : base(message)
        {
        }

        public InvokerMisconfigurationException(Guid outcomeId, string message) : base(outcomeId, message)
        {
        }

        public InvokerMisconfigurationException(string message, Exception inner) : base(message, inner)
        {
        }

        public InvokerMisconfigurationException(Guid outcomeId, Exception inner) : base(outcomeId, inner)
        {
        }

        public InvokerMisconfigurationException(Guid outcomeId, string message, Exception inner) : base(outcomeId, message, inner)
        {
        }
    }
}
