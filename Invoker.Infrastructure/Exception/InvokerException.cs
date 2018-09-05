namespace Invoker.Infrastructure
{
    using System;

    public class InvokerException : ApplicationException
    {
        public InvokerException(Guid outcomeId) : base()
        {
            this.OutcomeId = outcomeId;
        }

        public InvokerException(string message) : base(message)
        {
            this.OutcomeId = new Guid("72C24158-C46B-43D1-BCE6-FEF26B7A8C61");
        }

        public InvokerException(Guid outcomeId, string message) : base(message)
        {
            this.OutcomeId = outcomeId;
        }

        public InvokerException(string message, Exception inner) : base(message, inner)
        {
            this.OutcomeId = new Guid("72C24158-C46B-43D1-BCE6-FEF26B7A8C61");
        }

        public InvokerException(Guid outcomeId, Exception inner) : base(string.Empty, inner)
        {
            this.OutcomeId = outcomeId;
        }

        public InvokerException(Guid outcomeId, string message, Exception inner) : base(message, inner)
        {
            this.OutcomeId = outcomeId;
        }

        public Guid OutcomeId { get; private set; }
    }
}
