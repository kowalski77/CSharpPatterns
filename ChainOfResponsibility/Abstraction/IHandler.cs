namespace ChainOfResponsibility.Abstraction
{
    public interface IHandler<TRequest, TResponse>
    {
        IHandler<TRequest, TResponse> SetNext(IHandler<TRequest, TResponse> handler);

        TResponse? Run(TRequest request);
    }
}