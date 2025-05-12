using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace WeifenLuo.Docking
{

    public class Person
    {
        public string Name { get; set; }
        
        public Person(string name) {
            Name = name;
        }
    }


    public class Resources
    {

        /// <summary>
        /// Cache for resource images
        /// </summary>
        private static readonly Dictionary<string, Image> imageCache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

        private static Stream GetManifestResourceStream(string name) {
            return typeof(Resources).Assembly.GetManifestResourceStream("WeifenLuo.Docking.Resources." + name);
        }

        public static Image GetImage(string name) {
            if (imageCache.ContainsKey(name)) { return imageCache[name]; }
            try {
                var stream = GetManifestResourceStream(name);
                if (stream == null) throw new Exception();
                var image = Image.FromStream(stream);
                if (image == null) throw new Exception();
                imageCache[name] = image;
                return image;
            } catch (Exception e) {
                throw new Exception($"Failed to get resource '{name}': {e.Message}", e);
            }
        }

        public static Bitmap GetBitmap(string name) =>
            GetImage(name) as Bitmap ?? 
                throw new Exception($"Failed to get Bitmap '{name}'");

        public static string GetString(string name) {
            try {
                var stream = GetManifestResourceStream(name);
                if (stream == null) throw new Exception();
                using (var reader = new StreamReader(stream)) {
                    return reader.ReadToEnd();
                }
            } catch (Exception e) {
                throw new Exception($"Failed to get resource '{name}': {e.Message}", e);
            }
        }


        public static byte[] GetBytes(string name) {
            try {
                var stream = GetManifestResourceStream(name);
                if (stream == null) throw new Exception();
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream()) {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0) {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            } catch (Exception e) {
                throw new Exception($"Failed to get resource '{name}': {e.Message}", e);
            }
        }

        public Resources() { }

    }
}
