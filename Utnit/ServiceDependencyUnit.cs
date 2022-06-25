using System;
using System.Linq;
using System.Text.Json;
using System.IO;
using arch_sync.Service.ServiceDependency;
using arch_sync.Model;

namespace arch_sync.Unit
{
	//M142 
	public class ServiceDependencyUnit
	{
		public void Execute()
		{
			var ct = File.ReadAllText("appSettings.json");
        	Console.WriteLine("======");
        	Console.WriteLine(ct);
        	Console.WriteLine("======");
        	var config = JsonSerializer.Deserialize<AppConfiguration>(ct);
        	
        	var tp = Path.Combine(config.BaseDirectory, config.ServiceFolder);
        	
        	var bn = new DirectoryInfo(config.BaseDirectory).Name;
        	Console.WriteLine("Base namespace: " + bn);
        	
        	Console.WriteLine("Service directory: " + tp);
        	var fms = new FileWalker().Walk(tp);
        	Console.WriteLine("Services: " + fms.Count);
        	
        	new StartupUpdater().Update(config.StartupFile, bn, config.ServicesDiMarker, fms);
        	 	
            Console.WriteLine("======");
        	Console.WriteLine("done");
		}
	}
}