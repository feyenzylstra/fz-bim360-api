using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field.Serialization
{
    public class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Guid) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return Guid.Empty;
                case JsonToken.String:
                    var value = reader.Value.ToString();
                    return !string.IsNullOrWhiteSpace(value)
                        ? Guid.Parse(value)
                        : Guid.Empty;
                default:
                    throw new ArgumentException("invalid token");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (Guid.Empty.Equals(value))
                writer.WriteValue("");
            else
                writer.WriteValue(value.ToString());
        }
    }
}
