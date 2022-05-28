using System.IO;
using System.Linq;
using System.Collections.Generic;
using arch_sync.Model;

namespace arch_sync.Service
{
	public class FileWalker
	{
		public List<FileModel> Walk(string folder)
		{
			List<FileModel> list = new List<FileModel>();
			
			var files = Directory.GetFiles(folder, "*.cs", SearchOption.TopDirectoryOnly);
			
			list.AddRange(files.Select(f => new FileModel(f, "", File.ReadAllText(f))));
			
			var sub = Directory.GetDirectories(folder).Where(f => new FileInfo(f).DirectoryName != "Interface" );
			
			list.AddRange(sub.SelectMany(s => 
					Directory.GetFiles(s, "*.cs", SearchOption.TopDirectoryOnly))
					.Select(f => new FileModel(
										f, 
										Path.GetDirectoryName(f).Substring(folder.Length),
										File.ReadAllText(f))));
			
			return list;
		}
	}	
}
