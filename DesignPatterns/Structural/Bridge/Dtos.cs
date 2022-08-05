namespace DesignPatterns.Structural.Bridge;

public record Invoice(Header Header, Customer Customer, Order Order);

public record Header(string Data);

public record Customer(string Name);

public record Order(string Data);