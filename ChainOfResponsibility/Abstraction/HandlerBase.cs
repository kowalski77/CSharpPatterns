namespace ChainOfResponsibility.Abstraction
{
    public class HandlerBase<TRequest, TResponse> : IHandler<TRequest, TResponse>
    {
        private IHandler<TRequest, TResponse>? nextHandler;

        public IHandler<TRequest, TResponse> Next(IHandler<TRequest, TResponse> handler)
        {
            this.nextHandler = handler;

            return this.nextHandler;
        }

        public virtual TResponse Run(TRequest request)
        {
            return this.nextHandler!.Run(request);
        }
    }
}