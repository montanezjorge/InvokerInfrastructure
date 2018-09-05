namespace Invoker.Infrastructure
{
    using System;

    public class Response<TResponse> : IResponse<TResponse>
    {
        private readonly TResponse serviceResponse;

        public Response(Id requestId, RequestOutcome requestOutcome, TResponse serviceResponse)
        {
            this.ResponseTime = DateTime.Now.ToUniversalTime();
            this.CorrelatedRequestId = requestId;
            this.serviceResponse = serviceResponse;
            this.Outcome = requestOutcome;
        }

        public Id CorrelatedRequestId { get; protected set; }

        public RequestOutcome Outcome { get; protected set; }

        public TResponse ResponseContract
        {
            get
            {
                return serviceResponse;
            }
        }

        public DateTime ResponseTime { get; protected set; }
    }
}
