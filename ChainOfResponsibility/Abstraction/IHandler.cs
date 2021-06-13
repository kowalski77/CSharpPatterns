namespace ChainOfResponsibility.Abstraction
{
    public interface IHandler<TRequest, TResponse>
    {
        IHandler<TRequest, TResponse> Next(IHandler<TRequest, TResponse> handler);

        TResponse Run(TRequest request);
    }
}