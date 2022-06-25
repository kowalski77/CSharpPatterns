namespace JsonTests;

public interface IIntegrationEvent
{
    Guid Id { get; }
}

public record ProductCreated(Guid Id, Guid ProductId, string Name, string Description, decimal Price) : IIntegrationEvent;

public record ProductUpdated(Guid Id, string Name, string Description, decimal Price) : IIntegrationEvent;