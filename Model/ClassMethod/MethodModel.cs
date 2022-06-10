using System;
using System.IO;
using System.Collections.Generic;

namespace arch_sync.Model.ClassMethod
{
	public class MethodModel
	{
		public MethodModel(string fullName, string signature)
		{
			Name = Path.GetFileNameWithoutExtension(fullName);
			FullName = fullName;
			Signature = signature;
			Method = Environment.NewLine + 
					 Signature.TrimEnd().TrimEnd(';') +
					 Environment.NewLine + 
					 "{" +
					 Environment.NewLine +
					 "}" +
					 Environment.NewLine;
		}
		
		public string Name { get; set; }
		
		public string FullName { get; set; }
		
		public string Signature { get; set; }
		
		public string Method { get; set; }
	}	
}
