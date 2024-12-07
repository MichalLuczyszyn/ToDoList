using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.ValueObjects.Name;

public class NameJsonConverter : JsonConverter<Name>
{
    public override Name Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new Name(value!); // Use the constructor
    }

    public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value); // Serialize only the string value
    }
}