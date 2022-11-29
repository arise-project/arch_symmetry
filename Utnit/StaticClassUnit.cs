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
            var ac = JsonSerializer.Deserialize<AppConfig>(ct);

            var tp = Path.Combine(ac.BaseDirectory, ac.ServiceFolder);

            Console.WriteLine("======");
            
            var dt = File.ReadAllText("template/StaticClass.txt");
            
            string [] records = File.ReadAllLines(ac.ClassMethods);

            foreach(var rec in records)
            {
                var fileName = rec.Replace(",","_");
                new TypeBuilder().Write(
                    ac, 
                    new Model.FileModel(fileName, tp, dt),
                    Model.FileType.Class,
                    dt,
                    new MethodBuilder().Gen(rec));
            }

        }
    }
}