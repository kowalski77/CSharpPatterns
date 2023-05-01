namespace Playground.Comparisons;

public class Coordinates
{
    public Coordinates(decimal latitude, decimal longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    public decimal Latitude { get; }

    public decimal Longitude { get; }
}