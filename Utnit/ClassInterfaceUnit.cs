using System;
using System.Text.Json;
using System.IO;
using arch_sync.Service.ClassInterface;

namespace arch_sync.Unit
{
    public class ClassInterfaceUnit
	{
		public void Execute()
		{
			var ct = File.ReadAllText("appSettings.json");
        	Console.WriteLine("======");
        	Console.WriteLine(ct);
        	Console.WriteLine("======");
        	var config = JsonSerializer.Deserialize<AppConfig>(ct);
        	
        	var sm = new StructureScanner().Scan(config);
        	
    		var fm = new FolderMerger();
    		var ims = fm.Merge(sm, sm.Interfaces, sm.Classes);
    		var cms = fm.Merge(sm, sm.Classes, sm.Interfaces);
    		
    		new StructureBuilder().Build(config, sm, cms, ims);
    		
            Console.WriteLine("======");
        	Console.WriteLine("done");
		}
	}
}