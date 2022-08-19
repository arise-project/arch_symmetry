using System;
using System.IO;
using System.Linq;
using arch_sync.Model.ClassInterface;

namespace arch_sync.Service.ClassInterface
{
    //KRAB
    public class StructureScanner
	{
		public StructureModel Scan(AppConfig ac)
		{
			StructureModel sm = new StructureModel();
			
			var bn = new DirectoryInfo(ac.BaseDirectory).Name;
			sm.ClassNamespace.Name = bn + "." + ac.ServiceFolder;
			sm.InterfaceNamespace.Name = bn + "." + ac.ServiceFolder + ".Interface";
			
			Console.WriteLine(sm.ClassNamespace.Name);
			Console.WriteLine(sm.InterfaceNamespace.Name);
			
			var fw = new ClassFileWalker();
        		
			if(!Directory.Exists(ac.BaseDirectory))
			{
				throw new ArgumentException(nameof(ac.BaseDirectory));
			}
			
			var wd = Path.Combine(ac.BaseDirectory, ac.ServiceFolder);
			
			if(!Directory.Exists(wd))
			{
				throw new ArgumentException(wd);
			}
			
			var rc = fw.Walk(wd);
			
			Console.WriteLine("walked classes: " + rc.Count);
			
			sm.Classes.AddRange(rc.Select(c => new ClassModel(c.Name, sm.ClassNamespace.Name, c.Namespace, true, c.Empty, null)));
			
			var rip = Path.Combine(wd, "Interface");
			
			if(Directory.Exists(rip))
			{
				var ri = fw.Walk(rip);
				Console.WriteLine("walked interfaces: " + ri.Count);
				
				sm.Interfaces.AddRange(ri.Select(i => new InterfaceModel(i.Name, sm.InterfaceNamespace.Name, i.Namespace, true, i.Empty, null)));	
			}
			
			return sm;
		}
	}	
}
