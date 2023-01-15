namespace DesignPatterns.Creational.Singleton;

#pragma warning disable CA5394 // Do not use insecure randomness
public class LoadBalancer
{
    private static readonly Lazy<LoadBalancer> lazyLoadBalancer = new(() => new LoadBalancer());
    private readonly List<Server> servers = new();

    private LoadBalancer()
    {
        this.servers = new List<Server>
                {
                  new Server{ Name = "ServerI", IP = "120.14.220.18" },
                  new Server{ Name = "ServerII", IP = "120.14.220.19" },
                  new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                  new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                  new Server{ Name = "ServerV", IP = "120.14.220.22" },
                };
    }

    public static LoadBalancer Instance => lazyLoadBalancer.Value;

    public Server NextServer => this.servers[Random.Shared.Next(0, this.servers.Count)];
}

public sealed record Server
{
    public required string Name { get; init; }
    
    public required string IP { get; init; }
}
