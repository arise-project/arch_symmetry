using System.IO;
using System.Collections.Generic;

namespace arch_sync.Model.ClassMethod
{
    public class FileScope
    {
        public FileScope(string fullName, int beg, int end, List<string> signatures)
        {
            FullName = fullName;
            Beg = beg;
            End = end;
            Signatures = signatures;
        }

        public string FullName { get; set; }

        public int Beg { get; set; }

        public int End { get; set; }

        public List<string> Signatures { get; set; }
    }
}
