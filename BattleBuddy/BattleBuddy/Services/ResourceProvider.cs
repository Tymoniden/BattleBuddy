using System;
using System.IO;
using System.Reflection;

namespace BattleBuddy.Services
{
    public class ResourceProvider
    {
        private readonly Assembly _assembly;

        public ResourceProvider()
        {
            _assembly = GetType().Assembly;
        }

        public string GetResourceContentAsString(string path)
        {
            using var stream = GetResourceStream(path);
            if (stream == null)
            {
                throw new ArgumentException(nameof(path));
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public Stream? GetResourceStream(string path)
        {
            var names = _assembly.GetManifestResourceNames();

            return _assembly.GetManifestResourceStream(path);
        }
    }
}
