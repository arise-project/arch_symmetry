using System;
using System.Text.Json;
using System.IO;
using arch_sync.Service.MethodCall;
using System.Text;
using arch_sync.Service.StaticClass;

namespace arch_sync.Unit
{
    public class MethodCallUnit
    {
        public void Execute()
        {
            var ct = File.ReadAllText("appSettings.json");
            Console.WriteLine("======");
            Console.WriteLine(ct);
            Console.WriteLine("======");
            var ac = JsonSerializer.Deserialize<AppConfig>(ct);

            var tp = Path.Combine(ac.BaseDirectory, ac.ServiceFolder);

            Console.WriteLine("======");
            
            var dt = "{class}.{method}();";
            
            string [] records = File.ReadAllLines(ac.ClassMethods);
            var fileName = Path.Combine(tp,ac.WorkFile);
            var b = new StringBuilder();
            foreach(var rec in records)
            {
                b.AppendLine(string.Format(dt, rec.Split(',')[0], new MethodBuilder().Gen(rec)));
            }
            new InsertText().Insert(fileName,ac.MethodCallMarker,dt);
        }
    }
}