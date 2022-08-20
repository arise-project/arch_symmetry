using System.IO;
using System.Linq;
using System.Collections.Generic;
using arch_sync.Model;

namespace arch_sync.Service.ClassInterface
{
    public class InterfaceFileWalker
    {
        public List<FileModel> Walk(string folder)
        {
            List<FileModel> list = new List<FileModel>();

            var files = Directory.GetFiles(folder, "I*.cs", SearchOption.TopDirectoryOnly);

            list.AddRange(files.Select(f => new FileModel(f, "", File.ReadAllText(f))));

            return list;
        }
    }
}
