using System;
using System.IO;
using arch_sync.Model;
using arch_sync.Model.ClassInterface;

namespace arch_sync.Service.ClassInterface
{
	public class InterfaceWritter
	{
		public void Write(AppConfig ac, NamespaceModel nm, InterfaceModel im, ClassModel cm)
		{
			var pd = new DirectoryInfo(ac.BaseDirectory).Parent.FullName;
			var cp = cm != null ? Path.Combine(pd, cm.Namespace?.Replace(".","/"), cm.Name + ".cs") : null;
			var ip = im != null ? Path.Combine(pd, im.Namespace?.Replace(".","/"), "I" + im.Name + ".cs") : null;
			
			var ct = string.Empty;
			var it = string.Empty;
			
			if(cm != null)
			{
				if(!File.Exists(cp))
				{
					throw new ArgumentException(cp);
				}
				
				ct = File.ReadAllText(cp);
			}
			
			if(string.IsNullOrWhiteSpace(ct) || cm.Empty)
			{
				var dt = File.ReadAllText("DefaultInterfaceTemplate.txt");				
				it = dt.Replace("{interface}", "I" + im.Name)
				       .Replace("{namespace}", im.Namespace.TrimEnd('.'));
			}
			else
			{
				//throw new NotImplementedException();
			}
			
			File.WriteAllText(ip, it);
			Console.WriteLine(ip);
		}
	}	
}
