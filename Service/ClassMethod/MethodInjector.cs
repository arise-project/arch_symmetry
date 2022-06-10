using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using arch_sync.Model;
using arch_sync.Model.ClassMethod;

namespace arch_sync.Service.ClassMethod
{
	public class MethodInjector
	{
		public void Write(FileModel fm, FileScope cfs, List<MethodModel> mms)
		{
			var classText = fm.Text.Substring(0, cfs.Beg) + 
			string.Join(Environment.NewLine, mms.Select(m => "public " + m.Method)) +
			fm.Text.Substring(cfs.End);
			
			File.WriteAllText(fm.FullName,classText);
		}
	}	
}
