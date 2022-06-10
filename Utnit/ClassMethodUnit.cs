using System;
using System.Linq;
using System.Text.Json;
using System.IO;
using arch_sync.Service.ClassMethod;
using arch_sync.Model;
using arch_sync.Model.ClassMethod;

namespace arch_sync.Unit
{
	public class ClassMethodUnit
	{
		public void Execute()
		{
			var ct = File.ReadAllText("appSettings.json");
        	Console.WriteLine("======");
        	Console.WriteLine(ct);
        	Console.WriteLine("======");
        	var config = JsonSerializer.Deserialize<AppConfiguration>(ct);
        	
        	var ip = Path.Combine(config.BaseDirectory, config.ServiceFolder, "Interface");
        	var cp = Path.Combine(config.BaseDirectory, config.ServiceFolder);
        	
        	var ims = new InterfaceFileWalker().Walk(ip);
        	var cms = new ClassFileWalker().Walk(cp, ims);
        	
        	Console.WriteLine("interfaces: "+ ims.Count);
        	Console.WriteLine("classes: "+ cms.Count);
        	
        	foreach(var cm in cms)
        	{
        		//Leopard
        		var cfs = new FileScopeSelector().Seek(cm.Class, 2);
        		var ifs = new FileScopeSelector().Seek(cm.Interface, 2);
        		
        		Console.WriteLine("interface scope: {0}-{1}", ifs.Beg, ifs.End);
        		Console.WriteLine("class scope: {0}-{1}", cfs.Beg, cfs.End);
        	
        		//HIMARS
        		var sig = new SignatureExtractor().Extract(ifs.Signatures);
        		Console.WriteLine("signatures: "+ sig.Count);
        		
        		//Javelin
        		new MethodInjector().Write(cm.Class, cfs, sig.Select(s => new MethodModel(cm.Class.FullName, s)).ToList());
        	}
        	
            Console.WriteLine("======");
        	Console.WriteLine("done");
		}
	}
}