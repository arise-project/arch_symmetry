using System;
using System.Text.Json;
using System.IO;

namespace arch_sync.Unit
{
    public class InterfaceClassUnit
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