using System;
using System.Linq;
using System.Text.Json;
using System.IO;
using arch_sync.Service.ServicesSetup;
using arch_sync.Service.MethodCall;
using System.Linq;

namespace arch_sync.Unit
{
    public class ServicesSetupUnit
    {
        public void Execute()
        {
            var ct = File.ReadAllText("appSettings.json");
            Console.WriteLine("======");
            Console.WriteLine(ct);
            Console.WriteLine("======");
            var ac = JsonSerializer.Deserialize<AppConfig>(ct);

            var cp = Path.Combine(ac.BaseDirectory, ac.ServiceFolder);
            var ip = Path.Combine(ac.BaseDirectory, ac.ServiceFolder, "Interfaces");

            var ips = new ListImplementations().FilterImplementations(ip).ToList();
            //Console.WriteLine(string.Join(Environment.NewLine,ips));
            var di = new DiRealizations().GetPairs(cp,ips);
            Console.WriteLine(string.Join(Environment.NewLine,di));
            new InsertText().Insert(ac.StartupFile, ac.ServicesDiMarker, string.Join(Environment.NewLine, di));

            Console.WriteLine("======");
            Console.WriteLine("done");
        }
    }
}