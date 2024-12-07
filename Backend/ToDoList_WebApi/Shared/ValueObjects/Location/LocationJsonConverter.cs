using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.ValueObjects.Location;

public class LocationJsonConverter : JsonConverter<Location>
    {
        public override Location Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token for Location.");
            }

            string? name = null;
            double? latitude = null;
            double? longitude = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break; // End of JSON object
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read(); // Move to the value

                    switch (propertyName)
                    {
                        case nameof(Location.Name):
                            name = reader.GetString();
                            break;
                        case nameof(Location.Latitude):
                            latitude = reader.GetDouble();
                            break;
                        case nameof(Location.Longitude):
                            longitude = reader.GetDouble();
                            break;
                        default:
                            throw new JsonException($"Unexpected property: {propertyName}");
                    }
                }
            }

            if (name is null || latitude is null || longitude is null)
            {
                throw new JsonException("Missing one or more required properties for Location.");
            }

            try
            {
                return new Location(name, latitude.Value, longitude.Value);
            }
            catch (ArgumentException ex)
            {
                throw new JsonException($"Invalid Location data: {ex.Message}", ex);
            }
        }

        public override void Write(Utf8JsonWriter writer, Location value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(nameof(Location.Name), value.Name);
            writer.WriteNumber(nameof(Location.Latitude), value.Latitude);
            writer.WriteNumber(nameof(Location.Longitude), value.Longitude);
            writer.WriteEndObject();
        }
    }