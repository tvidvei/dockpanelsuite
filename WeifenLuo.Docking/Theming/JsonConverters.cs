using System;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.Design.AxImporter;
using System.Text.RegularExpressions;

namespace WeifenLuo.Docking
{

    public interface IVersionedObject<V>
    {
        V Version { get; set; }
    }


    public class JsonVersionedSerializer<T,V> where T : class
    {
        /// <summary>
        /// Version Property
        /// </summary>
        public PropertyInfo VersionProperty { get; private set; }

        /// <summary>
        /// Name of VersionProperty in Json files
        /// </summary>
        public string VersionPropertyJsonName { get; private set; }

        /// <summary>
        /// Version
        /// </summary>
        public V CurrentVersion { get; private set; }

        public V DefaultVersion { get; private set; }

        static TypeConverter VersionTypeConverter { get; } = TypeDescriptor.GetConverter(typeof(V));


        internal Dictionary<V, JsonSerializerOptions> OptionsDictionary = new();

        public JsonSerializerOptions GetOptions(V version) {
            if (!OptionsDictionary.TryGetValue(version, out JsonSerializerOptions result)) {
                result = CreateOptions(version);
                OptionsDictionary.Add(version, result);
            }
            return result;
        }

        public virtual V GetVersionFromJson(string json)
        {
            var match = Regex.Match(json, $"\"{VersionPropertyJsonName}\"\\s*\\\"?(^[\\s,}}])\\\"?\\s*[,}}]");
            if (match.Success)
            {
                string s = match.Groups[1].Value;
                V result = (V)VersionTypeConverter.ConvertFromString(s);
                return result;
            }
            return default(V);
        }

        public virtual JsonSerializerOptions CreateOptions(V version)
        {
            return new JsonSerializerOptions();
        }

        public virtual T Deserialize(string json)
        {
            var version = GetVersionFromJson(json);
            var result = JsonSerializer.Deserialize<T>(json, GetOptions(version));
            VersionProperty.SetValue(result, CurrentVersion);
            return result;
        }

        public virtual string Serialize(T obj)
        {
           VersionProperty.SetValue(obj, CurrentVersion);
            return JsonSerializer.Serialize(obj, GetOptions(CurrentVersion));
        }

        public JsonVersionedSerializer(string versionPropertyName, V currentVersion, V defaultVersion = default(V))
        {
            VersionProperty = typeof(T).GetProperty(versionPropertyName);
            if (VersionProperty.PropertyType != typeof(V)) 
                throw new Exception($"Version Property must be of type '{typeof(V).Name}'");
            CurrentVersion = currentVersion;
            DefaultVersion = defaultVersion;
        }

    }


    public class ThemeJsonSerializer : JsonVersionedSerializer<Theme, int> {

        public override JsonSerializerOptions CreateOptions(int version)
        {
            var options = new JsonSerializerOptions();

            options.WriteIndented = true;
            options.Converters.Add(new ColorJsonConverter());
            //options.Converters.Add(new TypeDescriptorJsonConverter<System.Drawing.Color>());
            options.Converters.Add(new TypeDescriptorJsonConverter<System.Drawing.Font>());

            return options;
        }

        public ThemeJsonSerializer(int currentVersion) : base(nameof(Theme.ThemeVersion), currentVersion) { }
    }


    public class TypeDescriptorJsonConverter<TValue> : JsonConverter<TValue>
    {
        static TypeConverter TypeConverter { get; } = TypeDescriptor.GetConverter(typeof(TValue));
        static bool IsNonNullableValueType { get; } = typeof(TValue).IsValueType && Nullable.GetUnderlyingType(typeof(TValue)) == null;

        public override TValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            reader.TokenType switch
            {
                JsonTokenType.Null when IsNonNullableValueType => throw new JsonException(),
                JsonTokenType.Null => default,
                JsonTokenType.String => (TValue?)TypeConverter.ConvertFromInvariantString(null, reader.GetString()!),
                _ => throw new JsonException()
            };

        public override void Write(Utf8JsonWriter writer, TValue? value, JsonSerializerOptions options)
        {
            if (value is null)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(TypeConverter.ConvertToInvariantString(null, value));
        }
    }


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
