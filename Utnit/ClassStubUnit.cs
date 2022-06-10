using System;
using System.Linq;
using System.Text.Json;
using System.IO;
using arch_sync.Service.ClassStub;
using arch_sync.Model;

namespace arch_sync.Unit
{
	public class ClassStubUnit
	{
		public void Execute()
		{
			var ct = File.ReadAllText("appSettings.json");
        	Console.WriteLine("======");
        	Console.WriteLine(ct);
        	Console.WriteLine("======");
        	var config = JsonSerializer.Deserialize<AppConfiguration>(ct);
        	
        	var tp = Path.Combine(config.BaseDirectory, config.ServiceFolder);
        	
        	//Harpoon
        	var tms = new TypeFileWalker().Walk(tp);
        	
        	FileType ft = tms.First().Name.IndexOf("I") == 0 ? FileType.Interface : FileType.Class;
        	
        	switch(ft)
        	{
        		case FileType.Interface:
        		Console.WriteLine("interfaces: "+ tms.Count);
        		break;
        		case FileType.Class:
        		Console.WriteLine("classes: "+ tms.Count);
        		break;
        	}
        	
        	foreach(var tm in tms)
        	{
        		new TypeBuilder().Write(config, tm, ft);
        	}
        	
            Console.WriteLine("======");
        	Console.WriteLine("done");
		}
	}
}