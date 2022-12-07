using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace arch_sync.Service.ServicesSetup
{
    public class DiRealizations
    {
        public IEnumerable<string> GetPairs(string folder, IEnumerable<string> abstrations)
        {
            var files = Directory.GetFiles(folder, "*.cs", SearchOption.TopDirectoryOnly);
            var names = files.Select(f =>Path.GetFileNameWithoutExtension(f));
            return names
                .Where(n => abstrations.Any(a => string.Equals(a, "I"+n)))
                .Select(n => $"services.AddSingleton<{abstrations.First(a => string.Equals(a, "I"+n))},{n}>();");
        }
    }
}
