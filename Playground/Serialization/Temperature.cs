using System.Text.Json.Serialization;

namespace Playground.Serialization;

[JsonConverter(typeof(TemperatureConverter))]

public struct Temperature
{
    public Temperature(int degrees, bool celsius)
    {
        this.Degrees = degrees;
        this.IsCelsius = celsius;
    }

    public int Degrees { get; }

    public bool IsCelsius { get; }

    public bool IsFahrenheit => !this.IsCelsius;

    public override string ToString() => $"{this.Degrees}{(this.IsCelsius ? "C" : "F")}";

    public static Temperature Parse(string input)
    {
        var degrees = int.Parse(input[..^1]);
        var celsius = input[^1..] == "C";

        return new Temperature(degrees, celsius);
    }
}