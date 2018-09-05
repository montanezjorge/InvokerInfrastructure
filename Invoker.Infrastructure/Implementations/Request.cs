namespace Invoker.Infrastructure
{
    using System;

    public class Request<TRequest> : IRequest<TRequest>
    {
        private readonly TRequest serviceRequest;

        public Request(Id requestId, TRequest serviceRequest)
        {
            this.RequestTime = DateTime.Now.ToUniversalTime();
            this.RequestId = requestId;
            this.serviceRequest = serviceRequest;
        }

        public TRequest RequestContract
        {
            get
            {
                return this.serviceRequest;
            }
        }

        public Id RequestId { get; private set; }

        public DateTime RequestTime { get; private set; }
    }
}
