namespace Comparisons;

public struct CoordinatesStruct
{
    public CoordinatesStruct(decimal latitude, decimal longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    public decimal Latitude { get; }

    public decimal Longitude { get; }
}