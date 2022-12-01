using System;
using System.Linq;
using System.Text.Json;
using System.IO;
using arch_sync.Service.ClassInterface;
using arch_sync.Service.MethodCall;

namespace arch_sync.Unit
{
    public class SnippetUnit
    {
        public void Execute()
        {
            var ct = File.ReadAllText("appSettings.json");
            Console.WriteLine("======");
            Console.WriteLine(ct);
            Console.WriteLine("======");
            var ac = JsonSerializer.Deserialize<AppConfig>(ct);

            var cp = Path.Combine(ac.BaseDirectory, ac.ServiceFolder);

            var cms = new ClassFileWalker().Walk(cp);

            var s = File.ReadAllText(ac.Snippet);

            Console.WriteLine("classes: " + cms.Count);

            foreach (var cm in cms)
            {
                new InsertText().Insert(cm.FullName, ac.MethodCallMarker, s);
            }

            Console.WriteLine("======");
            Console.WriteLine("done");
        }
    }
}