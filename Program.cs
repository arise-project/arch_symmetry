using System;
using System.Text.Json;
using System.IO;
using arch_sync.Service;
using arch_sync.Model;

namespace arch_sync
{
    class Program
    {
        static void Main(string[] args)
        {
        	//BV5500Plus
        	
        	var ct = File.ReadAllText("appSettings.json");
        	Console.WriteLine("======");
        	Console.WriteLine(ct);
        	Console.WriteLine("======");
        	var config = JsonSerializer.Deserialize<AppConfiguration>(ct);
        	
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
