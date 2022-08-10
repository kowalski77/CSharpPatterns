namespace Playground.Endpoints.API.Support;

public interface IRequestHandler<in TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    Task<TResult> HandlerAsync(TRequest request, CancellationToken cancellationToken = default);
}
