using System.Drawing;
using System.IO;

namespace ThemeEditor
{
    /// <summary>
    /// Get font, image and text resources for HtmlRenderer demo.
    /// </summary>
    public static class Resources
    {

        private static Stream GetManifestResourceStream(string name) {
            return typeof(Resources).Assembly.GetManifestResourceStream("ThemeEditor.Images." + name);
        }

        /// <summary>
        /// Cache for resource images
        /// </summary>
        private static readonly Dictionary<string, Image> _imageCache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);


        public static T GetResource<T>(string nameAndExt) {
            try {
                var stream = GetManifestResourceStream(nameAndExt);
                var ty = typeof(T);
                if (ty == typeof(string)) {
                    using (var reader = new StreamReader(GetManifestResourceStream(nameAndExt))) {
                        return (T)(object)reader.ReadToEnd();
                    }
                } else if (ty == typeof(Image)) {
                    Image image;
                    if (!_imageCache.TryGetValue(nameAndExt, out image)) {
                        var imageStream = GetManifestResourceStream(nameAndExt);
                        if (imageStream != null) {
                            image = System.Drawing.Image.FromStream(imageStream);
                            _imageCache[nameAndExt] = image;
                        }
                    }
                    return (T)(object)image!;
                } else if (ty == typeof(byte[])) {
                    byte[] buffer = new byte[16 * 1024];
                    using (MemoryStream ms = new MemoryStream()) {
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0) {
                            ms.Write(buffer, 0, read);
                        }
                        return (T)(object)ms.ToArray();
                    }
                } else {
                    throw new Exception("Invalid resource type requested");
                }
            } catch (Exception e) {
                throw new Exception($"Failed to get resouce '{nameAndExt}': {e.Message}", e);
            }
        }

    }
}