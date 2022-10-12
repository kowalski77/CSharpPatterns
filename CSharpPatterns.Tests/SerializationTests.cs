using System.Text.Json;
using FluentAssertions;
using Playground.Serialization;

namespace CSharpPatterns.Tests;

public class SerializationTests
{
    [Fact]
    public void Custom_converter_registration_serializes_date_accordingly()
    {
        // Arrange
        var options = new JsonSerializerOptions
        {
            Converters = { new DateTimeOffsetJsonConverter() }
        };
        var dateTime = new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);

        // Act
        var json = JsonSerializer.Serialize(dateTime, options);

        // Assert
        json.Should().Be(@"""01/01/2020""");
    }

    [Fact]
    public void Custom_converter_registration_deserializes_date_accordingly()
    {
        // Arrange
        var options = new JsonSerializerOptions
        {
            Converters = { new DateTimeOffsetJsonConverter() }
        };
        var json = @"""01/01/2020""";

        // Act
        var dateTime = JsonSerializer.Deserialize<DateTimeOffset>(json, options);

        // Assert
        dateTime.Should().Be(new DateTimeOffset(new DateTime(2020, 1, 1)));
    }

    [Fact]
    public void Custom_converter_registration_serializes_temperature_accordingly()
    {
        // Arrange
        var temperature = new Temperature(20, false);

        // Act
        var json = JsonSerializer.Serialize(temperature);

        // Assert
        json.Should().Be(@"""20F""");
    }
}
