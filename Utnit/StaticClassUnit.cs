using System;
using System.Text.Json;
using System.IO;
using arch_sync.Service.StaticClass;

namespace arch_sync.Unit
{
    public class StaticClassUnit
    {
        public void Execute()
        {
            var ct = File.ReadAllText("appSettings.json");
            Console.WriteLine("======");
            Console.WriteLine(ct);
            Console.WriteLine("======");
            var config = JsonSerializer.Deserialize<AppConfig>(ct);

            var tp = Path.Combine(config.BaseDirectory, config.ServiceFolder);

            Console.WriteLine("======");
            Console.WriteLine("not implemented");
        }
    }
}