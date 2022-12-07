using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace arch_sync.Service.ServicesSetup
{
    public class ListImplementations
    {
        public IEnumerable<string> FilterImplementations(string folder)
        {
            var files = Directory.GetFiles(folder, "*.cs", SearchOption.TopDirectoryOnly);
            var names = files.Select(f =>Path.GetFileNameWithoutExtension(f));
            var texts = files.Select(f => File.ReadAllText(f));
            foreach(var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                if(!texts.Any(t => names.Any(n => t.Contains(": "+n))))
                {
                    yield return name;
                }
            }
        }
    }
}
