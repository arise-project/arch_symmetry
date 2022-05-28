using System;
using System.IO;
using arch_sync.Model;

namespace arch_sync.Service
{
	public class ClassWritter
	{
		public void Write(AppConfiguration ac, NamespaceModel nm, ClassModel cm, InterfaceModel im)
		{
			var pd = new DirectoryInfo(ac.BaseDirectory).Parent.FullName;
			var cp = cm != null ? Path.Combine(pd, cm.Namespace?.Replace(".","/"), cm.Name + ".cs") : null;
			var ip = im != null ? Path.Combine(pd, im.Namespace?.Replace(".","/"), "I" + im.Name + ".cs") : null;
			
			var ct = string.Empty;
			var it = string.Empty;
			if(im != null)
			{
				if(!File.Exists(ip))
				{
					throw new ArgumentException(ip);
				}
				
				it = File.ReadAllText(ip);
			}
			
			if(string.IsNullOrWhiteSpace(it) || im.Empty)
			{
				var dt = File.ReadAllText("DefaultClassTemplate.txt");				
				ct = dt.Replace("{interface_namespace}", cm.Namespace + "Interface")
				       .Replace("{interface}", "I" + cm.Name)
				       .Replace("{namespace}", cm.Namespace.TrimEnd('.'))
				       .Replace("{class}", cm.Name);
			}
			else
			{
				//throw new NotImplementedException();
			}
			
			File.WriteAllText(cp, ct);
			Console.WriteLine(cp);
		}
	}	
}
