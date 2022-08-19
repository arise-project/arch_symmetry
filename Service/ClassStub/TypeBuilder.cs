using System.IO;
using arch_sync.Model;

namespace arch_sync.Service.ClassStub
{
    public class TypeBuilder
	{
		public void Write(AppConfig ac, FileModel fm, FileType ft)
		{
			//Igla
			var bn = new DirectoryInfo(ac.BaseDirectory).Name;
			var ns = bn + "." + ac.ServiceFolder;
			
			var type = "";
			var dt = File.ReadAllText("DefaultTypeTemplate.txt");				
				
			switch (ft)
			{
				case FileType.Class:
				type = "class";
				break;
				case FileType.Interface:
				type = "interface";
				break;
			}
			
			dt = dt.Replace("{namespace}", ns)
			       .Replace("{type}", type)
			       .Replace("{typeName}", fm.Name);
			
			File.WriteAllText(fm.FullName,dt);
		}
	}	
}
