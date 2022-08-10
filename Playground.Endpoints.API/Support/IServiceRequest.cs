namespace Playground.Endpoints.API.Support;

public interface IServiceRequest<in TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    Task<TResult> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
}
