using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;

namespace BlazorFileAccess.FileOptions;

internal class EnumDescriptionConverter<T> : JsonConverter<T> where T : IComparable, IFormattable, IConvertible
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonValue = reader.GetString();
        foreach (var fi in typeToConvert.GetFields())
        {
            var description = (DescriptionAttribute)(fi.GetCustomAttribute(typeof(DescriptionAttribute), false) ?? (default!));
            if (description != null)
            {
                if (description.Description == jsonValue)
                {
                    return (T)(fi.GetValue(null) ?? default!);
                }
            }
        }
        throw new JsonException($"string {jsonValue} was not found as a description in the enum {typeToConvert}");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString() ?? default!) ?? default!;
        DescriptionAttribute description = (DescriptionAttribute)(fi.GetCustomAttribute(typeof(DescriptionAttribute), false) ?? default!);
        writer.WriteStringValue(description.Description);
    }
}
