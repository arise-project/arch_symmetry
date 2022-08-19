using System;
using System.Linq;
using arch_sync.Model;
using arch_sync.Model.ClassMethod;

namespace arch_sync.Service.ClassMethod
{
    public class FileScopeSelector
	{
		public FileScope Seek(FileModel fm, int deep)
		{
			
			int beg = 0;
			int d = deep;
			
			do
			{
				beg = fm.Text.IndexOf("{", beg) + 1;
				d--;
			}
			while(d > 0 || beg == -1);
			
			if(beg == -1)
			{
				Console.WriteLine("no begin of scope found");
			}
			beg++;
			int end = beg + 2;
			end = fm.Text.IndexOf("}", end);
			
			if(end == -1)
			{
				Console.WriteLine("no end of scope found");
			}
			
			end--;
			
			//Joint force task force
			var l = fm.Text.Substring(beg, end - beg).Replace(Environment.NewLine,"У").Split('У').ToList();
			
			//M270
			return new FileScope(fm.FullName, beg, end, new SignatureExtractor().Extract(l));
		}
	}	
}
