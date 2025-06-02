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


    public class ThemeSerializer : VersionedJsonSerializer<Theme, int>
    {

        public override JsonSerializerOptions CreateOptions(int version)
        {
            var options = new JsonSerializerOptions();

            options.WriteIndented = true;
            //options.Converters.Add(new ColorJsonConverter());
            if (version >= 1)
                options.Converters.Add(new TypeDescriptorJsonConverter<System.Drawing.Color>());
            else
                options.Converters.Add(new ColorJsonConverter());
            options.Converters.Add(new TypeDescriptorJsonConverter<System.Drawing.Font>());

            return options;
        }

        public ThemeSerializer() : base(nameof(Theme.ThemeVersion), 1) { }
    }


    /// <summary>
    /// Wrapper around <see cref="JsonSerializer"/> to handle compatibility issues between various versions
    /// of the type <see cref="T"/> to be serialized.
    /// </summary>
    /// <typeparam name="T">Type of object to be serialized or deserialized</typeparam>
    /// <typeparam name="V">Type of version property. Must be IComparable. Usually int, string or <see cref="System.Version"/></typeparam>
    public class VersionedJsonSerializer<T,V> where T : class where V : IComparable
    {
        /// <summary>
        /// Version Property
        /// </summary>
        public PropertyInfo VersionProperty { get; private set; }

        /// <summary>
        /// Name(s) of Version property in Json files.
        /// </summary>
        /// Multiple alternative names may be given as a string separated by '|', and must follow Regex syntax
        public string VersionPropertyJsonNames { get; private set; }

        /// <summary>
        /// Current version.  Used while serializing
        /// </summary>
        public V CurrentVersion { get; private set; }

        static TypeConverter VersionTypeConverter { get; } = TypeDescriptor.GetConverter(typeof(V));


        internal Dictionary<V, JsonSerializerOptions> OptionsDictionary = new();

        public JsonSerializerOptions GetOptions(V version) {
            if (!OptionsDictionary.TryGetValue(version, out JsonSerializerOptions result)) {
                result = CreateOptions(version);
                OptionsDictionary.Add(version, result);
            }
            return result;
        }

        public virtual Type GetType(V version)
        {
            return typeof(T);
        }

        public virtual T Upgrade(object value, V version)
        {
            return (T)value;
        }

        public virtual V GetVersionFromJson(string json)
        {
            var match = Regex.Match(json, $"\"({VersionPropertyJsonNames})\"\\s*:\\s*\\\"?([^\\,}}\\\"]*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string s = match.Groups[2].Value.Trim();
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
            var result = Upgrade(JsonSerializer.Deserialize(json, GetType(version), GetOptions(version)), version);
            VersionProperty.SetValue(result, CurrentVersion);
            return result;
        }

        public virtual string Serialize(T obj)
        {
           VersionProperty.SetValue(obj, CurrentVersion);
            return JsonSerializer.Serialize(obj, GetOptions(CurrentVersion));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="versionPropertyName">Name of the version property in T</param>
        /// <param name="currentVersion">Current version</param>
        /// <param name="alternativeVersionPropertyNames">Alternative version property names</param>
        /// <exception cref="Exception"></exception>
        public VersionedJsonSerializer(string versionPropertyName, V currentVersion, string alternativeVersionPropertyNames = null)
        {
            VersionProperty = typeof(T).GetProperty(versionPropertyName);
            if (VersionProperty.PropertyType != typeof(V)) 
                throw new Exception($"Version Property must be of type '{typeof(V).Name}'");
            var custName = VersionProperty.GetCustomAttribute<JsonPropertyNameAttribute>();
            VersionPropertyJsonNames = custName?.Name ?? versionPropertyName;
            if (!String.IsNullOrWhiteSpace(alternativeVersionPropertyNames))
            {
                var altNames = alternativeVersionPropertyNames.Trim();
                VersionPropertyJsonNames += (altNames[0] != '|' ? "|" : null) + alternativeVersionPropertyNames;
            }
            CurrentVersion = currentVersion;
        }

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
