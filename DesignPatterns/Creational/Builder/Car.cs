namespace DesignPatterns.Creational.Builder;

public record Car
{
    public string? Make { get; set; }

    public Color Color { get; set; }

    public DateTime ManufactureDate { get; set; }
}

public enum Color
{
    Black,
    White,
    Red,
    Gray,
    Yellow,
    Orange
}
