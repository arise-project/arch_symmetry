using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using arch_sync.Model;

namespace arch_sync.Service.ServiceDependency
{
	public class FileWalker
	{
		public List<FileModel> Walk(string folder)
		{
			List<FileModel> list = new List<FileModel>();
			
			var files = Directory.GetFiles(folder, "I*.cs", SearchOption.AllDirectories);
			Console.WriteLine(files.Length);
			list.AddRange(files.Select(f => 
			{
				Console.WriteLine(f);
				var n = "";
				var p = Path.GetDirectoryName(f);
				
				if(!string.Equals(p, folder))
				{
					var d = new DirectoryInfo(p);
					n = d.Parent.Name;
				}
				
				return new FileModel(f, n, "");	
			}));
			
			return list;
		}
	}	
}
