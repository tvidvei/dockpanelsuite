using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing;
using System.Globalization;

namespace ThemeEditor
{
    internal class ColorJsonConverter : JsonConverter<Color>
    {

        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var str = "";
            try {
                str = reader.GetString()!;
                if (Enum.TryParse(typeof(KnownColor), str, out var color)) {
                    return Color.FromName(str);
                }
                return Color.FromArgb(Int32.Parse(str, System.Globalization.NumberStyles.HexNumber));
            } catch {
                throw new Exception($"Error: Unable to convert '{str}' to Color");
            }
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.Name);
        }

        public ColorJsonConverter() : base() { }
    }
}
