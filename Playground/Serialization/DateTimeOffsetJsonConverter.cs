using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Playground.Serialization;

public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            DateTimeOffset.ParseExact(reader.GetString()!, "dd/MM/yyyy", CultureInfo.InvariantCulture);

    public override void Write(Utf8JsonWriter writer, DateTimeOffset dateTimeValue, JsonSerializerOptions options) =>
        writer.WriteStringValue(dateTimeValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
}