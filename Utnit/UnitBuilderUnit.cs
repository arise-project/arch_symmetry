using System;
using System.Linq;
using System.Text.Json;
using System.IO;
using arch_sync.Service.UnitBuilder;
using arch_sync.Model;

namespace arch_sync.Unit
{
	public class UnitBuilderUnit
	{
		public void Execute()
		{
			var ct = File.ReadAllText("appSettings.json");
        	Console.WriteLine("======");
        	Console.WriteLine(ct);
        	Console.WriteLine("======");
        	var config = JsonSerializer.Deserialize<AppConfiguration>(ct);
        	
        	var tp = Path.Combine(config.BaseDirectory, config.ServiceFolder);
        	
        	Console.WriteLine("======");
        	Console.WriteLine("not implemented");
		}
	}
}