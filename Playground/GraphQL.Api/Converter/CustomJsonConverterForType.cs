using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraphQL.Api.Converter
{
    public class CustomJsonConverterForType : JsonConverter<Type>
    {
        public override Type Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
        {
            string assemblyQualifiedName = value.AssemblyQualifiedName;
            writer.WriteStringValue(assemblyQualifiedName);
        }
    }
}
