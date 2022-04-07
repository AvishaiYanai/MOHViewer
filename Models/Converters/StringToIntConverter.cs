using System;
using Newtonsoft.Json;

namespace MOHViewer.Models.Converters
{
    internal class StringToIntConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType == JsonToken.Integer)
                return reader.Value;

            if (reader.TokenType == JsonToken.String)
            {
                var stringValue = (string)reader.Value;
                if (string.IsNullOrEmpty(stringValue))
                    return null;
                if (stringValue == "<15")
                    return 8;
                int num;
                //Tenta converter o valor
                if (int.TryParse(stringValue, out num))
                {
                    return num;
                }
                //Retorna 0
                else
                {
                    return 0;
                }

            }

            throw new JsonReaderException(string.Format("Unexcepted token {0}", reader.TokenType));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int?);
        }









    }
}
