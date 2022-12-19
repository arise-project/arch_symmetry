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
            
            var dt = File.ReadAllText(ac.Template);
            
            string [] records = File.ReadAllLines(ac.ClassMethods);

            foreach(var rec in records)
            {
                var fileName = rec.Replace(",","_");
                if(!string.IsNullOrWhiteSpace(fileName))
                {
                    new TypeBuilder().Write(
                    ac,
                    new Model.FileModel(Path.Combine(tp,fileName + "." + ac.Lang), tp, dt),
                    rec.Split(',')[0],
                    Model.FileType.Class,
                    dt,
                    new MethodBuilder().Gen(rec));
                }
            }

        }
    }
}